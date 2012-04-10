using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TraceRoute;

namespace TestTrace
{
    class TestTrace
    {
        static void Main(string[] args)
        {

            List<Hop> hops = RouteTracer.traceRoute("g-s.cn",30,1000);
            Console.WriteLine(hops.Count);
            foreach (Hop hop in hops)
            {
                Console.WriteLine("{0}\t {1}\t {2}\t {3}", hop.hopNum, hop.ip, hop.time, hop.timedOut);
            }

            Console.ReadKey();
        }
    }
}
