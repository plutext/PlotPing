using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TraceRoute;
using System.Threading;
using System.Net;
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;
using System.Net.NetworkInformation;

namespace PlotPing
{
    public partial class PlotPing : Form
    {
        /// <summary>
        /// To save bandwidth, perform the traceroute once only.  
        /// After that, just ping the last hop entry
        /// UNLESS last ping was > MAX_PING_MS_YELLOW
        /// This is consistent with the data we save (ie even if we keep
        /// repeating the traceroute, the traceroute data is thrown away).
        /// POSSIBLY: add a toggle to the UI allowing the user to control this.
        /// </summary>
        private Boolean TRACEROUTE_ONCE_ONLY = true;

        /// <summary>
        /// Use green (lime actually), for time less than this
        /// </summary>
        private int MAX_PING_MS_GREEN = 200; // more evocative than calling it _LIME
        private int MAX_PING_MS_YELLOW = 500;

        private int counterGreen = 0;
        private int counterYellow = 0;
        private int counterRed = 0;

        private List<DateTime> dates = new List<DateTime>();
        private BindingList<long> pings = new BindingList<long>();
        private string hostOrIp;
        private Axis axisX;
        private Axis axisY;
        private Series pingSeries;
        private int nTraces;
        private double traceInterval;
        private DateTime tStart;
        private DateTime tEnd;
        private int nDataPts = 240;
        private int nGridPts = 8;

        private int AXIS_Y_MAXIMUM = 1200; // use -1 to scale; I prefer not to scale it
        private long quickest = 1200; // keep track of our fastest ping time

        private NetworkInterface[] networkInterfaces;
        private NetworkInterface networkInterface;

        private string routeToDestination;
        private GatewayIPAddressInformation gateway;

        private List<EndPoint> endpoints = new List<EndPoint>();

        public PlotPing()
        {
            InitializeComponent();
            traceIntUpDown.Maximum = Decimal.MaxValue;
            nTraceUpDown.Maximum = Decimal.MaxValue;
            chartPings.Visible = false;

            // TODO persist these values
            endpoints.Add(new EndPoint("www.google.com"));
            endpoints.Add(new EndPoint("slashdot.org"));
            endpoints.Add(new EndPoint("172.24.223.225", "Optus"));
            endpoints.Add(new EndPoint("10.143.110.65", "Vodafone"));
            endpoints.Add(new EndPoint("139.130.111.73", "Telstra"));
            endpoints.Add(new EndPoint("10.202.0.1", "Connectify Gateway"));
            //, "101.119.16.21"
            endpoints.Add(new EndPoint("125.63.57.173", "Connectify Sydney")); 

            this.addrComboBox.Items.AddRange(endpoints.ToArray());

            // Populate available interfaces
            networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();

            foreach (NetworkInterface adapter in networkInterfaces)
            {
                listBoxNetworkInterface.Items.Add(interfaceLabel(adapter));
            }

            listBoxNetworkInterface.MouseMove += new MouseEventHandler(listBox1_MouseMove);

            routeListView.ItemDrag += new ItemDragEventHandler(routeListView_ItemDrag);

        }

        /// <summary>
        /// Provides an easy way to copy the IP address from one of the 
        /// hops.  Use case: you enter google.com, but you really only
        /// care whether your packets are making it through your ISP,
        /// so you want to copy an IP address much closer to home
        /// (and restart PlotPing using that).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void routeListView_ItemDrag(object sender, ItemDragEventArgs e)
        {
            ListViewItem item = (ListViewItem)e.Item;
            string ip = item.SubItems[1].Text;
            System.Windows.Forms.Clipboard.SetText(ip);
            MessageBox.Show(ip + " on clipboard");
        }



