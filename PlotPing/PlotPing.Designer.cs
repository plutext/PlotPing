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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint2 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 0D);
            this.addrComboBox = new System.Windows.Forms.ComboBox();
            this.routeListView = new System.Windows.Forms.ListView();
            this.hopCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ipCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hostCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
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
            ((System.ComponentModel.ISupportInitialize)(this.nTraceUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.traceIntUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartPings)).BeginInit();
            this.SuspendLayout();
            // 
            // addrComboBox
            // 
            this.addrComboBox.FormattingEnabled = true;
            this.addrComboBox.Items.AddRange(new object[] {
            "www.google.com",
            "www.facebook.com",
            "speedtest.cfl.rr.com"});
            this.addrComboBox.Location = new System.Drawing.Point(102, 9);
            this.addrComboBox.Name = "addrComboBox";
            this.addrComboBox.Size = new System.Drawing.Size(207, 21);
            this.addrComboBox.TabIndex = 9;
            this.addrComboBox.Text = "www.google.com";
            // 
            // routeListView
            // 
            this.routeListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.hopCol,
            this.ipCol,
            this.hostCol,
            this.curTimeCol});
            this.routeListView.Location = new System.Drawing.Point(12, 61);
            this.routeListView.Name = "routeListView";
            this.routeListView.Size = new System.Drawing.Size(380, 248);
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
            this.ipCol.Width = 99;
            // 
            // hostCol
            // 
            this.hostCol.Text = "Hostname";
            this.hostCol.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.hostCol.Width = 157;
            // 
            // curTimeCol
            // 
            this.curTimeCol.Text = "Ping (ms)";
            this.curTimeCol.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.curTimeCol.Width = 96;
            // 
            // traceBtn
            // 
            this.traceBtn.Location = new System.Drawing.Point(315, 7);
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
            this.addrLbl.Location = new System.Drawing.Point(9, 9);
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
            this.nTraceLbl.Location = new System.Drawing.Point(9, 35);
            this.nTraceLbl.Name = "nTraceLbl";
            this.nTraceLbl.Size = new System.Drawing.Size(125, 13);
            this.nTraceLbl.TabIndex = 10;
            this.nTraceLbl.Text = "Number of times to trace:";
            // 
            // nTraceUpDown
            // 
            this.nTraceUpDown.Location = new System.Drawing.Point(140, 36);
            this.nTraceUpDown.Name = "nTraceUpDown";
            this.nTraceUpDown.Size = new System.Drawing.Size(62, 20);
            this.nTraceUpDown.TabIndex = 12;
            // 
            // traceIntLbl
            // 
            this.traceIntLbl.AutoSize = true;
            this.traceIntLbl.Location = new System.Drawing.Point(208, 35);
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
            this.traceIntUpDown.Location = new System.Drawing.Point(315, 36);
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
            this.traceIntUpDown.Size = new System.Drawing.Size(77, 20);
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
            this.roundTripLbl.Location = new System.Drawing.Point(241, 312);
            this.roundTripLbl.Name = "roundTripLbl";
            this.roundTripLbl.Size = new System.Drawing.Size(103, 13);
            this.roundTripLbl.TabIndex = 15;
            this.roundTripLbl.Text = "Round Trip Ping:";
            // 
            // totPingLbl
            // 
            this.totPingLbl.AutoSize = true;
            this.totPingLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totPingLbl.Location = new System.Drawing.Point(350, 312);
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
            chartArea2.AxisX.IsLabelAutoFit = false;
            chartArea2.AxisX.LabelAutoFitMaxFontSize = 7;
            chartArea2.AxisX.LabelAutoFitMinFontSize = 7;
            chartArea2.AxisX.LabelStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            chartArea2.AxisX.LabelStyle.Format = "h:mm:ss";
            chartArea2.AxisX.LabelStyle.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Seconds;
            chartArea2.AxisX.MajorGrid.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Seconds;
            chartArea2.AxisX.MajorGrid.LineColor = System.Drawing.Color.DimGray;
            chartArea2.AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea2.AxisX.Title = "Time";
            chartArea2.AxisX.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            chartArea2.AxisY.IsLabelAutoFit = false;
            chartArea2.AxisY.LabelAutoFitMaxFontSize = 7;
            chartArea2.AxisY.LabelAutoFitMinFontSize = 7;
            chartArea2.AxisY.MajorGrid.LineColor = System.Drawing.Color.DimGray;
            chartArea2.AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea2.AxisY.Title = "Ping (ms)";
            chartArea2.AxisY.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            chartArea2.AxisY2.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 4F);
            chartArea2.BackColor = System.Drawing.Color.Black;
            chartArea2.BackSecondaryColor = System.Drawing.Color.White;
            chartArea2.InnerPlotPosition.Auto = false;
            chartArea2.InnerPlotPosition.Height = 85F;
            chartArea2.InnerPlotPosition.Width = 93F;
            chartArea2.InnerPlotPosition.X = 7F;
            chartArea2.InnerPlotPosition.Y = 2F;
            chartArea2.Name = "ChartArea1";
            this.chartPings.ChartAreas.Add(chartArea2);
            this.chartPings.Location = new System.Drawing.Point(398, 35);
            this.chartPings.Name = "chartPings";
            series2.BorderWidth = 2;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Color = System.Drawing.Color.Lime;
            series2.Name = "Series1";
            dataPoint2.Color = System.Drawing.Color.Red;
            series2.Points.Add(dataPoint2);
            series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            this.chartPings.Series.Add(series2);
            this.chartPings.Size = new System.Drawing.Size(627, 325);
            this.chartPings.TabIndex = 17;
            this.chartPings.Text = "chart1";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 316);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(109, 10);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 18;
            this.progressBar1.Visible = false;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(453, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(110, 17);
            this.lblTitle.TabIndex = 19;
            this.lblTitle.Text = "Target Address:";
            // 
            // lblTarget
            // 
            this.lblTarget.AutoSize = true;
            this.lblTarget.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTarget.Location = new System.Drawing.Point(569, 12);
            this.lblTarget.Name = "lblTarget";
            this.lblTarget.Size = new System.Drawing.Size(30, 13);
            this.lblTarget.TabIndex = 20;
            this.lblTarget.Text = "N/A";
            // 
            // lblSampleInt
            // 
            this.lblSampleInt.AutoSize = true;
            this.lblSampleInt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSampleInt.Location = new System.Drawing.Point(454, 27);
            this.lblSampleInt.Name = "lblSampleInt";
            this.lblSampleInt.Size = new System.Drawing.Size(109, 17);
            this.lblSampleInt.TabIndex = 21;
            this.lblSampleInt.Text = "Sample Interval:";
            // 
            // lblStartTime
            // 
            this.lblStartTime.AutoSize = true;
            this.lblStartTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStartTime.Location = new System.Drawing.Point(569, 29);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new System.Drawing.Size(27, 13);
            this.lblStartTime.TabIndex = 22;
            this.lblStartTime.Text = "N/A";
            // 
            // lblEndTime
            // 
            this.lblEndTime.AutoSize = true;
            this.lblEndTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEndTime.Location = new System.Drawing.Point(731, 29);
            this.lblEndTime.Name = "lblEndTime";
            this.lblEndTime.Size = new System.Drawing.Size(27, 13);
            this.lblEndTime.TabIndex = 23;
            this.lblEndTime.Text = "N/A";
            this.lblEndTime.Visible = false;
            // 
            // lblGreenPing
            // 
            this.lblGreenPing.BackColor = System.Drawing.Color.Lime;
            this.lblGreenPing.Location = new System.Drawing.Point(906, 6);
            this.lblGreenPing.Name = "lblGreenPing";
            this.lblGreenPing.Size = new System.Drawing.Size(100, 13);
            this.lblGreenPing.TabIndex = 24;
            this.lblGreenPing.Text = "0-200 ms";
            this.lblGreenPing.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Yellow;
            this.label1.Location = new System.Drawing.Point(906, 19);
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
            this.label2.Location = new System.Drawing.Point(906, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = ">500 ms or Timeout";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1037, 349);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblGreenPing);
            this.Controls.Add(this.lblEndTime);
            this.Controls.Add(this.lblStartTime);
            this.Controls.Add(this.lblSampleInt);
            this.Controls.Add(this.lblTarget);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.chartPings);
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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.Text = "PlotPing";
            ((System.ComponentModel.ISupportInitialize)(this.nTraceUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.traceIntUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartPings)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox addrComboBox;
        private System.Windows.Forms.ListView routeListView;
        private System.Windows.Forms.ColumnHeader hopCol;
        private System.Windows.Forms.ColumnHeader ipCol;
        private System.Windows.Forms.ColumnHeader hostCol;
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
    }
}

