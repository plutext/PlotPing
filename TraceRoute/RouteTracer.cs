using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Text;
using System.ComponentModel;

namespace TraceRoute
{   
    /// <summary>
    /// Allows an application to perform a traceroute, displaying the path and latency of packets across an IP network.
    /// </summary>
    public class RouteTracer
    {
        public static List<Hop> traceRoute(string ipAddrOrHostname, int maxHops=30, int timeout=5000, byte[] buffer=null)
        {
            PingOptions pingOpts = new PingOptions();
            Stopwatch      watch = new Stopwatch();
            pingOpts.Ttl = 1;   // only allow one hop initially

            // create default buffer to send if not specified
            if (buffer == null)
                buffer = new byte[32];

            List<Hop> hops = new List<Hop>();
            for (int i = 0; i < maxHops; i++)
            {
                // send ping and hop, and keep track of the time it takes
                Ping pinger = new Ping();
                watch.Reset();
                watch.Start();

                PingReply reply;
                // make sure that the address is a vaild one
                try
                {
                    reply = pinger.Send(ipAddrOrHostname, timeout, buffer, pingOpts);
                }
                catch (PingException e)
                {
                    throw (e);
                }
                watch.Stop();

                // save all the hop information
                Hop curHop = new Hop(i, reply.Address, watch.ElapsedMilliseconds);
                hops.Add(curHop);
                if (reply.Status == IPStatus.Success)   // destination reached
                    break;
                pingOpts.Ttl++;
            }
            return hops;
        }
    }

    public class Hop
    {
        public int hopNum;      // number of hop in trace route
        public IPAddress ip;    // ip address of hop
        public long time;       // time hop took in ms

        public Hop(int hopNum, IPAddress ip, long time)
        {
            this.hopNum = hopNum;
            this.ip = ip;
            this.time = time;
        }
    }
}
