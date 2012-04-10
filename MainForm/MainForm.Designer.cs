namespace MainForm
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
            ((System.ComponentModel.ISupportInitialize)(this.nTraceUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.traceIntUpDown)).BeginInit();
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
            1000,
            0,
            0,
            0});
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 349);
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
    }
}

