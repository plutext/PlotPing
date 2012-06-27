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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.slbl_Status = new System.Windows.Forms.ToolStripStatusLabel();
            this.progressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.slbl_traceCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.slbl_roundTrip = new System.Windows.Forms.ToolStripStatusLabel();
            this.slbl_avgMinMax = new System.Windows.Forms.ToolStripStatusLabel();
            this.slbl_elapsed = new System.Windows.Forms.ToolStripStatusLabel();
            this.bgwrkr_runTrace = new System.ComponentModel.BackgroundWorker();
            this.gb_sampling = new System.Windows.Forms.GroupBox();
            this.lbl_nTraces = new System.Windows.Forms.Label();
            this.lbl_interval = new System.Windows.Forms.Label();
            this.ud_interval = new System.Windows.Forms.NumericUpDown();
            this.ud_nTraces = new System.Windows.Forms.NumericUpDown();
            this.lbl_addrToTrace = new System.Windows.Forms.Label();
            this.btn_trace = new System.Windows.Forms.Button();
            this.lb_Addrs = new System.Windows.Forms.ListBox();
            this.txt_Addr = new System.Windows.Forms.TextBox();
            this.timer_elapsed = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mitem_file = new System.Windows.Forms.ToolStripMenuItem();
            this.saveDataToFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mitem_exit = new System.Windows.Forms.ToolStripMenuItem();
            this.mitem_help = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.lbl_yellowPing = new System.Windows.Forms.Label();
            this.lbl_greenPing = new System.Windows.Forms.Label();
            this.lbl_redPing = new System.Windows.Forms.Label();
            this.panel_legend = new System.Windows.Forms.Panel();
            this.lbl_targetAddr = new System.Windows.Forms.Label();
            this.lbl_sampInterval = new System.Windows.Forms.Label();
            this.lbl_curTargAddr = new System.Windows.Forms.Label();
            this.lbl_curSampInt = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgv_routeInfo = new System.Windows.Forms.DataGridView();
            this.hopNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hostname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.latency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.statusStrip.SuspendLayout();
            this.gb_sampling.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ud_interval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ud_nTraces)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.panel_legend.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_routeInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.slbl_Status,
            this.progressBar,
            this.slbl_traceCount,
            this.slbl_roundTrip,
            this.slbl_avgMinMax,
            this.slbl_elapsed});
            this.statusStrip.Location = new System.Drawing.Point(0, 396);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(748, 22);
            this.statusStrip.TabIndex = 4;
            this.statusStrip.Text = "statusStrip1";
            // 
            // slbl_Status
            // 
            this.slbl_Status.AutoSize = false;
            this.slbl_Status.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.slbl_Status.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.slbl_Status.Name = "slbl_Status";
            this.slbl_Status.Size = new System.Drawing.Size(62, 17);
            this.slbl_Status.Text = "Ready";
            this.slbl_Status.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // progressBar
            // 
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(100, 16);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar.Visible = false;
            // 
            // slbl_traceCount
            // 
            this.slbl_traceCount.AutoSize = false;
            this.slbl_traceCount.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.slbl_traceCount.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.slbl_traceCount.Name = "slbl_traceCount";
            this.slbl_traceCount.Size = new System.Drawing.Size(102, 17);
            this.slbl_traceCount.Text = "Trace Count:";
            this.slbl_traceCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.slbl_traceCount.Visible = false;
            // 
            // slbl_roundTrip
            // 
            this.slbl_roundTrip.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.slbl_roundTrip.Name = "slbl_roundTrip";
            this.slbl_roundTrip.Size = new System.Drawing.Size(149, 17);
            this.slbl_roundTrip.Text = "Round Trip Latency (ms):";
            this.slbl_roundTrip.Visible = false;
            // 
            // slbl_avgMinMax
            // 
            this.slbl_avgMinMax.AutoSize = false;
            this.slbl_avgMinMax.Name = "slbl_avgMinMax";
            this.slbl_avgMinMax.Size = new System.Drawing.Size(170, 17);
            this.slbl_avgMinMax.Text = "9999 (avg) 9999 (min) 9999 (max)";
            this.slbl_avgMinMax.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.slbl_avgMinMax.Visible = false;
            // 
            // slbl_elapsed
            // 
            this.slbl_elapsed.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.slbl_elapsed.Name = "slbl_elapsed";
            this.slbl_elapsed.Size = new System.Drawing.Size(671, 17);
            this.slbl_elapsed.Spring = true;
            this.slbl_elapsed.Text = "Elapsed time: ---";
            this.slbl_elapsed.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.slbl_elapsed.Visible = false;
            // 
            // bgwrkr_runTrace
            // 
            this.bgwrkr_runTrace.WorkerReportsProgress = true;
            this.bgwrkr_runTrace.WorkerSupportsCancellation = true;
            this.bgwrkr_runTrace.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwrkr_runTrace_DoWork);
            this.bgwrkr_runTrace.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwrkr_runTrace_RunWorkerCompleted);
            this.bgwrkr_runTrace.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgwrkr_runTrace_ProgressChanged);
            // 
            // gb_sampling
            // 
            this.gb_sampling.Controls.Add(this.lbl_nTraces);
            this.gb_sampling.Controls.Add(this.lbl_interval);
            this.gb_sampling.Controls.Add(this.ud_interval);
            this.gb_sampling.Controls.Add(this.ud_nTraces);
            this.gb_sampling.Location = new System.Drawing.Point(12, 285);
            this.gb_sampling.Name = "gb_sampling";
            this.gb_sampling.Size = new System.Drawing.Size(167, 72);
            this.gb_sampling.TabIndex = 18;
            this.gb_sampling.TabStop = false;
            this.gb_sampling.Text = "Sampling";
            // 
            // lbl_nTraces
            // 
            this.lbl_nTraces.AutoSize = true;
            this.lbl_nTraces.Location = new System.Drawing.Point(6, 47);
            this.lbl_nTraces.Name = "lbl_nTraces";
            this.lbl_nTraces.Size = new System.Drawing.Size(95, 13);
            this.lbl_nTraces.TabIndex = 9;
            this.lbl_nTraces.Text = "Number of Traces:";
            this.toolTip1.SetToolTip(this.lbl_nTraces, "Number of times to trace the supplied address - 0 is unlimited, anything higher s" +
                    "tops at that trace count.");
            // 
            // lbl_interval
            // 
            this.lbl_interval.AutoSize = true;
            this.lbl_interval.Location = new System.Drawing.Point(6, 21);
            this.lbl_interval.Name = "lbl_interval";
            this.lbl_interval.Size = new System.Drawing.Size(102, 13);
            this.lbl_interval.TabIndex = 9;
            this.lbl_interval.Text = "Trace Interval (sec):";
            this.toolTip1.SetToolTip(this.lbl_interval, "Number of seconds between each successive trace.");
            // 
            // ud_interval
            // 
            this.ud_interval.Location = new System.Drawing.Point(109, 19);
            this.ud_interval.Maximum = new decimal(new int[] {
            86400,
            0,
            0,
            0});
            this.ud_interval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ud_interval.Name = "ud_interval";
            this.ud_interval.Size = new System.Drawing.Size(52, 20);
            this.ud_interval.TabIndex = 5;
            this.toolTip1.SetToolTip(this.ud_interval, "Number of seconds between each successive trace.");
            this.ud_interval.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // ud_nTraces
            // 
            this.ud_nTraces.Location = new System.Drawing.Point(109, 45);
            this.ud_nTraces.Name = "ud_nTraces";
            this.ud_nTraces.Size = new System.Drawing.Size(52, 20);
            this.ud_nTraces.TabIndex = 6;
            this.toolTip1.SetToolTip(this.ud_nTraces, "Number of times to trace the supplied address - 0 is unlimited, anything higher s" +
                    "tops at that trace count.");
            // 
            // lbl_addrToTrace
            // 
            this.lbl_addrToTrace.AutoSize = true;
            this.lbl_addrToTrace.Location = new System.Drawing.Point(12, 29);
            this.lbl_addrToTrace.Name = "lbl_addrToTrace";
            this.lbl_addrToTrace.Size = new System.Drawing.Size(91, 13);
            this.lbl_addrToTrace.TabIndex = 17;
            this.lbl_addrToTrace.Text = "Address to Trace:";
            // 
            // btn_trace
            // 
            this.btn_trace.Location = new System.Drawing.Point(12, 363);
            this.btn_trace.Name = "btn_trace";
            this.btn_trace.Size = new System.Drawing.Size(167, 27);
            this.btn_trace.TabIndex = 16;
            this.btn_trace.Text = "Start";
            this.btn_trace.UseVisualStyleBackColor = true;
            this.btn_trace.Click += new System.EventHandler(this.btn_trace_Click);
            // 
            // lb_Addrs
            // 
            this.lb_Addrs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.lb_Addrs.FormattingEnabled = true;
            this.lb_Addrs.Location = new System.Drawing.Point(12, 71);
            this.lb_Addrs.Name = "lb_Addrs";
            this.lb_Addrs.Size = new System.Drawing.Size(167, 212);
            this.lb_Addrs.TabIndex = 15;
            this.lb_Addrs.SelectedIndexChanged += new System.EventHandler(this.lb_Addrs_SelectedIndexChanged);
            this.lb_Addrs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lb_Addrs_KeyDown);
            // 
            // txt_Addr
            // 
            this.txt_Addr.Location = new System.Drawing.Point(12, 45);
            this.txt_Addr.Name = "txt_Addr";
            this.txt_Addr.Size = new System.Drawing.Size(167, 20);
            this.txt_Addr.TabIndex = 14;
            this.txt_Addr.Text = "10.166.146.230";
            this.txt_Addr.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Addr_KeyPress);
            this.txt_Addr.Validating += new System.ComponentModel.CancelEventHandler(this.txt_Addr_Validating);
            // 
            // timer_elapsed
            // 
            this.timer_elapsed.Interval = 1000;
            this.timer_elapsed.Tick += new System.EventHandler(this.timer_elapsed_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mitem_file,
            this.mitem_help});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(748, 24);
            this.menuStrip1.TabIndex = 24;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mitem_file
            // 
            this.mitem_file.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveDataToFileToolStripMenuItem,
            this.toolStripSeparator1,
            this.mitem_exit});
            this.mitem_file.Name = "mitem_file";
            this.mitem_file.Size = new System.Drawing.Size(35, 20);
            this.mitem_file.Text = "File";
            // 
            // saveDataToFileToolStripMenuItem
            // 
            this.saveDataToFileToolStripMenuItem.Name = "saveDataToFileToolStripMenuItem";
            this.saveDataToFileToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.saveDataToFileToolStripMenuItem.Text = "Save data to file...";
            this.saveDataToFileToolStripMenuItem.Click += new System.EventHandler(this.saveDataToFileToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(173, 6);
            // 
            // mitem_exit
            // 
            this.mitem_exit.Name = "mitem_exit";
            this.mitem_exit.Size = new System.Drawing.Size(176, 22);
            this.mitem_exit.Text = "Exit";
            this.mitem_exit.Click += new System.EventHandler(this.mitem_exit_Click);
            // 
            // mitem_help
            // 
            this.mitem_help.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.mitem_help.Name = "mitem_help";
            this.mitem_help.Size = new System.Drawing.Size(40, 20);
            this.mitem_help.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // lbl_yellowPing
            // 
            this.lbl_yellowPing.BackColor = System.Drawing.Color.Yellow;
            this.lbl_yellowPing.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_yellowPing.Location = new System.Drawing.Point(6, 18);
            this.lbl_yellowPing.Name = "lbl_yellowPing";
            this.lbl_yellowPing.Size = new System.Drawing.Size(97, 16);
            this.lbl_yellowPing.TabIndex = 22;
            this.lbl_yellowPing.Text = "201-500 ms";
            this.lbl_yellowPing.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_greenPing
            // 
            this.lbl_greenPing.BackColor = System.Drawing.Color.Lime;
            this.lbl_greenPing.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_greenPing.Location = new System.Drawing.Point(6, 2);
            this.lbl_greenPing.Name = "lbl_greenPing";
            this.lbl_greenPing.Size = new System.Drawing.Size(97, 16);
            this.lbl_greenPing.TabIndex = 21;
            this.lbl_greenPing.Text = "0-200 ms";
            this.lbl_greenPing.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_redPing
            // 
            this.lbl_redPing.BackColor = System.Drawing.Color.Red;
            this.lbl_redPing.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_redPing.Location = new System.Drawing.Point(6, 34);
            this.lbl_redPing.Name = "lbl_redPing";
            this.lbl_redPing.Size = new System.Drawing.Size(97, 16);
            this.lbl_redPing.TabIndex = 23;
            this.lbl_redPing.Text = "501 ms and up";
            this.lbl_redPing.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel_legend
            // 
            this.panel_legend.Controls.Add(this.lbl_redPing);
            this.panel_legend.Controls.Add(this.lbl_greenPing);
            this.panel_legend.Controls.Add(this.lbl_yellowPing);
            this.panel_legend.Location = new System.Drawing.Point(633, 29);
            this.panel_legend.Name = "panel_legend";
            this.panel_legend.Size = new System.Drawing.Size(103, 50);
            this.panel_legend.TabIndex = 25;
            // 
            // lbl_targetAddr
            // 
            this.lbl_targetAddr.AutoSize = true;
            this.lbl_targetAddr.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_targetAddr.Location = new System.Drawing.Point(194, 37);
            this.lbl_targetAddr.Name = "lbl_targetAddr";
            this.lbl_targetAddr.Size = new System.Drawing.Size(105, 16);
            this.lbl_targetAddr.TabIndex = 19;
            this.lbl_targetAddr.Text = "Target Address:";
            // 
            // lbl_sampInterval
            // 
            this.lbl_sampInterval.AutoSize = true;
            this.lbl_sampInterval.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_sampInterval.Location = new System.Drawing.Point(185, 61);
            this.lbl_sampInterval.Name = "lbl_sampInterval";
            this.lbl_sampInterval.Size = new System.Drawing.Size(114, 16);
            this.lbl_sampInterval.TabIndex = 20;
            this.lbl_sampInterval.Text = "Sampling Interval:";
            // 
            // lbl_curTargAddr
            // 
            this.lbl_curTargAddr.AutoSize = true;
            this.lbl_curTargAddr.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_curTargAddr.Location = new System.Drawing.Point(305, 40);
            this.lbl_curTargAddr.Name = "lbl_curTargAddr";
            this.lbl_curTargAddr.Size = new System.Drawing.Size(97, 13);
            this.lbl_curTargAddr.TabIndex = 26;
            this.lbl_curTargAddr.Text = "lbl_curTargAddr";
            this.lbl_curTargAddr.Visible = false;
            // 
            // lbl_curSampInt
            // 
            this.lbl_curSampInt.AutoSize = true;
            this.lbl_curSampInt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_curSampInt.Location = new System.Drawing.Point(305, 63);
            this.lbl_curSampInt.Name = "lbl_curSampInt";
            this.lbl_curSampInt.Size = new System.Drawing.Size(77, 13);
            this.lbl_curSampInt.TabIndex = 27;
            this.lbl_curSampInt.Text = "lbl_curSampInt";
            this.lbl_curSampInt.Visible = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Location = new System.Drawing.Point(185, 79);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.Controls.Add(this.dgv_routeInfo);
            this.splitContainer1.Size = new System.Drawing.Size(551, 311);
            this.splitContainer1.SplitterDistance = 180;
            this.splitContainer1.TabIndex = 28;
            // 
            // dgv_routeInfo
            // 
            this.dgv_routeInfo.AllowUserToAddRows = false;
            this.dgv_routeInfo.AllowUserToDeleteRows = false;
            this.dgv_routeInfo.AllowUserToOrderColumns = true;
            this.dgv_routeInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_routeInfo.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgv_routeInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_routeInfo.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgv_routeInfo.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_routeInfo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_routeInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_routeInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.hopNum,
            this.IP,
            this.hostname,
            this.latency});
            this.dgv_routeInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_routeInfo.Location = new System.Drawing.Point(0, 0);
            this.dgv_routeInfo.Name = "dgv_routeInfo";
            this.dgv_routeInfo.ReadOnly = true;
            this.dgv_routeInfo.RowHeadersVisible = false;
            this.dgv_routeInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgv_routeInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_routeInfo.Size = new System.Drawing.Size(549, 178);
            this.dgv_routeInfo.TabIndex = 10;
            // 
            // hopNum
            // 
            this.hopNum.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.hopNum.DefaultCellStyle = dataGridViewCellStyle2;
            this.hopNum.FillWeight = 20F;
            this.hopNum.HeaderText = "Hop";
            this.hopNum.Name = "hopNum";
            this.hopNum.ReadOnly = true;
            // 
            // IP
            // 
            this.IP.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.IP.DefaultCellStyle = dataGridViewCellStyle3;
            this.IP.FillWeight = 109.6447F;
            this.IP.HeaderText = "IP Address";
            this.IP.Name = "IP";
            this.IP.ReadOnly = true;
            // 
            // hostname
            // 
            this.hostname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.hostname.DefaultCellStyle = dataGridViewCellStyle4;
            this.hostname.FillWeight = 109.6447F;
            this.hostname.HeaderText = "Hostname";
            this.hostname.Name = "hostname";
            this.hostname.ReadOnly = true;
            // 
            // latency
            // 
            this.latency.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.latency.DefaultCellStyle = dataGridViewCellStyle5;
            this.latency.FillWeight = 45F;
            this.latency.HeaderText = "Latency (ms)";
            this.latency.Name = "latency";
            this.latency.ReadOnly = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(748, 418);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.lbl_curSampInt);
            this.Controls.Add(this.lbl_curTargAddr);
            this.Controls.Add(this.lbl_sampInterval);
            this.Controls.Add(this.lbl_targetAddr);
            this.Controls.Add(this.gb_sampling);
            this.Controls.Add(this.lbl_addrToTrace);
            this.Controls.Add(this.btn_trace);
            this.Controls.Add(this.lb_Addrs);
            this.Controls.Add(this.txt_Addr);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panel_legend);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "PlotPing";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.gb_sampling.ResumeLayout(false);
            this.gb_sampling.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ud_interval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ud_nTraces)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel_legend.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_routeInfo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel slbl_Status;
        private System.ComponentModel.BackgroundWorker bgwrkr_runTrace;
        private System.Windows.Forms.ToolStripProgressBar progressBar;
        private System.Windows.Forms.ToolStripStatusLabel slbl_traceCount;
        private System.Windows.Forms.ToolStripStatusLabel slbl_roundTrip;
        private System.Windows.Forms.GroupBox gb_sampling;
        private System.Windows.Forms.Label lbl_nTraces;
        private System.Windows.Forms.Label lbl_interval;
        private System.Windows.Forms.NumericUpDown ud_interval;
        private System.Windows.Forms.NumericUpDown ud_nTraces;
        private System.Windows.Forms.Label lbl_addrToTrace;
        private System.Windows.Forms.Button btn_trace;
        private System.Windows.Forms.ListBox lb_Addrs;
        private System.Windows.Forms.TextBox txt_Addr;
        private System.Windows.Forms.Timer timer_elapsed;
        private System.Windows.Forms.ToolStripStatusLabel slbl_avgMinMax;
        private System.Windows.Forms.ToolStripStatusLabel slbl_elapsed;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mitem_file;
        private System.Windows.Forms.ToolStripMenuItem mitem_help;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mitem_exit;
        private System.Windows.Forms.ToolStripMenuItem saveDataToFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label lbl_yellowPing;
        private System.Windows.Forms.Label lbl_greenPing;
        private System.Windows.Forms.Label lbl_redPing;
        private System.Windows.Forms.Panel panel_legend;
        private System.Windows.Forms.Label lbl_targetAddr;
        private System.Windows.Forms.Label lbl_sampInterval;
        private System.Windows.Forms.Label lbl_curTargAddr;
        private System.Windows.Forms.Label lbl_curSampInt;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgv_routeInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn hopNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn IP;
        private System.Windows.Forms.DataGridViewTextBoxColumn hostname;
        private System.Windows.Forms.DataGridViewTextBoxColumn latency;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