        void listBox1_MouseMove(object sender, MouseEventArgs e)
        {
            // Adapted from http://www.codeproject.com/Articles/32124/Showing-a-Separate-Tooltip-for-Each-Item-in-a-List
            // License is http://www.codeproject.com/info/cpol10.aspx

            // TODO: fix the flickering

                try
                {
                    ListBox objListBox = (ListBox)sender;
                    int itemIndex = -1;
                    if (objListBox.ItemHeight != 0)
                    {
                        itemIndex = e.Y / objListBox.ItemHeight;
                        itemIndex += objListBox.TopIndex;
                    }
                    if ((itemIndex >= 0 && itemIndex!=lastIndex))
                    {
                        string tooltip = interfaceTooltip(networkInterfaces[itemIndex]);
                        toolTipNetworkInterface.SetToolTip(objListBox, tooltip );
                        lastIndex = itemIndex;

                        // Also stick it in here, so you can read without flickering
                        this.textBoxUserNotes.Text = tooltip;
                    }
                    else
                    {
                        toolTipNetworkInterface.Hide(objListBox);
                        lastIndex = -1;
                    }
                }
                catch (Exception ex)
                {
                }
        }
        private int lastIndex = -1;


        private string interfaceTooltip(NetworkInterface adapter)
        {
            StringBuilder sb = new StringBuilder();
            if (!adapter.OperationalStatus.Equals(OperationalStatus.Up))
            {
                sb.AppendLine("** Status " + adapter.OperationalStatus + " **");
            }
            sb.AppendLine("Name\t\t: " + adapter.Name);
            //sb.AppendLine("Id\t\t: " + adapter.Id);
            sb.AppendLine("Type\t\t: " + adapter.NetworkInterfaceType);
            sb.AppendLine("Description\t: " + adapter.Description);
            UnicastIPAddressInformationCollection unicastIPC = adapter.GetIPProperties().UnicastAddresses;
            foreach (UnicastIPAddressInformation unicast in unicastIPC)
            {
                sb.AppendLine(unicast.Address.AddressFamily + "\t: " + unicast.Address);
            }           
            return sb.ToString();
        }

        private string interfaceLabel(NetworkInterface adapter)
        {
            // Various options here; this'll do, since we show the rest in the tooltip
            return adapter.Description;
        }

        private NetworkInterface getInterface(string label)
        {
            foreach (NetworkInterface adapter in networkInterfaces)
            {
                // TODO filter out irrelevant ones
                if (interfaceLabel(adapter).Equals(label)) return adapter;
            }
            return null;
        }

        private void traceBtn_Click(object sender, EventArgs e)
        {
            EndPoint theEndPoint = null;
            foreach (EndPoint ep in endpoints)
            {
                if (ep.ToString().Equals(addrComboBox.Text))
                {
                    theEndPoint = ep;
                    break;
                }
            }

            if (theEndPoint == null)
            {
                theEndPoint = new EndPoint(addrComboBox.Text);
                addrComboBox.Items.Add(theEndPoint);
                endpoints.Add(theEndPoint);
            }
            hostOrIp = theEndPoint.HostOrIp;
            
            // start traceroute if not already running, otherwise kill it.
            if (!tracertBackgroundWorker.IsBusy)
            {
                // save user input here
                nTraces = (int)nTraceUpDown.Value;
                traceInterval = (double)traceIntUpDown.Value;
                tStart = DateTime.Now;
                tEnd = DateTime.Now;
                networkInterface = getInterface((string)listBoxNetworkInterface.SelectedItem);
                if (networkInterface != null)
                {
                    // set the route
                    routeToDestination = NetworkInterfaceUtils.AddRoute(networkInterface, hostOrIp);

                    IPInterfaceProperties properties = networkInterface.GetIPProperties();
                    GatewayIPAddressInformationCollection gateways = properties.GatewayAddresses;
                    gateway = gateways[0]; // just use the first one
                }

                // clear any previously logged data
                dates.Clear();
                pings.Clear();

                // start the traceroute in a separate thread
                tracertBackgroundWorker.RunWorkerAsync();
                
                // update form
                traceBtn.Text = "Stop";
                lblTarget.Text = hostOrIp;
                lblStartTime.Text = tStart.ToString() + "       to";
                lblEndTime.Visible = true;
                lblEndTime.Text = tEnd.ToString();
                progressBar1.Visible = true;

            }
            else if (tracertBackgroundWorker.IsBusy)
            {
                tracertBackgroundWorker.CancelAsync();
                traceBtn.Text = "Stopping...";
                traceBtn.Enabled = false;

                // Delete the route
                if (routeToDestination != null)
                {
                    NetworkInterfaceUtils.RemoveRoute(routeToDestination);
                }
            }
        }

        // Runs a traceroute in a separate thread
        private void tracertBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            if (nTraces == 0) nTraces = Int32.MaxValue; // 0 means loop forever

