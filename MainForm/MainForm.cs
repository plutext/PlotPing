﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TraceRoute;
using System.Threading;

namespace MainForm
{
    public partial class MainForm : Form
    {
        private string hostOrIp;
        List<List<Hop>> allRoutes = new List<List<Hop>>();

        public MainForm()
        {
            InitializeComponent();
            traceIntUpDown.Maximum = Decimal.MaxValue;
            nTraceUpDown.Maximum = Decimal.MaxValue;
        }

        private void traceBtn_Click(object sender, EventArgs e)
        {
            hostOrIp = addrComboBox.Text;
            if (!addrComboBox.Items.Contains(hostOrIp))
                addrComboBox.Items.Add(hostOrIp);
            
            // start traceroute if not already running, otherwise kill it.
            if (!tracertBackgroundWorker.IsBusy)
            {
                hostOrIp = addrComboBox.Text;
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
            int n = (int) nTraceUpDown.Value;
            if (n == 0) n = Int32.MaxValue; // 0 means loop forever

            // get sleep time and convert sec to ms
            int tsleep = (int)(1000*traceIntUpDown.Value);

            for (int i = 0; i < n; i++)
            {
                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                    break;
                }
                List<Hop> hops = RouteTracer.traceRoute(hostOrIp);
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
            allRoutes.Add(hops);
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
                    if (hop.time < 100)
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
                int j = 0;
                foreach(Hop hop in hops)
                {
                    if(routeListView.Items[j].SubItems[1].Text != hop.ip.ToString())
                        routeListView.Items[j].SubItems[1].Text = hop.ip.ToString();
                    if(routeListView.Items[j].SubItems[3].Text != hop.time.ToString())
                        routeListView.Items[j].SubItems[3].Text = hop.time.ToString();

                    // color code pings 
                    Color bg = routeListView.Items[j].SubItems[3].BackColor;
                    if (hop.time < 100 && bg != Color.Lime)
                        routeListView.Items[j].SubItems[3].BackColor = Color.Lime;
                    else if (hop.time > 100 && hop.time < 200 && bg != Color.Yellow)
                        routeListView.Items[j].SubItems[3].BackColor = Color.Yellow;
                    else if (hop.time > 200 && bg != Color.Red)
                        routeListView.Items[j].SubItems[3].BackColor = Color.Red;

                    j++;
                }
            }
        }

        private void tracertBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            traceBtn.Text = "Trace";
        }
    }
}
