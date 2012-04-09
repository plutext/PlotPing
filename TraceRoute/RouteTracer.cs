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
                PingReply reply = pinger.Send(ipAddrOrHostname, timeout, buffer, pingOpts);
                watch.Stop();

                /* get hostname from ip address
                String curHostName;
                try{ curHostName = Dns.GetHostEntry(reply.Address).HostName; }
                catch (SocketException){ curHostName = "--"; } */

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

    public class Hop : INotifyPropertyChanged
    {
        private int _hopNum;      // number of hop in trace route
        private IPAddress _ip;    // ip address of hop
        private long _time;       // time hop took in ms
        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public Hop(int hopNum, IPAddress ip, long time)
        {
            _hopNum = hopNum;
            _ip = ip;
            _time = time;
        }

        public int hopNum
        {
            get { return _hopNum; }
            set { _hopNum = value; }
        }

        public IPAddress ip
        {
            get { return _ip; }
            set { _ip = value; }
        }

        public long time
        {
            get { return _time; }
            set { _time = value; }
        }
    }
}
