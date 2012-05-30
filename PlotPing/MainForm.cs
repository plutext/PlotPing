using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PlotPing
{
    public partial class MainForm : Form
    {
        public DataTable dt_trace = new DataTable();
        public BindingSource bsource = new BindingSource();
        public MainForm()
        {
            InitializeComponent();
            bsource.DataSource = dt_trace;
            dgv_trace.DataSource = bsource;            
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        // add addresses to the address box
        private void txt_addr_KeyPress(object sender, KeyPressEventArgs e)
        {
            // check for enter key press
            if (e.KeyChar == (char)Keys.Enter)
            {
                listBox_addrs.Items.Add(txt_addr.Text);
                txt_addr.Clear();
                dt_trace.Columns.Add(txt_addr.Text.ToString());
                e.Handled = true;
            }
        }

        // start or stop the trace
        private void btn_trace_Click(object sender, EventArgs e)
        {
            if (!bgwrkr_pinger.IsBusy)
            {
                bgwrkr_pinger.RunWorkerAsync();
                btn_trace.Text = "Stop";
                progressBar1.Visible = true;
            }
            else
            {
                bgwrkr_pinger.CancelAsync();
                btn_trace.Text = "Stopping...";
                btn_trace.Enabled = false;
            }
        }

        // run the pings in the background
        private void bgwrkr_pinger_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            while (!worker.CancellationPending)
                System.Threading.Thread.Sleep(5000);
        }

        // the ping finished in the background thread
        private void bgwrkr_pinger_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btn_trace.Text = "Trace";
            btn_trace.Enabled = true;
            progressBar1.Visible = false;
        }
    }
}
