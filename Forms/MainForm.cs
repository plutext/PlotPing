using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace PlotPing
{
    public partial class MainForm : Form
    {
        // global variables
        private string curAddr = string.Empty;
        private long avgLat = 0, minLat = 0, maxLat = 0;
        private int timeout = 1000;
        private int oldHeight, oldWidth;
        private List<long> pings = new List<long>();
        private List<DateTime> times = new List<DateTime>();
        private DateTime startTime;        

        public MainForm()
        {
            InitializeComponent();
            oldHeight = this.Height;
            oldWidth = this.Width;
            slbl_avgMinMax.Text = String.Format("{0,4} (avg) {1,4} (min) {2,4} (max)", "----", "----", "----");

            // load addresses into listbox
            foreach (string addr in Properties.Settings.Default.addrs)
                lb_Addrs.Items.Add(addr);
        }

        #region GUI control events

        // about box!
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox about = new AboutBox();
            about.Show();
        }

        private void btn_trace_Click(object sender, EventArgs e)
        {
            if (!bgwrkr_runTrace.IsBusy)
            {
                // add addr to list
                if (!lb_Addrs.Items.Contains(txt_Addr.Text))
                    lb_Addrs.Items.Insert(0, txt_Addr.Text);

                // clear old data IF NOT resuming
                if (txt_Addr.Text != curAddr)
                {
                    // if user has stored a lot of data, ask before we clear it
                    if (pings.Count > 200)
                    {
                        if (MessageBox.Show("You have logged a lot of data for this address.  Do you want to delete it and start a new trace?", "Confirm delete", MessageBoxButtons.YesNo) == DialogResult.No)
                            return;
                    }
                    dgv_routeInfo.Rows.Clear();
                    pings.Clear();
                    times.Clear();
                    avgLat = 0;
                    minLat = 0;
                    maxLat = 0;
                    slbl_traceCount.Text = "Trace Count: 0";
                    slbl_elapsed.Text = String.Format("Elapsed time: {0,3}h {1,3}m {2,3}s", 0, 0, 0);
                    curAddr = txt_Addr.Text;
                }

                // update UI
                btn_trace.Text = "Tracing...";
                slbl_Status.Text = "Tracing...";
                lbl_curTargAddr.Text = txt_Addr.Text;
                slbl_traceCount.Visible = true;
                slbl_roundTrip.Visible = true;
                slbl_avgMinMax.Visible = true;
                slbl_elapsed.Visible = true;
                lbl_curTargAddr.Visible = true;
                btn_trace.Enabled = false;
                txt_Addr.ReadOnly = true;

                // configure progress bar
                if (ud_nTraces.Value == 0)
                    progressBar.Style = ProgressBarStyle.Marquee;
                else
                {
                    progressBar.Style = ProgressBarStyle.Blocks;
                    progressBar.Minimum = 0;
                    progressBar.Maximum = (int)ud_nTraces.Value;
                    progressBar.Value = progressBar.Minimum;
                }
                progressBar.Visible = true;

                // start work
                bgwrkr_runTrace.RunWorkerAsync();
                startTime = DateTime.Now;
                timer_elapsed.Start();
            }
            else
            {
                bgwrkr_runTrace.CancelAsync();
                btn_trace.Text = "Stopping...";
                slbl_Status.Text = "Stopping...";
                btn_trace.Enabled = false;
            }
        }

        // pressing enter should add the addr to the list
        private void txt_Addr_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (!lb_Addrs.Items.Contains(txt_Addr.Text))
                {
                    lb_Addrs.Items.Insert(0, txt_Addr.Text);
                    Properties.Settings.Default.addrs.Insert(0, txt_Addr.Text);
                }
                e.Handled = true;
                if (!txt_Addr.ReadOnly)
                    btn_trace.PerformClick();
            }
        }

        // selecting an address from the list should update the text box
        private void lb_Addrs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!txt_Addr.ReadOnly && lb_Addrs.SelectedItem != null)
                txt_Addr.Text = lb_Addrs.SelectedItem.ToString();

            if (txt_Addr.Text != curAddr)
                btn_trace.Text = "Start";
            else if (txt_Addr.Text == curAddr)
                btn_trace.Text = "Resume";
        }

        // custom resizing control
        private void frmMain_Resize(object sender, EventArgs e)
        {
            gb_sampling.Location = new Point(gb_sampling.Location.X, gb_sampling.Location.Y + (this.Height - oldHeight));
            btn_trace.Location = new Point(btn_trace.Location.X, btn_trace.Location.Y + (this.Height - oldHeight));
            panel_legend.Location = new Point(panel_legend.Location.X + (this.Width - oldWidth), panel_legend.Location.Y);
            oldHeight = this.Height;
            oldWidth = this.Width;
        }

        private void timer_elapsed_Tick(object sender, EventArgs e)
        {
            TimeSpan timeElapsed = DateTime.Now.Subtract(startTime);
            slbl_elapsed.Text = String.Format("Elapsed time: {0,3}h {1,3}m {2,3}s", (int)timeElapsed.TotalHours, timeElapsed.Minutes, timeElapsed.Seconds);
        }

        private void mitem_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Save();
        }

        // save data to a txt or csv file
        private void saveDataToFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // no data present
            if (pings.Count == 0 || times.Count == 0)
            {
                MessageBox.Show("No data availible to export!", "Error!");
                return;
            }

            string fileName = "";
            saveFileDialog1.Filter = "Text Files (*.txt)|*.txt|CSV Files (*.csv)|*.csv";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                fileName = saveFileDialog1.FileName;
                string ext;
                if (fileName.Contains(".csv"))
                    ext = ".csv";
                else
                    ext = ".txt";
                try
                {
                    TxtDataHandler.saveData(fileName, ext, dgv_routeInfo, pings, times);
                }
                catch (IOException ioErr)
                {
                    MessageBox.Show(ioErr.Message, "Error");
                }
            }
        }

        // delete an address from the list box 
        private void lb_Addrs_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                string selectedItem = lb_Addrs.SelectedItem.ToString();
                lb_Addrs.Items.Remove(selectedItem);
                Properties.Settings.Default.addrs.Remove(selectedItem);
            }
        }

        #endregion

        #region backgroundWorker events (runs the tracert in a separate thread)

        // run the tracerts in a background thread
        private void bgwrkr_runTrace_DoWork(object sender, DoWorkEventArgs e)
        {
            string ip = txt_Addr.Text;
            int nTraces = (int)ud_nTraces.Value;
            int interval = (int)ud_interval.Value;
            List<Hop> finalHops = null;

            // 0 traces means loop infinitely 
            if (nTraces == 0)
                nTraces = int.MaxValue;

            Hop[] hops = null;
            for (int i = 0; i < nTraces; i++)
            {
                if (bgwrkr_runTrace.CancellationPending)
                    return;

                // run the tracerout, let user know if it fails
                try
                {
                    if (hops == null)
                        hops = TraceRoute.GetTraceRoute(ip, 30, 30, timeout, null);
                    else
                        hops = TraceRoute.GetTraceRoute(ip, finalHops.Count, 30, timeout, hops);
                }
                catch (Exception ex)
                {
                    // on first run, we couldn't connect, so stop.
                    if (i == 0)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    // FINDME otherwise we have a timeout/connectivity-loss situation
                }

                // condense hop array
                finalHops = new List<Hop>();
                foreach (Hop hop in hops)
                {
                    finalHops.Add(hop);
                    if (hop.destReached)
                        break;
                }

                Thread.Sleep(1000 * interval);
                bgwrkr_runTrace.ReportProgress(i + 1, finalHops);
                if (bgwrkr_runTrace.CancellationPending)
                    return;
            }
        }

        // one tracert complete
        private void bgwrkr_runTrace_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            List<Hop> hops = (List<Hop>)e.UserState;

            // save final hop since this represents the entire trip
            pings.Add(hops[hops.Count - 1].latency);
            times.Add(DateTime.Now);

            // update gui and progress bar
            updateDataGrid(hops);
            // update trace button
            if (e.ProgressPercentage == 1)
            {
                btn_trace.Text = "Stop Trace";
                btn_trace.Enabled = true;
                dgv_routeInfo.ClearSelection();
                minLat = pings[0];
            }
            slbl_traceCount.Text = String.Format("Trace count: {0}", pings.Count);
            calcAvgMinMax();
            slbl_avgMinMax.Text = String.Format("{0,4} (avg) {1,4} (min) {2,4} (max)", avgLat, minLat, maxLat);
            lbl_curSampInt.Text = String.Format("{0} - {1}", times[0], times[times.Count - 1]);
            lbl_curSampInt.Visible = true;

            if (progressBar.Style != ProgressBarStyle.Marquee)
                progressBar.Value = e.ProgressPercentage;
        }

        // finished ALL traces
        private void bgwrkr_runTrace_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // no data collected
            if (pings.Count == 0)
                btn_trace.Text = "Start";
            else
                btn_trace.Text = "Resume";

            slbl_Status.Text = "Ready";
            btn_trace.Enabled = true;
            progressBar.Visible = false;
            txt_Addr.ReadOnly = false;
            timer_elapsed.Stop();
        }

        #endregion

        #region helper functions
        // update the main trace grid
        private void updateDataGrid(List<Hop> hops)
        {
            for (int i = 0; i < hops.Count; i++)
            {
                Hop hop = hops[i];
                DataGridViewRow row;

                // create new row if it doesn't exist
                if (i >= dgv_routeInfo.Rows.Count)
                {
                    row = new DataGridViewRow();
                    dgv_routeInfo.Rows.Add(row);
                }

                row = dgv_routeInfo.Rows[i];

                // update values ONLY if they are new
                if (row.Cells[0].Value == null || (int)row.Cells[0].Value != hop.num)
                    row.Cells[0].Value = hop.num;
                if (row.Cells[1].Value == null || (string)row.Cells[1].Value != hop.ip)
                    row.Cells[1].Value = hop.ip;
                if (row.Cells[2].Value == null || (string)row.Cells[2].Value != hop.hostname)
                    row.Cells[2].Value = hop.hostname;
                if (row.Cells[3].Value == null || (long)row.Cells[3].Value != hop.latency)
                    row.Cells[3].Value = hop.latency;

                // color code values
                colorCodeLatency(hop.latency, row.Cells[3]);
            }
        }

        // set bg color of ping column; 0-200 = green, 201-500 = yellow, 501+ = red
        private void colorCodeLatency(long latency, DataGridViewCell cell)
        {
            if (latency >= 0 && latency <= 200)
                cell.Style.BackColor = Color.Lime;
            else if (latency > 200 && latency <= 500)
                cell.Style.BackColor = Color.Yellow;
            else
                cell.Style.BackColor = Color.Red;
        }

        // calculate average, minimum, and maximum round trip latencies
        private void calcAvgMinMax()
        {
            // FINDME: use LINQ in 4.0
            foreach (long ping in pings)
            {
                avgLat += ping;
                if (ping < minLat)
                    minLat = ping;
                if (ping > maxLat)
                    maxLat = ping;
            }
            avgLat /= pings.Count;
        }
        #endregion

        private void txt_Addr_Validating(object sender, CancelEventArgs e)
        {
            if (txt_Addr.Text != curAddr)
                btn_trace.Text = "Start";
        }

    }
}