            // get sleep time and convert sec to ms
            int tsleep = (int)(1000*traceIntUpDown.Value);

            List<Hop> hops=null;
            for (int i = 0; i < nTraces; i++)
            {
                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                    break;
                }
                if (forceTableUpdate)
                {
                    // traceroute to all hops, to diagnose issue
                    hops = RouteTracer.traceRoute(hostOrIp, gateway, 0, timeout: AXIS_Y_MAXIMUM);
                }
                else if (TRACEROUTE_ONCE_ONLY && hops != null)
                {
                    hops = RouteTracer.traceRoute(hostOrIp, gateway, hops.Count - 1, timeout: AXIS_Y_MAXIMUM);
                }
                else
                {
                    hops = RouteTracer.traceRoute(hostOrIp, gateway, 0, timeout: AXIS_Y_MAXIMUM);
                }
                tracertBackgroundWorker.ReportProgress(i, hops);
                Thread.Sleep(tsleep);
            }
        }


        private bool forceTableUpdate = false;

        // updates the program for each completed ping (a full traceroute).
        private void tracertBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            int i = e.ProgressPercentage;
            List<Hop> hops = (List<Hop>)e.UserState;
            long previousPing = hops.Last().time;
            totPingLbl.Text = previousPing.ToString() + " ms";

            // initialize or update table
            if (i == 0)
            {
                // first ping was a timeout
                if (hops.Last().time == -1)
                {
                    tracertBackgroundWorker.CancelAsync();
                    MessageBox.Show("Could not establish connection to address!  The address might not support ICMP, be invalid or it may be down. There may also be a problem with your connection.", "PlotPing: ERROR");
                    //chartPings.Visible = false;
                    return;
                }
                initTable(hops);

                // clear the plot if it has data
                chartPings.Series[0].Points.Clear();
                initChart();
            }
            else if (previousPing == -1 || previousPing > MAX_PING_MS_YELLOW)
            {
                // FIXME: this is reacting an iteration or 2 too late..
                // but that's ok for a problem which goes on for a while
                updateLastTableRow(hops.Last());
                forceTableUpdate = true;
            }
            else if (!TRACEROUTE_ONCE_ONLY)
            {
                drawTable(hops);
            }
            else if (forceTableUpdate)
            {
                drawTable(hops);
                forceTableUpdate = false;
            }
            else
            {
                // Just update the last entry
                updateLastTableRow(hops.Last());
            }

            // plot results so far
            updateChart(hops.Last().time);

            // update stats
            int total = counterGreen + counterYellow + counterRed;
            this.labelGreenPercent.Text = Math.Round((decimal)counterGreen * 100 / total)+"%";
            this.labelRedPercent.Text = Math.Round((decimal)counterRed * 100 / total) + "%";

            if (hops.Last().time > 0
                && hops.Last().time < quickest)
            {
                quickest = hops.Last().time;
                this.textBoxFastestResult.Text = ""+quickest;
            }

            // update sample interval
            tEnd = DateTime.Now;
            lblEndTime.Text = tEnd.ToString();
        }

        // done pinging
        private void tracertBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            traceBtn.Text = "Trace";
            traceBtn.Enabled = true;
            progressBar1.Visible = false;
            tEnd = DateTime.Now;
            lblEndTime.Text = tEnd.ToString();
        }

        // initializes the traceroute table
        private void initTable(List<Hop> hops)
        {
            routeListView.Items.Clear();
            foreach (Hop hop in hops)
            {
                ListViewItem item = new ListViewItem();
                item.UseItemStyleForSubItems = false;   // set to false, otherwise items don't appear

                item.Text = hop.hopNum.ToString();
                item.SubItems.Add(hop.ip);
                item.SubItems.Add(hop.time.ToString());

                // color code pings 
                if (hop.time <= MAX_PING_MS_GREEN && hop.time >= 0) {
                    item.SubItems[2].BackColor = Color.Lime;
                    // Don't count pings of our local gateway
                    if (gateway == null || !gateway.Equals(hop.ip))
                    {
                        this.counterGreen++;
                    }
                }
                else if (hop.time > MAX_PING_MS_GREEN && hop.time <= MAX_PING_MS_YELLOW)
                {
                    item.SubItems[2].BackColor = Color.Yellow;
                    this.counterYellow++;
                }
                else
                {
                    item.SubItems[2].BackColor = Color.Red;
                    this.counterRed++;
                }

                routeListView.Items.Add(item);
            }
            
            hideHScrollBar();
        }

        // redraws the trace route table
        private void drawTable(List<Hop> hops)
        {   
            if(hops.Count != routeListView.Items.Count)
                initTable(hops);
            else
            {
                // update the table instead of totally re-writing it.
                for (int j = 0; j < hops.Count; j++)
                {
                    ListViewItem curItem = routeListView.Items[j];
                    Hop curHop = hops[j];

                    updateTableRow(curHop, curItem);
                }
            }

            hideHScrollBar();
        }

        private void updateLastTableRow(Hop curHop)
        {
            ListViewItem curItem = routeListView.Items[routeListView.Items.Count-1];
            updateTableRow(curHop, curItem);
        }

        private void updateTableRow(Hop curHop, ListViewItem curItem)
        {
            // if prev ip != cur ip
            if (curItem.SubItems[1].Text != curHop.ip.ToString())
            {
                curItem.SubItems[1].Text = curHop.ip.ToString();
            }

            // if prev time != cur time
            if (curItem.SubItems[2].Text != curHop.time.ToString())
                curItem.SubItems[2].Text = curHop.time.ToString();

            // color code pings 
            Color bg = curItem.SubItems[2].BackColor;
            if (curHop.time <= MAX_PING_MS_GREEN && curHop.time != -1 && bg != Color.Lime) {
                curItem.SubItems[2].BackColor = Color.Lime;
                // Don't count pings of our local gateway
                if (gateway == null || !gateway.Equals(hop.ip))
                {
                    this.counterGreen++;
                }
            } else if (curHop.time > MAX_PING_MS_GREEN && curHop.time <= MAX_PING_MS_YELLOW && bg != Color.Yellow) {
                curItem.SubItems[2].BackColor = Color.Yellow;
                this.counterYellow++;
            }
            else if (curHop.time > MAX_PING_MS_YELLOW || curHop.time == -1 && bg != Color.Red)
            {
                curItem.SubItems[2].BackColor = Color.Red;
                this.counterRed++;
            }
        }

        // hides the horizontal scroll bar on the traceroute table (routeListView)
        private void hideHScrollBar()
        {
            if (routeListView.Items.Count > 12)
            {
                routeListView.Columns[2].Width = 77 - 17;   // 96 is width of the last column, 25 is the width of the scrollbar.
            }
            else
                routeListView.Columns[2].Width = -2;
        }

        // initializes the plot of ping vs time.
        private void initChart()
        {
            int dx = nDataPts / nGridPts;   // grid spacing
            chartPings.Visible = true;

            // get reference to plot axes
            axisX = chartPings.ChartAreas[0].AxisX;
            axisY = chartPings.ChartAreas[0].AxisY;

            if (AXIS_Y_MAXIMUM>0) {
                axisY.Maximum = AXIS_Y_MAXIMUM;
                }

            // establish the grid and labels
            axisX.LabelStyle.Interval = dx * traceInterval;
            axisX.MajorGrid.Interval = dx * traceInterval;
            axisX.MajorTickMark.Interval = dx * traceInterval;
        }

        // sets up the proper labels and tick marks
        private void updateYAxis()
        {
            axisY.LabelStyle.Interval = Math.Floor((axisY.Maximum - axisY.Minimum) / 6);
            axisY.MajorGrid.Interval = Math.Floor((axisY.Maximum - axisY.Minimum) / 6);
            axisY.MajorTickMark.Interval = Math.Floor((axisY.Maximum - axisY.Minimum) / 6);
        }

        // updates the plot of ping vs time after it has been created
        private void updateChart(long ping)
        {
            // get reference to axes and series - these will come in handy
            axisX = chartPings.ChartAreas[0].AxisX;
            axisY = chartPings.ChartAreas[0].AxisY;
            pingSeries = chartPings.Series[0];

            updateYAxis();

            axisX.Minimum = DateTime.Now.Subtract(new TimeSpan(0, 0, (int)(traceInterval * nDataPts))).ToOADate();
            axisX.Maximum = DateTime.Now.ToOADate();

            // add current data point
            dates.Add(DateTime.Now);
            pings.Add(ping);

            // plot red for timeouts
            if (ping == -1)
            {

                // first ping is a timeout
                if (pings.Count == 1)
                    pingSeries.Points.AddXY(dates.Last(), -1);
                else
                    pingSeries.Points.AddXY(dates.Last(), pingSeries.Points.Last().YValues[0]);

                // color data points red for timeout
                DataPoint last = pingSeries.Points.Last(); // most recent data point
                last.MarkerStyle = MarkerStyle.Square;
                last.MarkerColor = Color.Red;
            }
            else
            {
                pingSeries.Points.AddXY(dates.Last(), pings.Last());
                DataPoint last = pingSeries.Points.Last(); // most recent data point

                // color code the data points
                if (ping <= 200 && ping != -1)
                    last.Color = Color.Lime;
                if (ping > 200 && ping <= 500)
                    last.Color = Color.Yellow;
                else if (ping > 500)
                    last.Color = Color.Red;
            }

            // show at most nDataPts
            while (pingSeries.Points.Count > nDataPts)
                pingSeries.Points.RemoveAt(0);

            if (pingSeries.Points.Count == nDataPts)
            {
                axisX.Minimum = pingSeries.Points[0].XValue;
                axisX.Maximum = pingSeries.Points.Last().XValue;
            }
        }

        // close the program
        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Close();
        }

        // export the data
        private void exportDataFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // no data present
            if (pings.Count == 0 || dates.Count == 0)
            {
                MessageBox.Show("No data available to export!", "Error!");
                return;
            }

            string fileName = "";
            saveFileDialog1.Filter = "CSV Files (*.csv)|*.csv|Text Files (*.txt)|*.txt|RRD Files (*.rrd)|*.rrd";

            if (saveFileDialog1.ShowDialog() != DialogResult.Cancel)
            {
                fileName = saveFileDialog1.FileName;
                if (fileName.EndsWith(".rrd"))
                {
                    RRD.save(fileName, traceInterval, dates, pings, hostOrIp, this.routeToDestination, interfaceTooltip(networkInterface), this.textBoxUserNotes.Text);
                } else {
                    try
                    {
                        saveCSV(fileName);
                    }
                    catch(IOException ioErr)
                    {
                        MessageBox.Show(ioErr.Message, "Error");
                    }
                }
            }
        }

        // saves the ping vs time series data to a csv file
        private void saveCSV(string filename)
        {
            TextWriter tw = new StreamWriter(filename);
            tw.WriteLine(hostOrIp);
            if (networkInterface != null)
            {
                tw.WriteLine(interfaceTooltip(networkInterface));
            }
            tw.WriteLine(this.textBoxUserNotes);

            tw.WriteLine("yyyy, MM, dd, HH, mm, ss, ping");
            for (int i = 0; i < pings.Count; i++)
            {
                string line = dates[i].ToString("yyyy, MM, dd, HH, mm, ss") + "," + pings[i].ToString();
                tw.WriteLine(line);
            }
            tw.Close();
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AboutBox about = new AboutBox();
            about.Show();
        }

        private void nTraceLbl_MouseHover(object sender, EventArgs e)
        {
            toolTipHover.Show("0 is unlimited", nTraceLbl);
        }

        /// <summary>
        /// Saves the chart as either a PNG, JPEG or GIF file as whatever
        /// the user specifies the name to be
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exportChartMenuItem_Click(object sender, EventArgs e)
        {
            // no data present
            if (pings.Count == 0 || dates.Count == 0)
            {
                MessageBox.Show("No data availible to export!", "Error!");
                return;
            }

            string fileName = "";
            saveFileDialog1.Filter = "PNG Files (*.png)|*.png|JPG Files (*.jpeg)|*.jpeg|GIF Files (*.gif)|*.gif";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                fileName = saveFileDialog1.FileName;

                    // default formatting to PNG
                    ChartImageFormat fmt = ChartImageFormat.Png;
                    if (fileName.Contains(".png"))
                    {
                        fmt = ChartImageFormat.Png;
                    }
                    else if (fileName.Contains(".jpeg"))
                    {
                        fmt = ChartImageFormat.Jpeg;
                    }
                    else if (fileName.Contains(".gif"))
                    {
                        fmt = ChartImageFormat.Gif;
                    }
                    chartPings.SaveImage(fileName, fmt);
            }
        }
    }
}
