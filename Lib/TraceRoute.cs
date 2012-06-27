using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading;
using System.Diagnostics;


namespace PlotPing
{
    public class TraceRoute
    {
        // returns an array of "hops" representing a complete traceroute from the local address to passed parameter `ip`.
        // each hop is ran in a separate thread which dramatically decreases the completion time of each trace.
        public static Hop[] GetTraceRoute(string ip, int curNumHops, int maxNumHops, int timeout, Hop[] prevHops)
        {
            int numHops = curNumHops;
            Hop[] hops = null;
            ManualResetEvent[] doneEvents = null;

            while (true)
            {
                hops = new Hop[numHops];
                doneEvents = new ManualResetEvent[numHops];
                for (int i = 0; i < numHops; i++)
                {
                    doneEvents[i] = new ManualResetEvent(false);
                    Hop hop = new Hop(i + 1, ip, doneEvents[i]);
                    hops[i] = hop;

                    HopThreadContext getHopArgs;
                    // if previous tracert has not been ran, prevHop is null
                    if (prevHops != null && i < prevHops.Length)
                        getHopArgs = new HopThreadContext(prevHops[i], timeout);
                    else
                        getHopArgs = new HopThreadContext(null, timeout);

                    ThreadPool.QueueUserWorkItem(hop.GetHop, getHopArgs);
                }

                WaitHandle.WaitAll(doneEvents);
                // if we didn't reach the destination, increase hops to max and try again
                if (!hops[hops.Length - 1].destReached && numHops != maxNumHops)
                    numHops = maxNumHops;
                else if (!hops[hops.Length - 1].destReached && numHops == maxNumHops)
                    throw new Exception("Specified route destination not reached.");
                else
                    break;
            }
                
            return hops;
        }
    }

    // contains all information to be passed into GetHop
    public class HopThreadContext
    {
        public Hop prevHop;
        public int timeout;

        public HopThreadContext(Hop prevHop, int timeout)
        {
            this.prevHop = prevHop;
            this.timeout = timeout;
        }
    }

    public class Hop
    {
        public int num;
        public long latency;
        public bool destReached = false, timedOut = false;
        public string dest, ip, hostname;
        private ManualResetEvent doneEvent;

        public Hop(int num, string dest, ManualResetEvent doneEvent)
        {
            this.num = num;
            this.dest = dest;
            this.doneEvent = doneEvent;
        }

        // send the ping to the specific hop
        public void GetHop(Object threadContext)
        {
            HopThreadContext hopArgs = (HopThreadContext)threadContext;
            int timeout = hopArgs.timeout;
            PingOptions pingOpts = new PingOptions();
            Stopwatch watch = new Stopwatch();

            pingOpts.Ttl = num;
            byte[] buffer = new byte[32];

            // send the ping to the current hop
            Ping pinger = new Ping();
            PingReply reply;
            watch.Reset();
            watch.Start();
            try
            {
                reply = pinger.Send(dest, timeout, buffer, pingOpts);
            }
            catch (PingException)
            {
                ip = "Could not find address...";
                hostname = "----";
                latency = -1;
                doneEvent.Set();
                return;
            }
            watch.Stop();

            if (reply.Status == IPStatus.TimedOut)
            {
                ip = "Request timed out";
                hostname = "----";
                latency = -1;
                timedOut = true;
            }
            else
            {
                ip = reply.Address.ToString();

                // if the ip from the previous tracert is the same, save some time by not looking up the hostname
                if (hopArgs.prevHop == null || hopArgs.prevHop.ip != ip)
                {
                    try
                    {
                        hostname = Dns.GetHostEntry(IPAddress.Parse(ip)).HostName;
                    }
                    catch   // couldn't resolve hostname
                    {
                        hostname = "----";
                    }
                }
                else
                    hostname = hopArgs.prevHop.hostname;

                latency = watch.ElapsedMilliseconds;
                if (reply.Status == IPStatus.Success)
                    destReached = true;
            }
            doneEvent.Set();
        }
    }
}
