using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace PlotPing
{
    class TxtDataHandler
    {
        // export all trace and historical ping data to a plain text file.
        public static void saveData(string filename, string extension, DataGridView routeInfo, List<long> pings, List<DateTime> times)
        {
            TextWriter tw = new StreamWriter(filename);

            // write last route info to file
            tw.WriteLine(string.Format("# route info as of {0}", times[times.Count-1]));
            tw.WriteLine("# hop number, IP address, hostname, latency");
            foreach(DataGridViewRow row in routeInfo.Rows)
            {
                string line = "";
                foreach(DataGridViewCell cell in row.Cells)
                    line += cell.Value.ToString() + ", ";

                char[] trimChars = {',', ' '};
                line = line.TrimEnd(trimChars);
                tw.WriteLine(line);
            }

            // write all pings/times to file
            tw.WriteLine();
            tw.WriteLine(string.Format("# all pings recorded over interval: {0} - {1}", times[0], times[times.Count - 1]));
            tw.WriteLine("# MM/dd/yyyy hh:mm:ss, latency (ms)");
            for (int i = 0; i < pings.Count; i++)
                tw.WriteLine(times[i].ToString() + ", " + pings[i].ToString());
            tw.Close();
        }
    }
}
