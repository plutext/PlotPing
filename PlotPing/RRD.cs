using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.ComponentModel;
using robin.core;
using robin.graph;
using System.Drawing; 

namespace PlotPing
{
    /// <summary>
    /// Use https://github.com/plutext/robin.net to generate RRD data.
    /// There is also https://code.google.com/p/rrd4net, but I haven't tried it.
    /// </summary>
    class RRD : TimeSeriesStore
    {

        /// <summary>
        /// This method saves:
        /// 1. a .rrd file
        /// 2. a RRD .xml file 
        /// 3. a PNG (proof of concept - just to demonstrate value of interop)
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="traceInterval"></param>
        /// <param name="dates"></param>
        /// <param name="pings"></param>
        /// <param name="hostOrIp"></param>
        /// <param name="networkInterfaceText"></param>
        /// <param name="userNotes"></param>
        public static void save(string filename, double traceInterval, List<DateTime> dates , BindingList<long> pings,
            string hostOrIp, string routeToDestination, string networkInterfaceText, string userNotes)
        {
            // Delete pre-existing file to avoid Rrd error
            if (File.Exists(filename))
            {
                File.Delete(filename);
            }

            RrdDef def = new RrdDef(filename);
            def.Step = (long)traceInterval;
			def.StartTime = dates[0].GetTimestamp();

			def.AddDatasource(DsDef.FromRrdToolString("DS:input:GAUGE:600:0:U"));
            int rows = pings.Count-1;
			def.AddArchive(ArcDef.FromRrdToolString("RRA:AVERAGE:0.5:1:"+rows));
            using (RrdDb db = RrdDb.Create(def))
            {
                Sample sample = db.CreateSample();
                for (int i = 1; i < pings.Count; i++) // skip first
                {
                    sample.Set(dates[i], pings[i]);
                    sample.Update();

                }

                // Save the XML version
                String filenameXML = filename + ".xml";
                if (File.Exists(filenameXML))
                {
                    File.Delete(filenameXML);
                }
                db.ToXml(filenameXML);

                /* There doesn't seem to be a way to add comments to rrd file.
                 * Maybe the best we can do is to insert them in the XML file
                 * as an XML comment? */ 

            }


            saveAsPng(filename, dates, hostOrIp, routeToDestination, networkInterfaceText, userNotes);
        }

        public static void saveAsPng(string filename, List<DateTime> dates, string hostOrIp, 
            string routeToDestination, string networkInteface, string userNotes)
        {
            // RrdGraph output is not perfect, but it does produce a graph.
            // For better results, use some other graph library, eg 
            // could try Java https://code.google.com/p/rrd4j/
            // or http://oldwww.jrobin.org/api/graphingapi.html
            // or possibly https://code.google.com/p/rrd4net/source/browse/#svn%2Ftrunk%2Frrd4n.Graph

            RrdGraphDef def = new RrdGraphDef();
            def.setTimeSpan(dates[0].GetTimestamp(), dates[dates.Count - 1].GetTimestamp());

            def.setVerticalLabel("ms");
            def.setTitle("Ping times to " + hostOrIp + " via " + routeToDestination);
            def.datasource("in", filename, "input", ConsolidationFunction.AVERAGE);
            def.line("in", Color.Green, "ping time");

            def.imageFormat="png";
            def.filename=filename+"."+def.imageFormat;
            if (File.Exists(def.filename))
            {
                File.Delete(def.filename);
            }
            RrdGraph g = new RrdGraph(def);


        }
    }
}
