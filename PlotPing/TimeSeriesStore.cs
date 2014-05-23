using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlotPing
{
    /// <summary>
    /// There are various open approaches to storing time series data.
    /// If the data is stored in an open format, then an ecosystem of
    /// tools can be used to graph it etc.
    /// 
    /// Stores include:
    /// - RRD (big ecosystem but growing old; no widely used C# implementation; we're using https://github.com/plutext/robin.net
    /// - http://graphite.wikidot.com/whisper
    /// - http://opentsdb.net/ (runs on Hadoop and HBase)
    /// - https://code.google.com/p/kairosdb/ (rewrite of OpenTSDB; Java; written on top of Cassandra or HBase)
    ///   Graphs via Flot or Highcharts; 
    /// - InfluxDB 
    /// 
    /// .NET specific:
    /// - https://github.com/discretelogics/TeaFiles.Net (but no free graphing;
    ///   though see http://stackoverflow.com/questions/17113156/architecture-behind-teafiles-and-teahouse-charting-library
    /// - cronos.codeplex.com
    /// </summary>
    interface TimeSeriesStore
    {
    }
}
