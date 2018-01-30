namespace NATRIX_Host
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
            this.mainStatusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.mainToolStrip = new System.Windows.Forms.ToolStrip();
            this.connectionBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.infoBtn = new System.Windows.Forms.ToolStripButton();
            this.settingsBtn = new System.Windows.Forms.ToolStripButton();
            this.mainSplit = new System.Windows.Forms.SplitContainer();
            this.leftTabCtrl = new System.Windows.Forms.TabControl();
            this.serviceModeTab = new System.Windows.Forms.TabPage();
            this.readSettingsBtn = new System.Windows.Forms.Button();
            this.locDataQueryBtn = new System.Windows.Forms.Button();
            this.writeSettingsBtn = new System.Windows.Forms.Button();
            this.locDataIdCbx = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.rxChIdCbx = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txChIdCbx = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataModeTab = new System.Windows.Forms.TabPage();
            this.resendPeriodEdit = new System.Windows.Forms.NumericUpDown();
            this.isSERModeChb = new System.Windows.Forms.CheckBox();
            this.echoerModeChb = new System.Windows.Forms.CheckBox();
            this.sendOnceBtn = new System.Windows.Forms.Button();
            this.testMessageTxb = new System.Windows.Forms.TextBox();
            this.testMsgLbl = new System.Windows.Forms.Label();
            this.commLogToolStrip = new System.Windows.Forms.ToolStrip();
            this.commLogClearBtn = new System.Windows.Forms.ToolStripButton();
            this.commLogExportBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.writeStatisticsBtn = new System.Windows.Forms.ToolStripButton();
            this.commLogTxb = new System.Windows.Forms.RichTextBox();
            this.mainStatusStrip.SuspendLayout();
            this.mainToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainSplit)).BeginInit();
            this.mainSplit.Panel1.SuspendLayout();
            this.mainSplit.Panel2.SuspendLayout();
            this.mainSplit.SuspendLayout();
            this.leftTabCtrl.SuspendLayout();
            this.serviceModeTab.SuspendLayout();
            this.dataModeTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resendPeriodEdit)).BeginInit();
            this.commLogToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainStatusStrip
            // 
            this.mainStatusStrip.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mainStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLbl});
            this.mainStatusStrip.Location = new System.Drawing.Point(0, 546);
            this.mainStatusStrip.Name = "mainStatusStrip";
            this.mainStatusStrip.Size = new System.Drawing.Size(1061, 33);
            this.mainStatusStrip.TabIndex = 0;
            this.mainStatusStrip.Text = "statusStrip";
            // 
            // statusLbl
            // 
            this.statusLbl.Name = "statusLbl";
            this.statusLbl.Size = new System.Drawing.Size(192, 28);
            this.statusLbl.Text = "Status: Disconnected";
            // 
            // mainToolStrip
            // 
            this.mainToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectionBtn,
            this.toolStripSeparator1,
            this.infoBtn,
            this.settingsBtn});
            this.mainToolStrip.Location = new System.Drawing.Point(0, 0);
            this.mainToolStrip.Name = "mainToolStrip";
            this.mainToolStrip.Size = new System.Drawing.Size(1061, 35);
            this.mainToolStrip.TabIndex = 1;
            this.mainToolStrip.Text = "toolStrip1";
            // 
            // connectionBtn
            // 
            this.connectionBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.connectionBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.connectionBtn.Image = ((System.Drawing.Image)(resources.GetObject("connectionBtn.Image")));
            this.connectionBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.connectionBtn.Name = "connectionBtn";
            this.connectionBtn.Size = new System.Drawing.Size(88, 32);
            this.connectionBtn.Text = "Connect";
            this.connectionBtn.Click += new System.EventHandler(this.connectionBtn_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 35);
            // 
            // infoBtn
            // 
            this.infoBtn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.infoBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.infoBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.infoBtn.Image = ((System.Drawing.Image)(resources.GetObject("infoBtn.Image")));
            this.infoBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.infoBtn.Name = "infoBtn";
            this.infoBtn.Size = new System.Drawing.Size(50, 32);
            this.infoBtn.Text = "Info";
            this.infoBtn.Click += new System.EventHandler(this.infoBtn_Click);
            // 
            // settingsBtn
            // 
            this.settingsBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.settingsBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.settingsBtn.Image = ((System.Drawing.Image)(resources.GetObject("settingsBtn.Image")));
            this.settingsBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.settingsBtn.Name = "settingsBtn";
            this.settingsBtn.Size = new System.Drawing.Size(87, 32);
            this.settingsBtn.Text = "Settings";
            this.settingsBtn.Click += new System.EventHandler(this.settingsBtn_Click);
            // 
            // mainSplit
            // 
            this.mainSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainSplit.Location = new System.Drawing.Point(0, 35);
            this.mainSplit.Name = "mainSplit";
            // 
            // mainSplit.Panel1
            // 
            this.mainSplit.Panel1.Controls.Add(this.leftTabCtrl);
            // 
            // mainSplit.Panel2
            // 
            this.mainSplit.Panel2.Controls.Add(this.commLogToolStrip);
            this.mainSplit.Panel2.Controls.Add(this.commLogTxb);
            this.mainSplit.Size = new System.Drawing.Size(1061, 511);
            this.mainSplit.SplitterDistance = 353;
            this.mainSplit.TabIndex = 2;
            // 
            // leftTabCtrl
            // 
            this.leftTabCtrl.Controls.Add(this.serviceModeTab);
            this.leftTabCtrl.Controls.Add(this.dataModeTab);
            this.leftTabCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.leftTabCtrl.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.leftTabCtrl.Location = new System.Drawing.Point(0, 0);
            this.leftTabCtrl.Name = "leftTabCtrl";
            this.leftTabCtrl.SelectedIndex = 0;
            this.leftTabCtrl.Size = new System.Drawing.Size(353, 511);
            this.leftTabCtrl.TabIndex = 0;
            this.leftTabCtrl.SelectedIndexChanged += new System.EventHandler(this.leftTabCtrl_SelectedIndexChanged);
            // 
            // serviceModeTab
            // 
            this.serviceModeTab.Controls.Add(this.readSettingsBtn);
            this.serviceModeTab.Controls.Add(this.locDataQueryBtn);
            this.serviceModeTab.Controls.Add(this.writeSettingsBtn);
            this.serviceModeTab.Controls.Add(this.locDataIdCbx);
            this.serviceModeTab.Controls.Add(this.label3);
            this.serviceModeTab.Controls.Add(this.rxChIdCbx);
            this.serviceModeTab.Controls.Add(this.label2);
            this.serviceModeTab.Controls.Add(this.txChIdCbx);
            this.serviceModeTab.Controls.Add(this.label1);
            this.serviceModeTab.Location = new System.Drawing.Point(4, 37);
            this.serviceModeTab.Name = "serviceModeTab";
            this.serviceModeTab.Padding = new System.Windows.Forms.Padding(3);
            this.serviceModeTab.Size = new System.Drawing.Size(345, 470);
            this.serviceModeTab.TabIndex = 0;
            this.serviceModeTab.Text = "Service mode";
            this.serviceModeTab.UseVisualStyleBackColor = true;
            // 
            // readSettingsBtn
            // 
            this.readSettingsBtn.Location = new System.Drawing.Point(13, 110);
            this.readSettingsBtn.Name = "readSettingsBtn";
            this.readSettingsBtn.Size = new System.Drawing.Size(145, 42);
            this.readSettingsBtn.TabIndex = 9;
            this.readSettingsBtn.Text = "Read";
            this.readSettingsBtn.UseVisualStyleBackColor = true;
            this.readSettingsBtn.Click += new System.EventHandler(this.readSettingsBtn_Click);
            // 
            // locDataQueryBtn
            // 
            this.locDataQueryBtn.Location = new System.Drawing.Point(194, 220);
            this.locDataQueryBtn.Name = "locDataQueryBtn";
            this.locDataQueryBtn.Size = new System.Drawing.Size(145, 42);
            this.locDataQueryBtn.TabIndex = 8;
            this.locDataQueryBtn.Text = "Query";
            this.locDataQueryBtn.UseVisualStyleBackColor = true;
            this.locDataQueryBtn.Click += new System.EventHandler(this.locDataQueryBtn_Click);
            // 
            // writeSettingsBtn
            // 
            this.writeSettingsBtn.Location = new System.Drawing.Point(194, 110);
            this.writeSettingsBtn.Name = "writeSettingsBtn";
            this.writeSettingsBtn.Size = new System.Drawing.Size(145, 42);
            this.writeSettingsBtn.TabIndex = 7;
            this.writeSettingsBtn.Text = "Write";
            this.writeSettingsBtn.UseVisualStyleBackColor = true;
            this.writeSettingsBtn.Click += new System.EventHandler(this.writeSettingsBtn_Click);
            // 
            // locDataIdCbx
            // 
            this.locDataIdCbx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.locDataIdCbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.locDataIdCbx.DropDownWidth = 300;
            this.locDataIdCbx.FormattingEnabled = true;
            this.locDataIdCbx.Location = new System.Drawing.Point(139, 178);
            this.locDataIdCbx.Name = "locDataIdCbx";
            this.locDataIdCbx.Size = new System.Drawing.Size(200, 36);
            this.locDataIdCbx.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 181);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 28);
            this.label3.TabIndex = 5;
            this.label3.Text = "? LOC_DATA";
            // 
            // rxChIdCbx
            // 
            this.rxChIdCbx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rxChIdCbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.rxChIdCbx.FormattingEnabled = true;
            this.rxChIdCbx.Location = new System.Drawing.Point(155, 6);
            this.rxChIdCbx.Name = "rxChIdCbx";
            this.rxChIdCbx.Size = new System.Drawing.Size(184, 36);
            this.rxChIdCbx.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 28);
            this.label2.TabIndex = 2;
            this.label2.Text = "Rx channel ID";
            // 
            // txChIdCbx
            // 
            this.txChIdCbx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txChIdCbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txChIdCbx.FormattingEnabled = true;
            this.txChIdCbx.Location = new System.Drawing.Point(155, 48);
            this.txChIdCbx.Name = "txChIdCbx";
            this.txChIdCbx.Size = new System.Drawing.Size(184, 36);
            this.txChIdCbx.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tx channel ID";
            // 
            // dataModeTab
            // 
            this.dataModeTab.Controls.Add(this.resendPeriodEdit);
            this.dataModeTab.Controls.Add(this.isSERModeChb);
            this.dataModeTab.Controls.Add(this.echoerModeChb);
            this.dataModeTab.Controls.Add(this.sendOnceBtn);
            this.dataModeTab.Controls.Add(this.testMessageTxb);
            this.dataModeTab.Controls.Add(this.testMsgLbl);
            this.dataModeTab.Location = new System.Drawing.Point(4, 37);
            this.dataModeTab.Name = "dataModeTab";
            this.dataModeTab.Padding = new System.Windows.Forms.Padding(3);
            this.dataModeTab.Size = new System.Drawing.Size(345, 470);
            this.dataModeTab.TabIndex = 1;
            this.dataModeTab.Text = "Data mode";
            this.dataModeTab.UseVisualStyleBackColor = true;
            // 
            // resendPeriodEdit
            // 
            this.resendPeriodEdit.Location = new System.Drawing.Point(226, 94);
            this.resendPeriodEdit.Maximum = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.resendPeriodEdit.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.resendPeriodEdit.Name = "resendPeriodEdit";
            this.resendPeriodEdit.Size = new System.Drawing.Size(108, 34);
            this.resendPeriodEdit.TabIndex = 7;
            this.resendPeriodEdit.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // isSERModeChb
            // 
            this.isSERModeChb.AutoSize = true;
            this.isSERModeChb.Location = new System.Drawing.Point(8, 96);
            this.isSERModeChb.Name = "isSERModeChb";
            this.isSERModeChb.Size = new System.Drawing.Size(212, 32);
            this.isSERModeChb.TabIndex = 6;
            this.isSERModeChb.Text = "Send-Re-send mode";
            this.isSERModeChb.UseVisualStyleBackColor = true;
            this.isSERModeChb.CheckedChanged += new System.EventHandler(this.isSERModeChb_CheckedChanged);
            // 
            // echoerModeChb
            // 
            this.echoerModeChb.AutoSize = true;
            this.echoerModeChb.Location = new System.Drawing.Point(8, 58);
            this.echoerModeChb.Name = "echoerModeChb";
            this.echoerModeChb.Size = new System.Drawing.Size(192, 32);
            this.echoerModeChb.TabIndex = 5;
            this.echoerModeChb.Text = "Echoer mode only";
            this.echoerModeChb.UseVisualStyleBackColor = true;
            this.echoerModeChb.CheckedChanged += new System.EventHandler(this.echoerModeChb_CheckedChanged);
            // 
            // sendOnceBtn
            // 
            this.sendOnceBtn.Location = new System.Drawing.Point(194, 239);
            this.sendOnceBtn.Name = "sendOnceBtn";
            this.sendOnceBtn.Size = new System.Drawing.Size(140, 46);
            this.sendOnceBtn.TabIndex = 3;
            this.sendOnceBtn.Text = "Send once";
            this.sendOnceBtn.UseVisualStyleBackColor = true;
            this.sendOnceBtn.Click += new System.EventHandler(this.sendOnceBtn_Click);
            // 
            // testMessageTxb
            // 
            this.testMessageTxb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.testMessageTxb.Location = new System.Drawing.Point(8, 199);
            this.testMessageTxb.MaxLength = 127;
            this.testMessageTxb.Name = "testMessageTxb";
            this.testMessageTxb.Size = new System.Drawing.Size(326, 34);
            this.testMessageTxb.TabIndex = 2;
            this.testMessageTxb.TextChanged += new System.EventHandler(this.testMessageTxb_TextChanged);
            // 
            // testMsgLbl
            // 
            this.testMsgLbl.AutoSize = true;
            this.testMsgLbl.Location = new System.Drawing.Point(11, 168);
            this.testMsgLbl.Name = "testMsgLbl";
            this.testMsgLbl.Size = new System.Drawing.Size(125, 28);
            this.testMsgLbl.TabIndex = 1;
            this.testMsgLbl.Text = "Test message";
            this.testMsgLbl.Click += new System.EventHandler(this.testMsgLbl_Click);
            // 
            // commLogToolStrip
            // 
            this.commLogToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.commLogClearBtn,
            this.commLogExportBtn,
            this.toolStripSeparator2,
            this.writeStatisticsBtn});
            this.commLogToolStrip.Location = new System.Drawing.Point(0, 0);
            this.commLogToolStrip.Name = "commLogToolStrip";
            this.commLogToolStrip.Size = new System.Drawing.Size(704, 35);
            this.commLogToolStrip.TabIndex = 1;
            this.commLogToolStrip.Text = "toolStrip1";
            // 
            // commLogClearBtn
            // 
            this.commLogClearBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.commLogClearBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.commLogClearBtn.Image = ((System.Drawing.Image)(resources.GetObject("commLogClearBtn.Image")));
            this.commLogClearBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.commLogClearBtn.Name = "commLogClearBtn";
            this.commLogClearBtn.Size = new System.Drawing.Size(60, 32);
            this.commLogClearBtn.Text = "Clear";
            this.commLogClearBtn.Click += new System.EventHandler(this.commLogClearBtn_Click);
            // 
            // commLogExportBtn
            // 
            this.commLogExportBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.commLogExportBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.commLogExportBtn.Image = ((System.Drawing.Image)(resources.GetObject("commLogExportBtn.Image")));
            this.commLogExportBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.commLogExportBtn.Name = "commLogExportBtn";
            this.commLogExportBtn.Size = new System.Drawing.Size(73, 32);
            this.commLogExportBtn.Text = "Export";
            this.commLogExportBtn.Click += new System.EventHandler(this.commLogExportBtn_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 35);
            // 
            // writeStatisticsBtn
            // 
            this.writeStatisticsBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.writeStatisticsBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.writeStatisticsBtn.Image = ((System.Drawing.Image)(resources.GetObject("writeStatisticsBtn.Image")));
            this.writeStatisticsBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.writeStatisticsBtn.Name = "writeStatisticsBtn";
            this.writeStatisticsBtn.Size = new System.Drawing.Size(143, 32);
            this.writeStatisticsBtn.Text = "Write statistics";
            this.writeStatisticsBtn.Click += new System.EventHandler(this.writeStatisticsBtn_Click);
            // 
            // commLogTxb
            // 
            this.commLogTxb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.commLogTxb.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.commLogTxb.Location = new System.Drawing.Point(3, 38);
            this.commLogTxb.Name = "commLogTxb";
            this.commLogTxb.ReadOnly = true;
            this.commLogTxb.Size = new System.Drawing.Size(689, 469);
            this.commLogTxb.TabIndex = 0;
            this.commLogTxb.Text = "";
            this.commLogTxb.TextChanged += new System.EventHandler(this.commLogTxb_TextChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1061, 579);
            this.Controls.Add(this.mainSplit);
            this.Controls.Add(this.mainToolStrip);
            this.Controls.Add(this.mainStatusStrip);
            this.Name = "MainForm";
            this.Text = "NATRIX Host";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.mainStatusStrip.ResumeLayout(false);
            this.mainStatusStrip.PerformLayout();
            this.mainToolStrip.ResumeLayout(false);
            this.mainToolStrip.PerformLayout();
            this.mainSplit.Panel1.ResumeLayout(false);
            this.mainSplit.Panel2.ResumeLayout(false);
            this.mainSplit.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainSplit)).EndInit();
            this.mainSplit.ResumeLayout(false);
            this.leftTabCtrl.ResumeLayout(false);
            this.serviceModeTab.ResumeLayout(false);
            this.serviceModeTab.PerformLayout();
            this.dataModeTab.ResumeLayout(false);
            this.dataModeTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resendPeriodEdit)).EndInit();
            this.commLogToolStrip.ResumeLayout(false);
            this.commLogToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip mainStatusStrip;
        private System.Windows.Forms.ToolStrip mainToolStrip;
        private System.Windows.Forms.ToolStripButton connectionBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton infoBtn;
        private System.Windows.Forms.SplitContainer mainSplit;
        private System.Windows.Forms.TabControl leftTabCtrl;
        private System.Windows.Forms.TabPage serviceModeTab;
        private System.Windows.Forms.TabPage dataModeTab;
        private System.Windows.Forms.ComboBox locDataIdCbx;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox rxChIdCbx;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox txChIdCbx;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button locDataQueryBtn;
        private System.Windows.Forms.Button writeSettingsBtn;
        private System.Windows.Forms.Button readSettingsBtn;
        private System.Windows.Forms.ToolStripStatusLabel statusLbl;
        private System.Windows.Forms.ToolStrip commLogToolStrip;
        private System.Windows.Forms.ToolStripButton commLogClearBtn;
        private System.Windows.Forms.ToolStripButton commLogExportBtn;
        private System.Windows.Forms.RichTextBox commLogTxb;
        private System.Windows.Forms.TextBox testMessageTxb;
        private System.Windows.Forms.Label testMsgLbl;
        private System.Windows.Forms.Button sendOnceBtn;
        private System.Windows.Forms.CheckBox echoerModeChb;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton writeStatisticsBtn;
        private System.Windows.Forms.ToolStripButton settingsBtn;
        private System.Windows.Forms.CheckBox isSERModeChb;
        private System.Windows.Forms.NumericUpDown resendPeriodEdit;
    }
}

