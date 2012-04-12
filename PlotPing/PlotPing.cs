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
using System.Windows.Forms.DataVisualization.Charting;

namespace PlotPing
{
    public partial class PlotPing : Form
    {
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

        public PlotPing()
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
                tStart = DateTime.Now;
                tEnd = DateTime.Now;

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
            }
        }

        // Runs a traceroute in a separate thread
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

        // updates the program for each completed ping (a full traceroute).
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
                    MessageBox.Show("Could not establish connection to address!  The address might be invaild or it may be down. There may also be a problem with your connection.", "PlotPing: ERROR");
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
                if (hop.time <= 200 && hop.time >= 0)
                    item.SubItems[2].BackColor = Color.Lime;
                else if (hop.time > 200 && hop.time <= 500)
                    item.SubItems[2].BackColor = Color.Yellow;
                else
                    item.SubItems[2].BackColor = Color.Red;

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
                    if (curHop.time <= 200 && curHop.time != -1 && bg != Color.Lime)
                        curItem.SubItems[2].BackColor = Color.Lime;
                    else if (curHop.time > 200 && curHop.time <= 500 && bg != Color.Yellow)
                        curItem.SubItems[2].BackColor = Color.Yellow;
                    else if (curHop.time > 500 || curHop.time == -1 && bg != Color.Red)
                        curItem.SubItems[2].BackColor = Color.Red;
                }
            }

            hideHScrollBar();
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

            // establish the grid and labels
            axisX.LabelStyle.Interval = dx * traceInterval;
            axisX.MajorGrid.Interval = dx * traceInterval;
            axisX.MajorTickMark.Interval = dx * traceInterval;

            //updateYAxis();
        }

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
    }
}
