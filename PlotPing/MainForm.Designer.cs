namespace PlotPing
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lbl_addrToTrace = new System.Windows.Forms.Label();
            this.txt_addr = new System.Windows.Forms.TextBox();
            this.listBox_addrs = new System.Windows.Forms.ListBox();
            this.btn_trace = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.bgwrkr_pinger = new System.ComponentModel.BackgroundWorker();
            this.dgv_trace = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_trace)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(717, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // lbl_addrToTrace
            // 
            this.lbl_addrToTrace.AutoSize = true;
            this.lbl_addrToTrace.Location = new System.Drawing.Point(13, 28);
            this.lbl_addrToTrace.Name = "lbl_addrToTrace";
            this.lbl_addrToTrace.Size = new System.Drawing.Size(91, 13);
            this.lbl_addrToTrace.TabIndex = 1;
            this.lbl_addrToTrace.Text = "Address to Trace:";
            // 
            // txt_addr
            // 
            this.txt_addr.Location = new System.Drawing.Point(12, 44);
            this.txt_addr.Name = "txt_addr";
            this.txt_addr.Size = new System.Drawing.Size(147, 20);
            this.txt_addr.TabIndex = 2;
            this.txt_addr.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_addr_KeyPress);
            // 
            // listBox_addrs
            // 
            this.listBox_addrs.FormattingEnabled = true;
            this.listBox_addrs.Location = new System.Drawing.Point(12, 71);
            this.listBox_addrs.Name = "listBox_addrs";
            this.listBox_addrs.Size = new System.Drawing.Size(147, 290);
            this.listBox_addrs.TabIndex = 3;
            // 
            // btn_trace
            // 
            this.btn_trace.Location = new System.Drawing.Point(12, 367);
            this.btn_trace.Name = "btn_trace";
            this.btn_trace.Size = new System.Drawing.Size(147, 23);
            this.btn_trace.TabIndex = 4;
            this.btn_trace.Text = "Trace";
            this.btn_trace.UseVisualStyleBackColor = true;
            this.btn_trace.Click += new System.EventHandler(this.btn_trace_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 397);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(147, 10);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 5;
            this.progressBar1.Visible = false;
            // 
            // bgwrkr_pinger
            // 
            this.bgwrkr_pinger.WorkerReportsProgress = true;
            this.bgwrkr_pinger.WorkerSupportsCancellation = true;
            this.bgwrkr_pinger.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwrkr_pinger_DoWork);
            this.bgwrkr_pinger.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwrkr_pinger_RunWorkerCompleted);
            // 
            // dgv_trace
            // 
            this.dgv_trace.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_trace.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dgv_trace.Location = new System.Drawing.Point(187, 44);
            this.dgv_trace.Name = "dgv_trace";
            this.dgv_trace.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgv_trace.Size = new System.Drawing.Size(518, 150);
            this.dgv_trace.TabIndex = 6;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.HeaderText = "Column2";
            this.Column2.Name = "Column2";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 411);
            this.Controls.Add(this.dgv_trace);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btn_trace);
            this.Controls.Add(this.listBox_addrs);
            this.Controls.Add(this.txt_addr);
            this.Controls.Add(this.lbl_addrToTrace);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "PlotPing";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_trace)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Label lbl_addrToTrace;
        private System.Windows.Forms.TextBox txt_addr;
        private System.Windows.Forms.ListBox listBox_addrs;
        private System.Windows.Forms.Button btn_trace;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.ComponentModel.BackgroundWorker bgwrkr_pinger;
        private System.Windows.Forms.DataGridView dgv_trace;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;

    }
}

