using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms;

namespace TraceRoute
{   
    /// <summary>
    /// Allows an application to perform a traceroute, displaying the path and latency of packets across an IP network.
    /// </summary>
    public class RouteTracer
    {
        public static List<Hop> traceRoute(string ipAddrOrHostname, GatewayIPAddressInformation gateway, int minHops, int maxHops = 50, int timeout = 5000, byte[] buffer = null)
        {
            PingOptions pingOpts = new PingOptions();
            Stopwatch      watch = new Stopwatch();
            //pingOpts.Ttl = 1;   // only allow one hop initially

            // create default buffer to send if not specified
            if (buffer == null)
                buffer = new byte[32];

            List<Hop> hops = new List<Hop>();
            
            // Always do the first hop, so we can verify expected route is being used;
            // and if no interface was specified, well, its cheap anyway, since this is inside our PC 
            if (doPing(0, hops, pingOpts, watch, ipAddrOrHostname, timeout, buffer))
            {
                // check it 
                if (gateway!=null)
                {
                    if (!gateway.Address.ToString().Equals(hops[0].ip))
                    {
                        MessageBox.Show("WARNING: First hop" + hops[0].ip
                            + " didn't match intended gateway " + gateway.Address.ToString() + "; try 'route print'.");
                    }
                }
            }
            else
            {
                // stop
                if (gateway != null)
                {
                    MessageBox.Show("Gateway " + gateway.Address.ToString() + " down?");
                }
                else
                {
                    MessageBox.Show(hops[0].ip);
                }
                return hops;
            }

            if (minHops > 0)
            {
                // prefill
                for (int i = 1; i < minHops; i++)
                {
                    hops.Add(new Hop(i, "Dummy entry", -1, false));
                }
            }
            int start = Math.Max(minHops, 1);
            for (int i = start; i < maxHops; i++)
            {
                if (!doPing(i, hops, pingOpts, watch, ipAddrOrHostname,   timeout ,  buffer)) {
                    // stop
                    break;
                }
            }
            return hops;
        }

        private static bool doPing(int hopNum, List<Hop> hops, PingOptions pingOpts, Stopwatch watch,
            string ipAddrOrHostname,  int timeout , byte[] buffer)
        {
            pingOpts.Ttl = hopNum+1;

            // send ping and hop, and keep track of the time it takes
            Ping pinger = new Ping();
            watch.Reset();
            watch.Start();

            // make sure that the address is a valid one
            PingReply reply;
            try
            {
                reply = pinger.Send(ipAddrOrHostname, timeout, buffer, pingOpts);
            }
            catch (PingException e)
            {
                hops.Add(new Hop(hopNum, "Request timed out", -1, true));
                //break;
                return false;
            }
            watch.Stop();


            // catch and fix timed out hops
            Hop curHop;
            if (reply.Status != IPStatus.TimedOut)
                curHop = new Hop(hopNum, reply.Address.ToString(), watch.ElapsedMilliseconds, false);
            else
                curHop = new Hop(hopNum, "Request timed out", -1, true);

            hops.Add(curHop);

            // destination reached
            if (reply.Status == IPStatus.Success)
            {
                //break;
                return false;
            }
            return true;
        }
    }

    public class Hop
    {
        public int hopNum;      // number of hop in trace route
        public string ip;       // ip address of hop
        public long time;       // time hop took in ms
        public bool timedOut;   // did the hop time out?

        public Hop(int hopNum, string ip, long time, bool timedOut)
        {
            this.hopNum = hopNum;
            this.ip = ip;
            this.time = time;
            this.timedOut = timedOut;
        }
    }
}
