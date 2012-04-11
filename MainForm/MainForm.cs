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
using System.Windows.Forms.DataVisualization.Charting;

namespace MainForm
{
    public partial class MainForm : Form
    {
        private string hostOrIp;
        private BindingList<long> pings = new BindingList<long>();
        private Axis axisX;
        private Axis axisY;
        private Series pingSeries;
        private List<DateTime> dates = new List<DateTime>();
        private int nTraces;
        private double traceInterval;

        public MainForm()
        {
            InitializeComponent();
            traceIntUpDown.Maximum = Decimal.MaxValue;
            nTraceUpDown.Maximum = Decimal.MaxValue;
            chartPings.Visible = false;
        }

        private void traceBtn_Click(object sender, EventArgs e)
        {
            hostOrIp = addrComboBox.Text;
            if (!addrComboBox.Items.Contains(hostOrIp))
                addrComboBox.Items.Add(hostOrIp);
            
            // start traceroute if not already running, otherwise kill it.
            if (!tracertBackgroundWorker.IsBusy)
            {
                // save user input here
                hostOrIp = addrComboBox.Text;
                nTraces = (int)nTraceUpDown.Value;
                traceInterval = (double)traceIntUpDown.Value;

                // clear the plot if it has data
                chartPings.Series[0].Points.Clear();
                initChart();

                // start the traceroute in a separate thread
                tracertBackgroundWorker.RunWorkerAsync();
                traceBtn.Text = "Stop";
            }
            else if (tracertBackgroundWorker.IsBusy)
            {
                tracertBackgroundWorker.CancelAsync();
                traceBtn.Text = "Trace";
            }
        }

        /// <summary>
        /// Runs a traceroute in a separate thread
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tracertBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            if (nTraces == 0) nTraces = Int32.MaxValue; // 0 means loop forever

            // get sleep time and convert sec to ms
            int tsleep = (int)(1000*traceIntUpDown.Value);

            for (int i = 0; i < nTraces; i++)
            {
                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                    break;
                }
                List<Hop> hops = RouteTracer.traceRoute(hostOrIp, timeout: 1000);
                tracertBackgroundWorker.ReportProgress(i, hops);
                Thread.Sleep(tsleep);
            }
        }

        private void tracertBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // update the table
            int i = e.ProgressPercentage;
            List<Hop> hops = (List<Hop>)e.UserState;
            drawTable(hops, i);
            totPingLbl.Text = hops.Last().time.ToString() + " ms";
            updateChart(hops.Last().time);
        }

        // initializes the plot of ping vs time.
        private void initChart()
        {
            chartPings.Visible = true;
            int nDataPts = 200;
            int nGridPts = 8;
            int dx = nDataPts / nGridPts;
            axisX = chartPings.ChartAreas[0].AxisX;
            axisY = chartPings.ChartAreas[0].AxisY;
            axisX.LabelStyle.Interval = dx * traceInterval;
            axisX.MajorGrid.Interval = dx * traceInterval;
            axisX.MajorTickMark.Interval = dx * traceInterval;
        }

        private void updateChart(long ping)
        {
            int nDataPts = 200;
            int nGridPts = 8;
            int dx = nDataPts / nGridPts;

            // get reference to axes and series - these will come in handy
            axisX = chartPings.ChartAreas[0].AxisX;
            axisY = chartPings.ChartAreas[0].AxisY;
            pingSeries = chartPings.Series[0];
            Series timeOutSeries = chartPings.Series[1];

            axisX.Minimum = DateTime.Now.Subtract(new TimeSpan(0, 0, (int)(traceInterval * nDataPts))).ToOADate();
            axisX.Maximum = DateTime.Now.ToOADate();

            // add current data point
            dates.Add(DateTime.Now);
            pings.Add(ping);

            // plot red for timeouts
            if (ping == -1)
            {
                pingSeries.Points.AddXY(dates.Last(), pingSeries.Points.Last().YValues[0]);
                timeOutSeries.Points.AddXY(dates.Last(), pingSeries.Points.Last().YValues[0]);
            }
            else
                pingSeries.Points.AddXY(dates.Last(), pings.Last());

            while (pingSeries.Points.Count > nDataPts)
                pingSeries.Points.RemoveAt(0);

            if (pingSeries.Points.Count == nDataPts)
            {
                axisX.Minimum = pingSeries.Points[0].XValue;
                axisX.Maximum = pingSeries.Points.Last().XValue;
            }
        }

        private void drawTable(List<Hop> hops, int i = 1)
        {   
            // first iteration draws a new table
            if (i == 0)
            {
                routeListView.Items.Clear();
                foreach (Hop hop in hops)
                {
                    ListViewItem item = new ListViewItem();
                    item.UseItemStyleForSubItems = false;
                    item.Text = hop.hopNum.ToString();
                    item.SubItems.Add(hop.ip.ToString());
                    item.SubItems.Add("-----");
                    item.SubItems.Add(hop.time.ToString());
                    
                    // color code pings 
                    if (hop.time < 100 && hop.time >= 0)
                        item.SubItems[3].BackColor = Color.Lime;
                    else if (hop.time > 100 && hop.time < 200)
                        item.SubItems[3].BackColor = Color.Yellow;
                    else
                        item.SubItems[3].BackColor = Color.Red;
                    
                    routeListView.Items.Add(item);
                }
            }
            else
            {
                // FINDME: need to re-do this loop to account for the case where a new hop is added
                for (int j = 0; j < hops.Count; j++)
                {
                    // if prev ip != cur ip
                    if (routeListView.Items[j].SubItems[1].Text != hops[j].ip.ToString())
                        routeListView.Items[j].SubItems[1].Text = hops[j].ip.ToString();

                    // if prev time != cur time
                    if (routeListView.Items[j].SubItems[3].Text != hops[j].time.ToString())
                        routeListView.Items[j].SubItems[3].Text = hops[j].time.ToString();

                    // color code pings 
                    Color bg = routeListView.Items[j].SubItems[3].BackColor;
                    if (hops[j].time < 100 && hops[j].time != -1 && bg != Color.Lime)
                        routeListView.Items[j].SubItems[3].BackColor = Color.Lime;
                    else if (hops[j].time > 100 && hops[j].time < 200 && bg != Color.Yellow)
                        routeListView.Items[j].SubItems[3].BackColor = Color.Yellow;
                    else if (hops[j].time > 200 || hops[j].time == -1 && bg != Color.Red)
                        routeListView.Items[j].SubItems[3].BackColor = Color.Red;
                }
            }

            // removes horizontal scroll bar
            if (hops.Count > 12)
                routeListView.Columns[3].Width = 96 - 25;
            else
                routeListView.Columns[3].Width = -2;
        }

        private void tracertBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            traceBtn.Text = "Trace";
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
