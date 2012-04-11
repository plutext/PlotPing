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
        private List<DateTime> dates = new List<DateTime>();
        private BindingList<long> pings = new BindingList<long>();
        private string hostOrIp;
        private Axis axisX;
        private Axis axisY;
        private Series pingSeries;
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

                // start the traceroute in a separate thread
                traceBtn.Text = "Stop";
                tracertBackgroundWorker.RunWorkerAsync();
                progressBar1.Visible = true;
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
            int i = e.ProgressPercentage;
            List<Hop> hops = (List<Hop>)e.UserState;
            totPingLbl.Text = hops.Last().time.ToString() + " ms";

            // initialize or update table
            if (i == 0)
            {
                // first ping was a timeout
                if (hops.Last().time == -1)
                {
                    tracertBackgroundWorker.CancelAsync();
                    MessageBox.Show("Could not establish connection to address!");
                    //chartPings.Visible = false;
                    return;
                }
                initTable(hops);

                // clear the plot if it has data
                chartPings.Series[0].Points.Clear();
                initChart();
            }
            else
                drawTable(hops);

            // plot results so far
            updateChart(hops.Last().time);
        }

        private void tracertBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            traceBtn.Text = "Trace";
            progressBar1.Visible = false;
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
                item.SubItems.Add(hop.ip.ToString());
                item.SubItems.Add("-----");
                item.SubItems.Add(hop.time.ToString());

                // color code pings 
                if (hop.time <= 200 && hop.time >= 0)
                    item.SubItems[3].BackColor = Color.Lime;
                else if (hop.time > 200 && hop.time <= 500)
                    item.SubItems[3].BackColor = Color.Yellow;
                else
                    item.SubItems[3].BackColor = Color.Red;

                routeListView.Items.Add(item);
            }
            
            // removes horizontal scroll bar
            if (hops.Count > 12)
                routeListView.Columns[3].Width = 96 - 25;
            else
                routeListView.Columns[3].Width = -2;
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

                    // if prev ip != cur ip
                    if (curItem.SubItems[1].Text != curHop.ip.ToString())
                        curItem.SubItems[1].Text = curHop.ip.ToString();

                    // if prev time != cur time
                    if (curItem.SubItems[3].Text != curHop.time.ToString())
                        curItem.SubItems[3].Text = curHop.time.ToString();

                    // color code pings 
                    Color bg = curItem.SubItems[3].BackColor;
                    if (curHop.time <= 200 && curHop.time != -1 && bg != Color.Lime)
                        curItem.SubItems[3].BackColor = Color.Lime;
                    else if (curHop.time > 200 && curHop.time <= 500 && bg != Color.Yellow)
                        curItem.SubItems[3].BackColor = Color.Yellow;
                    else if (curHop.time > 500 || curHop.time == -1 && bg != Color.Red)
                        curItem.SubItems[3].BackColor = Color.Red;
                }
            }

            // removes horizontal scroll bar
            if (hops.Count > 12)
                routeListView.Columns[3].Width = 96 - 25;   // 96 is width of the last column, 25 is the width of the scrollbar.
            else
                routeListView.Columns[3].Width = -2;
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
                {
                    pingSeries.Points.AddXY(dates.Last(), -1);
                }
                else
                {
                    pingSeries.Points.AddXY(dates.Last(), pingSeries.Points.Last().YValues[0]);
                }

                // color data points red
                DataPoint last = pingSeries.Points.Last();
                last.MarkerStyle = MarkerStyle.Square;
                last.MarkerColor = Color.Red;
            }
            else
            {
                pingSeries.Points.AddXY(dates.Last(), pings.Last());
                //pingSeries.Color = Color.Lime;
            }

            while (pingSeries.Points.Count > nDataPts)
            {
                pingSeries.Points.RemoveAt(0);
                //timeOutSeries.Points.RemoveAt(0);
            }

            if (pingSeries.Points.Count == nDataPts)
            {
                axisX.Minimum = pingSeries.Points[0].XValue;
                axisX.Maximum = pingSeries.Points.Last().XValue;
            }
        }
    }
}
