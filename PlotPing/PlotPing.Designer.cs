namespace PlotPing
{
    partial class PlotPing
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint1 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 0D);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlotPing));
            this.addrComboBox = new System.Windows.Forms.ComboBox();
            this.routeListView = new System.Windows.Forms.ListView();
            this.hopCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ipCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.curTimeCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.traceBtn = new System.Windows.Forms.Button();
            this.addrLbl = new System.Windows.Forms.Label();
            this.tracertBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.nTraceLbl = new System.Windows.Forms.Label();
            this.nTraceUpDown = new System.Windows.Forms.NumericUpDown();
            this.traceIntLbl = new System.Windows.Forms.Label();
            this.traceIntUpDown = new System.Windows.Forms.NumericUpDown();
            this.roundTripLbl = new System.Windows.Forms.Label();
            this.totPingLbl = new System.Windows.Forms.Label();
            this.chartPings = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblTarget = new System.Windows.Forms.Label();
            this.lblSampleInt = new System.Windows.Forms.Label();
            this.lblStartTime = new System.Windows.Forms.Label();
            this.lblEndTime = new System.Windows.Forms.Label();
            this.lblGreenPing = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.contentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.indexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printPreviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveDataSetAscsvToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportDataFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportChartMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.toolTipHover = new System.Windows.Forms.ToolTip(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.listBoxNetworkInterface = new System.Windows.Forms.ListBox();
            this.toolTipNetworkInterface = new System.Windows.Forms.ToolTip(this.components);
            this.textBoxUserNotes = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.nTraceUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.traceIntUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartPings)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // addrComboBox
            // 
            this.addrComboBox.FormattingEnabled = true;
            this.addrComboBox.Items.AddRange(new object[] {
            "www.google.com",
            "www.facebook.com",
            "speedtest.cfl.rr.com"});
            this.addrComboBox.Location = new System.Drawing.Point(117, 27);
            this.addrComboBox.Name = "addrComboBox";
            this.addrComboBox.Size = new System.Drawing.Size(145, 21);
            this.addrComboBox.TabIndex = 9;
            this.addrComboBox.Text = "www.google.com";
            // 
            // routeListView
            // 
            this.routeListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.hopCol,
            this.ipCol,
            this.curTimeCol});
            this.routeListView.Location = new System.Drawing.Point(27, 140);
            this.routeListView.Name = "routeListView";
            this.routeListView.Size = new System.Drawing.Size(235, 248);
            this.routeListView.TabIndex = 8;
            this.routeListView.UseCompatibleStateImageBehavior = false;
            this.routeListView.View = System.Windows.Forms.View.Details;
            // 
            // hopCol
            // 
            this.hopCol.Text = "Hop";
            this.hopCol.Width = 32;
            // 
            // ipCol
            // 
            this.ipCol.Text = "IP Address";
            this.ipCol.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ipCol.Width = 122;
            // 
            // curTimeCol
            // 
            this.curTimeCol.Text = "Ping (ms)";
            this.curTimeCol.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.curTimeCol.Width = 77;
            // 
            // traceBtn
            // 
            this.traceBtn.Location = new System.Drawing.Point(185, 89);
            this.traceBtn.Name = "traceBtn";
            this.traceBtn.Size = new System.Drawing.Size(77, 23);
            this.traceBtn.TabIndex = 7;
            this.traceBtn.Text = "Trace";
            this.traceBtn.UseVisualStyleBackColor = true;
            this.traceBtn.Click += new System.EventHandler(this.traceBtn_Click);
            // 
            // addrLbl
            // 
            this.addrLbl.AutoSize = true;
            this.addrLbl.Location = new System.Drawing.Point(24, 27);
            this.addrLbl.Name = "addrLbl";
            this.addrLbl.Size = new System.Drawing.Size(87, 13);
            this.addrLbl.TabIndex = 6;
            this.addrLbl.Text = "Address to trace:";
            // 
            // tracertBackgroundWorker
            // 
            this.tracertBackgroundWorker.WorkerReportsProgress = true;
            this.tracertBackgroundWorker.WorkerSupportsCancellation = true;
            this.tracertBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.tracertBackgroundWorker_DoWork);
            this.tracertBackgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.tracertBackgroundWorker_ProgressChanged);
            this.tracertBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.tracertBackgroundWorker_RunWorkerCompleted);
            // 
            // nTraceLbl
            // 
            this.nTraceLbl.AutoSize = true;
            this.nTraceLbl.Location = new System.Drawing.Point(20, 90);
            this.nTraceLbl.Name = "nTraceLbl";
            this.nTraceLbl.Size = new System.Drawing.Size(91, 13);
            this.nTraceLbl.TabIndex = 10;
            this.nTraceLbl.Text = "Number of traces:";
            this.nTraceLbl.MouseHover += new System.EventHandler(this.nTraceLbl_MouseHover);
            // 
            // nTraceUpDown
            // 
            this.nTraceUpDown.Location = new System.Drawing.Point(117, 88);
            this.nTraceUpDown.Name = "nTraceUpDown";
            this.nTraceUpDown.Size = new System.Drawing.Size(62, 20);
            this.nTraceUpDown.TabIndex = 12;
            // 
            // traceIntLbl
            // 
            this.traceIntLbl.AutoSize = true;
            this.traceIntLbl.Location = new System.Drawing.Point(10, 116);
            this.traceIntLbl.Name = "traceIntLbl";
            this.traceIntLbl.Size = new System.Drawing.Size(101, 13);
            this.traceIntLbl.TabIndex = 13;
            this.traceIntLbl.Text = "Trace interval (sec):";
            // 
            // traceIntUpDown
            // 
            this.traceIntUpDown.DecimalPlaces = 1;
            this.traceIntUpDown.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.traceIntUpDown.Location = new System.Drawing.Point(117, 114);
            this.traceIntUpDown.Maximum = new decimal(new int[] {
            86400,
            0,
            0,
            0});
            this.traceIntUpDown.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.traceIntUpDown.Name = "traceIntUpDown";
            this.traceIntUpDown.Size = new System.Drawing.Size(62, 20);
            this.traceIntUpDown.TabIndex = 14;
            this.traceIntUpDown.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // roundTripLbl
            // 
            this.roundTripLbl.AutoSize = true;
            this.roundTripLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roundTripLbl.Location = new System.Drawing.Point(114, 391);
            this.roundTripLbl.Name = "roundTripLbl";
            this.roundTripLbl.Size = new System.Drawing.Size(103, 13);
            this.roundTripLbl.TabIndex = 15;
            this.roundTripLbl.Text = "Round Trip Ping:";
            // 
            // totPingLbl
            // 
            this.totPingLbl.AutoSize = true;
            this.totPingLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totPingLbl.Location = new System.Drawing.Point(223, 391);
            this.totPingLbl.Name = "totPingLbl";
            this.totPingLbl.Size = new System.Drawing.Size(30, 13);
            this.totPingLbl.TabIndex = 16;
            this.totPingLbl.Text = "N/A";
            // 
            // chartPings
            // 
            this.chartPings.BackColor = System.Drawing.SystemColors.Control;
            this.chartPings.BackSecondaryColor = System.Drawing.Color.White;
            this.chartPings.BorderlineColor = System.Drawing.Color.Black;
            chartArea1.AxisX.IsLabelAutoFit = false;
            chartArea1.AxisX.LabelAutoFitMaxFontSize = 7;
            chartArea1.AxisX.LabelAutoFitMinFontSize = 7;
            chartArea1.AxisX.LabelStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            chartArea1.AxisX.LabelStyle.Format = "h:mm:ss";
            chartArea1.AxisX.LabelStyle.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Seconds;
            chartArea1.AxisX.MajorGrid.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Seconds;
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.DimGray;
            chartArea1.AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea1.AxisX.Title = "Time";
            chartArea1.AxisX.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            chartArea1.AxisY.IsLabelAutoFit = false;
            chartArea1.AxisY.LabelAutoFitMaxFontSize = 7;
            chartArea1.AxisY.LabelAutoFitMinFontSize = 7;
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.DimGray;
            chartArea1.AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea1.AxisY.Title = "Ping (ms)";
            chartArea1.AxisY.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            chartArea1.AxisY2.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 4F);
            chartArea1.BackColor = System.Drawing.Color.Black;
            chartArea1.BackSecondaryColor = System.Drawing.Color.White;
            chartArea1.InnerPlotPosition.Auto = false;
            chartArea1.InnerPlotPosition.Height = 85F;
            chartArea1.InnerPlotPosition.Width = 93F;
            chartArea1.InnerPlotPosition.X = 7F;
            chartArea1.InnerPlotPosition.Y = 2F;
            chartArea1.Name = "ChartArea1";
            this.chartPings.ChartAreas.Add(chartArea1);
            this.chartPings.Location = new System.Drawing.Point(259, 32);
            this.chartPings.Name = "chartPings";
            series1.BorderWidth = 2;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Color = System.Drawing.Color.Lime;
            series1.Name = "Series1";
            dataPoint1.Color = System.Drawing.Color.Red;
            series1.Points.Add(dataPoint1);
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            this.chartPings.Series.Add(series1);
            this.chartPings.Size = new System.Drawing.Size(627, 356);
            this.chartPings.TabIndex = 17;
            this.chartPings.Text = "chart1";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(185, 116);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(77, 13);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 18;
            this.progressBar1.Visible = false;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(314, 7);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(110, 17);
            this.lblTitle.TabIndex = 19;
            this.lblTitle.Text = "Target Address:";
            // 
            // lblTarget
            // 
            this.lblTarget.AutoSize = true;
            this.lblTarget.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTarget.Location = new System.Drawing.Point(430, 9);
            this.lblTarget.Name = "lblTarget";
            this.lblTarget.Size = new System.Drawing.Size(30, 13);
            this.lblTarget.TabIndex = 20;
            this.lblTarget.Text = "N/A";
            // 
            // lblSampleInt
            // 
            this.lblSampleInt.AutoSize = true;
            this.lblSampleInt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSampleInt.Location = new System.Drawing.Point(315, 24);
            this.lblSampleInt.Name = "lblSampleInt";
            this.lblSampleInt.Size = new System.Drawing.Size(109, 17);
            this.lblSampleInt.TabIndex = 21;
            this.lblSampleInt.Text = "Sample Interval:";
            // 
            // lblStartTime
            // 
            this.lblStartTime.AutoSize = true;
            this.lblStartTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStartTime.Location = new System.Drawing.Point(430, 26);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new System.Drawing.Size(27, 13);
            this.lblStartTime.TabIndex = 22;
            this.lblStartTime.Text = "N/A";
            // 
            // lblEndTime
            // 
            this.lblEndTime.AutoSize = true;
            this.lblEndTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEndTime.Location = new System.Drawing.Point(592, 26);
            this.lblEndTime.Name = "lblEndTime";
            this.lblEndTime.Size = new System.Drawing.Size(27, 13);
            this.lblEndTime.TabIndex = 23;
            this.lblEndTime.Text = "N/A";
            this.lblEndTime.Visible = false;
            // 
            // lblGreenPing
            // 
            this.lblGreenPing.BackColor = System.Drawing.Color.Lime;
            this.lblGreenPing.Location = new System.Drawing.Point(767, 3);
            this.lblGreenPing.Name = "lblGreenPing";
            this.lblGreenPing.Size = new System.Drawing.Size(100, 13);
            this.lblGreenPing.TabIndex = 24;
            this.lblGreenPing.Text = "0-200 ms";
            this.lblGreenPing.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Yellow;
            this.label1.Location = new System.Drawing.Point(767, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "201-500 ms";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(767, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = ">500 ms or Timeout";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // contentsToolStripMenuItem
            // 
            this.contentsToolStripMenuItem.Name = "contentsToolStripMenuItem";
            this.contentsToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            this.contentsToolStripMenuItem.Text = "&Contents";
            // 
            // indexToolStripMenuItem
            // 
            this.indexToolStripMenuItem.Name = "indexToolStripMenuItem";
            this.indexToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            this.indexToolStripMenuItem.Text = "&Index";
            // 
            // searchToolStripMenuItem
            // 
            this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            this.searchToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            this.searchToolStripMenuItem.Text = "&Search";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 6);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            this.aboutToolStripMenuItem.Text = "&About...";
            // 
            // customizeToolStripMenuItem
            // 
            this.customizeToolStripMenuItem.Name = "customizeToolStripMenuItem";
            this.customizeToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            this.customizeToolStripMenuItem.Text = "&Customize";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            this.optionsToolStripMenuItem.Text = "&Options";
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            this.undoToolStripMenuItem.Text = "&Undo";
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            this.redoToolStripMenuItem.Text = "&Redo";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 6);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("cutToolStripMenuItem.Image")));
            this.cutToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            this.cutToolStripMenuItem.Text = "Cu&t";
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("copyToolStripMenuItem.Image")));
            this.copyToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            this.copyToolStripMenuItem.Text = "&Copy";
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("pasteToolStripMenuItem.Image")));
            this.pasteToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            this.pasteToolStripMenuItem.Text = "&Paste";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 6);
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            this.selectAllToolStripMenuItem.Text = "Select &All";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripMenuItem.Image")));
            this.newToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            this.newToolStripMenuItem.Text = "&New";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem.Image")));
            this.openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            this.openToolStripMenuItem.Text = "&Open";
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
            this.saveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            this.saveToolStripMenuItem.Text = "&Save";
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            this.saveAsToolStripMenuItem.Text = "Save &As";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 6);
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("printToolStripMenuItem.Image")));
            this.printToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.printToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            this.printToolStripMenuItem.Text = "&Print";
            // 
            // printPreviewToolStripMenuItem
            // 
            this.printPreviewToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("printPreviewToolStripMenuItem.Image")));
            this.printPreviewToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.printPreviewToolStripMenuItem.Name = "printPreviewToolStripMenuItem";
            this.printPreviewToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            this.printPreviewToolStripMenuItem.Text = "Print Pre&view";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            this.exitToolStripMenuItem.Text = "E&xit";
            // 
            // saveDataSetAscsvToolStripMenuItem
            // 
            this.saveDataSetAscsvToolStripMenuItem.Name = "saveDataSetAscsvToolStripMenuItem";
            this.saveDataSetAscsvToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.saveDataSetAscsvToolStripMenuItem.Text = "Export data to text file";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportDataFileToolStripMenuItem,
            this.exportChartMenuItem,
            this.toolStripSeparator6,
            this.exitToolStripMenuItem1});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.RightToLeftAutoMirrorImage = true;
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // exportDataFileToolStripMenuItem
            // 
            this.exportDataFileToolStripMenuItem.Name = "exportDataFileToolStripMenuItem";
            this.exportDataFileToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.exportDataFileToolStripMenuItem.Text = "Export data to file...";
            this.exportDataFileToolStripMenuItem.Click += new System.EventHandler(this.exportDataFileToolStripMenuItem_Click);
            // 
            // exportChartMenuItem
            // 
            this.exportChartMenuItem.Name = "exportChartMenuItem";
            this.exportChartMenuItem.Size = new System.Drawing.Size(179, 22);
            this.exportChartMenuItem.Text = "Export chart to file...";
            this.exportChartMenuItem.Click += new System.EventHandler(this.exportChartMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(176, 6);
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(179, 22);
            this.exitToolStripMenuItem1.Text = "E&xit";
            this.exitToolStripMenuItem1.Click += new System.EventHandler(this.exitToolStripMenuItem1_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem1});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem1
            // 
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(116, 22);
            this.aboutToolStripMenuItem1.Text = "&About...";
            this.aboutToolStripMenuItem1.Click += new System.EventHandler(this.aboutToolStripMenuItem1_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.menuStrip1.Size = new System.Drawing.Size(874, 24);
            this.menuStrip1.TabIndex = 27;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 28;
            this.label3.Text = "Using interface:";
            // 
            // listBoxNetworkInterface
            // 
            this.listBoxNetworkInterface.FormattingEnabled = true;
            this.listBoxNetworkInterface.Location = new System.Drawing.Point(117, 57);
            this.listBoxNetworkInterface.Name = "listBoxNetworkInterface";
            this.listBoxNetworkInterface.Size = new System.Drawing.Size(145, 17);
            this.listBoxNetworkInterface.TabIndex = 29;
            // 
            // textBoxUserNotes
            // 
            this.textBoxUserNotes.Location = new System.Drawing.Point(325, 369);
            this.textBoxUserNotes.Multiline = true;
            this.textBoxUserNotes.Name = "textBoxUserNotes";
            this.textBoxUserNotes.Size = new System.Drawing.Size(537, 34);
            this.textBoxUserNotes.TabIndex = 30;
            this.textBoxUserNotes.Text = "Type notes/observations here; will accompany any saved data";
            // 
            // PlotPing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 423);
            this.Controls.Add(this.textBoxUserNotes);
            this.Controls.Add(this.listBoxNetworkInterface);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblGreenPing);
            this.Controls.Add(this.lblEndTime);
            this.Controls.Add(this.lblStartTime);
            this.Controls.Add(this.lblSampleInt);
            this.Controls.Add(this.lblTarget);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.totPingLbl);
            this.Controls.Add(this.roundTripLbl);
            this.Controls.Add(this.traceIntUpDown);
            this.Controls.Add(this.traceIntLbl);
            this.Controls.Add(this.nTraceUpDown);
            this.Controls.Add(this.nTraceLbl);
            this.Controls.Add(this.addrComboBox);
            this.Controls.Add(this.routeListView);
            this.Controls.Add(this.traceBtn);
            this.Controls.Add(this.addrLbl);
            this.Controls.Add(this.chartPings);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PlotPing";
            this.Text = "PlotPing";
            ((System.ComponentModel.ISupportInitialize)(this.nTraceUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.traceIntUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartPings)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox addrComboBox;
        private System.Windows.Forms.ListView routeListView;
        private System.Windows.Forms.ColumnHeader hopCol;
        private System.Windows.Forms.ColumnHeader ipCol;
        private System.Windows.Forms.Button traceBtn;
        private System.Windows.Forms.Label addrLbl;
        private System.ComponentModel.BackgroundWorker tracertBackgroundWorker;
        private System.Windows.Forms.Label nTraceLbl;
        private System.Windows.Forms.NumericUpDown nTraceUpDown;
        private System.Windows.Forms.Label traceIntLbl;
        private System.Windows.Forms.NumericUpDown traceIntUpDown;
        private System.Windows.Forms.ColumnHeader curTimeCol;
        private System.Windows.Forms.Label roundTripLbl;
        private System.Windows.Forms.Label totPingLbl;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartPings;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblTarget;
        private System.Windows.Forms.Label lblSampleInt;
        private System.Windows.Forms.Label lblStartTime;
        private System.Windows.Forms.Label lblEndTime;
        private System.Windows.Forms.Label lblGreenPing;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem contentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem indexToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printPreviewToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveDataSetAscsvToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem exportDataFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolTip toolTipHover;
        private System.Windows.Forms.ToolStripMenuItem exportChartMenuItem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox listBoxNetworkInterface;
        private System.Windows.Forms.ToolTip toolTipNetworkInterface;
        private System.Windows.Forms.TextBox textBoxUserNotes;
    }
}

