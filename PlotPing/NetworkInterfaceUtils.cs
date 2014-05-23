using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.NetworkInformation;
using System.Net;
using System.Net.Sockets;
using System.Diagnostics;
using System.Windows.Forms;

namespace PlotPing
{
    /// <summary>
    /// Adapted from Eric Sierp's post at
    /// http://social.msdn.microsoft.com/Forums/vstudio/en-US/953ca987-b37a-42e2-8eaf-3378fb88282f/testing-for-internet-connectivity-across-a-specific-network-adapter?forum=csharpgeneral
    /// </summary>
    class NetworkInterfaceUtils
    {
        /// <summary>
        /// Returns the destination IP we'll later want to delete
        /// </summary>
        /// <param name="adapter"></param>
        /// <param name="hostOrIp"></param>
        /// <returns></returns>
        public static string AddRoute(NetworkInterface adapter, string hostOrIp )
        {
            IPAddress remoteAddress = null;
            if (IPAddress.TryParse(hostOrIp, out remoteAddress)) {
                // already an IP address
            } else {
                // resolve it
                try
                {
                    IPAddress[] addresslist = Dns.GetHostAddresses(hostOrIp);
                    if (addresslist.Length == 0)
                    {
                        MessageBox.Show("Can't resolve " + hostOrIp);
                    }
                    else
                    {
                        remoteAddress = addresslist[0];
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                    return null;
                }

            }


            IPInterfaceProperties properties = adapter.GetIPProperties();

            try
            {
                if (remoteAddress != null)
                {
                    GatewayIPAddressInformationCollection gateways = properties.GatewayAddresses;
                        for (int j = 0; j < gateways.Count; j++)
                        {
                            GatewayIPAddressInformation gateway = gateways[j];

                            // Add the route entry to the route table to solve the Windows XP issue.
                            AddRoute(gateway.Address.ToString(), remoteAddress.ToString());
                        }
                }
            }

            catch (Exception ex)
            {
                //DebugEx.WriteException(ex);
                MessageBox.Show(ex.Message, "Error");
                return null;
            }

            return remoteAddress.ToString();
        }

        // Since the Windows XP does not support the multiple default gateway.
        // In order to make the Ethernet can be access via its default gateway, we need to add the gateway into the route table.
        // For more information, plesae refer to the KB article.
        // http://support.microsoft.com/kb/159168
        private static void AddRoute(string gateway, string destination)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo("route");
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.Arguments = string.Format(" add {0} mask 255.255.255.255 {1}", destination, gateway);
            startInfo.Verb = "runas";
            string commandline = startInfo.ToString();
            MessageBox.Show("Executing: route " + startInfo.Arguments);
            Process p = Process.Start(startInfo);
            p.WaitForExit();
            int exitCode = p.ExitCode;
            if (exitCode != 0)
            {
                MessageBox.Show("hmm .. exitCode " + exitCode+ " (whatever that means)");
            }
        }

        public static void RemoveRoute(string destination)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo("route");
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.Arguments = string.Format(" delete {0}", destination);
            startInfo.Verb = "runas";

            Process p = Process.Start(startInfo);
            p.WaitForExit();
            int exitCode = p.ExitCode;
            if (exitCode != 0)
            {
                MessageBox.Show("hmm .. maybe we didn't delete the route? exit code : " + exitCode + " Try route " + startInfo.Arguments);
            }
        }
    }
}
