using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Reflection;
using System.Windows.Forms;
using UCNLDrivers;
using UCNLNMEA;
using UCNLUI.Dialogs;

namespace NATRIX_Host
{
    public partial class MainForm : Form
    {
        #region UI invokers

        private void InvokeAppendText(RichTextBox rtb, string text)
        {
            if (rtb.InvokeRequired)
                rtb.Invoke((MethodInvoker)delegate { rtb.AppendText(text); });
            else
                rtb.AppendText(text);
        }

        #endregion

        #region Properties

        NMEASerialPort port;
        PrecisionTimer timer;

        TSLogProvider logger;
        SettingsProviderXML<SettingsContainer> settingsProvider;

        string settingsFilePath;
        string logPath;
        string logFilePath;

        bool isRestart = false;



        #region UI properties

        int txChId
        {
            get
            {
                return int.Parse(txChIdCbx.SelectedItem.ToString());
            }
            set
            {
                int idx = txChIdCbx.Items.IndexOf(value.ToString());
                if (idx >= 0)
                    txChIdCbx.SelectedIndex = idx;
            }
        }

        int rxChId
        {
            get
            {
                return int.Parse(rxChIdCbx.SelectedItem.ToString());
            }
            set
            {
                int idx = rxChIdCbx.Items.IndexOf(value.ToString());
                if (idx >= 0)
                    rxChIdCbx.SelectedIndex = idx;
            }
        }

        LOC_DATA_IDs locDataID
        {
            get
            {
                return (LOC_DATA_IDs)Enum.Parse(typeof(LOC_DATA_IDs), locDataIdCbx.SelectedItem.ToString());
            }
            set
            {
                int idx = locDataIdCbx.Items.IndexOf(value.ToString());
                if (idx >= 0)
                    locDataIdCbx.SelectedIndex = idx;
            }
        }
        

        bool isEchoer
        {
            get
            {
                return echoerModeChb.Checked && echoerModeChb.Enabled;
            }
            set
            {
                echoerModeChb.Checked = value;
            }
        }

        bool isSERMode
        {
            get
            {
                return isSERModeChb.Checked && isSERModeChb.Enabled;
            }
            set
            {
                isSERModeChb.Checked = value;
            }
        }

        bool isServiceTab = true;

        string msg = string.Empty;

        #endregion

        #region statistics

        int bytesSent = 0;
        int bytesReceived = 0;

        int timCnt = 0;
        int tPeriod
        {
            get
            {
                return Convert.ToInt32(resendPeriodEdit.Value);
            }
            set
            {
                resendPeriodEdit.Value = value;
            }
        }

        #endregion

        #endregion

        #region Constructor

        public MainForm()
        {
            InitializeComponent();            

            #region Paths

            DateTime startTime = DateTime.Now;
            settingsFilePath = Path.ChangeExtension(Application.ExecutablePath, "settings");
            logPath = Utils.GetDateDirTree(Application.ExecutablePath, "LOG", startTime);
            logFilePath = Path.Combine(logPath, Utils.GetTimeFileName(startTime, "log"));

            if (!Directory.Exists(logPath))
                Directory.CreateDirectory(logPath);

            #endregion

            #region logger

            logger = new TSLogProvider(logFilePath);
            logger.WriteStart();

            #endregion

            #region settings

            bool settingsOk = false;
            settingsProvider = new SettingsProviderXML<SettingsContainer>();
            settingsProvider.isSwallowExceptions = false;

            try
            {
                settingsProvider.Load(settingsFilePath);
                logger.Write(settingsProvider.Data.ToString());
            }
            catch (Exception ex)
            {
                logger.Write(ex);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);                 
            }

            if (!settingsOk)
            {
                try
                {
                    settingsProvider.Save(settingsFilePath);
                }
                catch (Exception ex)
                {
                    logger.Write(ex);
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);                 
                }
            }

            #endregion

            #region UI

            testMessageTxb.Text = GenerateTestString();
            locDataIdCbx.Items.AddRange(Enum.GetNames(typeof(LOC_DATA_IDs)));
            locDataIdCbx.SelectedIndex = 0;

            List<string> subIDs = new List<string>();
            for (int i = 0; i < Utils.MAX_SUBSCRIBERS; i++)
                subIDs.Add(i.ToString());

            txChIdCbx.Items.AddRange(subIDs.ToArray());
            rxChIdCbx.Items.AddRange(subIDs.ToArray());

            txChId = 0;
            rxChId = 0;

            mainSplit.Enabled = false;

            #endregion

            #region port

            port = new NMEASerialPort(new SerialPortSettings(settingsProvider.Data.RedLINEPortName, 
                BaudRate.baudRate9600, 
                Parity.None, 
                DataBits.dataBits8, 
                StopBits.One, 
                Handshake.None));
            port.NewNMEAMessage += new EventHandler<NewNMEAMessageEventArgs>(port_NewNMEAMessage);
            port.PortError += new EventHandler<SerialErrorReceivedEventArgs>(port_Error);
            port.RawDataReceived += new EventHandler<RawDataReceivedEventArgs>(port_RawData);            

            #endregion

            #region timer

            timer = new PrecisionTimer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Period = 1000;            

            #endregion

            #region NMEA

            NMEAParser.AddManufacturerToProprietarySentencesBase(ManufacturerCodes.TNT);

            NMEAParser.AddProprietarySentenceDescription(ManufacturerCodes.TNT, "!", "c--c,x,c--c,x,x,c--c"); // IC_D2H_DEV_INFO_VAL    $PTNT!,sys_moniker,sys_ver,dev_type,core_moniker,core_ver,dev_serial_num
            NMEAParser.AddProprietarySentenceDescription(ManufacturerCodes.TNT, "0", "x");                    // IC_D2H_ACK             $PTNT0,errCode 
            
            NMEAParser.AddProprietarySentenceDescription(ManufacturerCodes.TNT, "1", "x,x");                  // IC_H2D_FLD_GET         $PTNT1,fldID,reserved
            NMEAParser.AddProprietarySentenceDescription(ManufacturerCodes.TNT, "2", "x,x");                  // IC_H2D_FLD_SET         $PTNT2,fldID,fldNewValue
            NMEAParser.AddProprietarySentenceDescription(ManufacturerCodes.TNT, "3", "x,x");                  // IC_D2H_FLD_VAL         $PTNT3,fldID,fldValue

            NMEAParser.AddProprietarySentenceDescription(ManufacturerCodes.TNT, "4", "x,x");                  // IC_H2D_LOC_DATA_GET    $PTNT4,locDataID,reserved
            NMEAParser.AddProprietarySentenceDescription(ManufacturerCodes.TNT, "5", "x,x.x");                // IC_D2H_LOC_DATA_VAL    $PTNT5,locDataID,locDataValue

            NMEAParser.AddProprietarySentenceDescription(ManufacturerCodes.TNT, "6", "x,x");                  // IC_H2D_ACT_INVOKE      $PTNT6,actionID,reserved

            NMEAParser.AddProprietarySentenceDescription(ManufacturerCodes.TNT, "7", "x,x");                  // IC_H2D_SETTINGS_WRITE  $PTNT7,rxChID,txChID
            NMEAParser.AddProprietarySentenceDescription(ManufacturerCodes.TNT, "8", "x");                    // IC_H2D_SETTINGS_READ   $PTNT8,reserved
            NMEAParser.AddProprietarySentenceDescription(ManufacturerCodes.TNT, "9", "x,x");                  // IC_D2H_SETTINGS        $PTNT9,rxChID,txChID

            NMEAParser.AddProprietarySentenceDescription(ManufacturerCodes.TNT, "P", "x,x.x");                // IC_H2D_SETVAL          $PTNTP,valueID,value          

            #endregion
        }

        #endregion

        #region Methods
        
        #region Custom NMEA parsers

        private void Parse_DEVICE_INFO(object[] parameters)
        {
            // $PTNT!,sys_moniker,sys_ver,dev_type,core_moniker,core_ver,dev_serial_num
            InvokeAppendText(commLogTxb, logger.Write(string.Format("[Hint]\r\nDEV: {0}\r\nSYS: {1} v{2}\r\nCRE: {3} v{4}\r\nS/N: {5}", 
                    (DEVICE_TYPE)(int)parameters[4], (string)parameters[0], Utils.BCDVersionToStr((int)parameters[1]),
                    (string)parameters[2], Utils.BCDVersionToStr((int)parameters[3]), (string)parameters[5])));
        }

        private void Parse_ACK(object[] parameters)
        {            
            InvokeAppendText(commLogTxb, logger.Write(string.Format("[Hint] {0}", (LOC_ERR_IDs)(int)parameters[0])));
        }

        private void Parse_LOC_DATA_VAL(object[] parameters)
        {
            InvokeAppendText(commLogTxb, logger.Write(string.Format("[Hint] {0} = {1:F00}", (LOC_DATA_IDs)(int)parameters[0], (double)parameters[1])));
        }

        private void Parse_SETTINGS(object[] parameters)
        {
            // $PTNT9,rxChID,txChID,isRTX
            InvokeAppendText(commLogTxb, logger.Write(string.Format("[Hint]\r\nRxChID = {0}\r\nTxChID = {1}", (int)parameters[0], (int)parameters[1])));

            Invoke((MethodInvoker)delegate
            { 
                rxChId = (int)parameters[0]; 
                txChId = (int)parameters[1];               
            });            
        }

        #endregion

        private string GenerateTestString()
        {
            DateTime now = DateTime.Now;
            return string.Format("[NATRIX_TEST_{0:00}-{1:00}-{2:0000}]", now.Day, now.Month, now.Year);
        }

        private void Send(string msg)
        {
            try
            {
                port.SendData(msg);
                if (!isServiceTab) bytesSent += msg.Length;
                InvokeAppendText(commLogTxb, logger.Write(string.Format("<< {0}", msg)));
            }
            catch (Exception ex)
            {
                InvokeAppendText(commLogTxb, logger.Write(ex));
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Send(byte[] data)
        {
            try
            {
                port.SendRaw(data);
                if (!isServiceTab) bytesSent += data.Length;
                InvokeAppendText(commLogTxb, logger.Write(string.Format("<< {0}", Utils.ToSafeString(data))));               
            }
            catch (Exception ex)
            {                
                InvokeAppendText(commLogTxb, logger.Write(ex));               
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion        

        #region Handlers

        #region UI

        #region mainForm

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = (!isRestart) && (MessageBox.Show("Close application?", "Question", MessageBoxButtons.YesNo) != System.Windows.Forms.DialogResult.Yes);
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            logger.Write("Closing...");
            logger.FinishLog();

            if (timer.IsRunning) timer.Stop();
            if (port.IsOpen)
            {
                try
                {
                    port.Close();
                }
                catch
                {

                }
            }            
        }

        #endregion

        #region mainToolStrip

        private void connectionBtn_Click(object sender, EventArgs e)
        {
            if (port.IsOpen)
            {
                try
                {
                    port.Close();
                }
                catch (Exception ex)
                {
                    var lStr = logger.Write(ex);
                    InvokeAppendText(commLogTxb, lStr);
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                try
                {
                    port.Open();
                }
                catch (Exception ex)
                {
                    var lStr = logger.Write(ex);
                    InvokeAppendText(commLogTxb, lStr);                 
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (port.IsOpen)
            {
                connectionBtn.Checked = true;
                connectionBtn.Text = "Disconnect";
                settingsBtn.Enabled = false;
                mainSplit.Enabled = true;
                statusLbl.Text = string.Format("State: Connected to {0}", settingsProvider.Data.RedLINEPortName);
            }
            else
            {
                connectionBtn.Checked = false;
                connectionBtn.Text = "Connect";
                settingsBtn.Enabled = true;
                mainSplit.Enabled = false;
                statusLbl.Text = "State: Disconnected";
            }
        }

        private void settingsBtn_Click(object sender, EventArgs e)
        {
            using (SettingsEditor sDialog = new SettingsEditor())
            {
                sDialog.Value = settingsProvider.Data;

                if (sDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    settingsProvider.Data = sDialog.Value;
                    bool isSaved = false;

                    try
                    {
                        settingsProvider.Save(settingsFilePath);
                        isSaved = true;
                    }
                    catch (Exception ex)
                    {
                        logger.Write(ex);
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    if (isSaved)
                    {
                        if (MessageBox.Show("Settings saved. Restart application to apply?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                        {
                            isRestart = true;
                            Application.Restart();
                        }
                    }
                }
            }
        }

        private void infoBtn_Click(object sender, EventArgs e)
        {
            using (AboutBox aDialog = new AboutBox())
            {
                aDialog.ApplyAssembly(Assembly.GetExecutingAssembly());
                aDialog.Weblink = "http://www.unavlab.com//";
                aDialog.ShowDialog();
            }
        }

        #endregion       

        #region leftTabCtrl

        private void leftTabCtrl_SelectedIndexChanged(object sender, EventArgs e)
        {
            isServiceTab = (leftTabCtrl.SelectedIndex == 0);
        }

        #endregion

        #region serviceModeTab

        private void readSettingsBtn_Click(object sender, EventArgs e)
        {
            // $PTNT8,0
            var cStr = NMEAParser.BuildProprietarySentence(ManufacturerCodes.TNT, "8", new object[] { 0 });
            Send(cStr);
        }

        private void writeSettingsBtn_Click(object sender, EventArgs e)
        {
            // $PTNT7,rxChID,txChID,isRTX
            var cStr = NMEAParser.BuildProprietarySentence(ManufacturerCodes.TNT, "7", new object[] { rxChId, txChId });
            Send(cStr);
        }

        private void locDataQueryBtn_Click(object sender, EventArgs e)
        {
            // $PTNT4,locDataID,reserved
            var cStr = NMEAParser.BuildProprietarySentence(ManufacturerCodes.TNT, "4", new object[] { (int)locDataID, 0 });
            Send(cStr);
        }

        #endregion

        #region dataModeTab

        private void testMsgLbl_Click(object sender, EventArgs e)
        {
            testMessageTxb.Text = GenerateTestString();
        }

        private void sendOnceBtn_Click(object sender, EventArgs e)
        {            
                Send(testMessageTxb.Text);         
        }        

        private void echoerModeChb_CheckedChanged(object sender, EventArgs e)
        {
            if (isEchoer)
            {                
                isSERModeChb.Enabled = false;
                testMessageTxb.Enabled = false;
                testMsgLbl.Enabled = false;
                sendOnceBtn.Enabled = false;
            }
            else
            {   
                isSERModeChb.Enabled = true;
                testMessageTxb.Enabled = true;
                testMsgLbl.Enabled = true;
                sendOnceBtn.Enabled = true;
            }
        }

        private void isSERModeChb_CheckedChanged(object sender, EventArgs e)
        {
            if (isSERMode)
            {
                echoerModeChb.Enabled = false;
                sendOnceBtn.Enabled = false;
                testMessageTxb.Enabled = false;

                timCnt = 0;
                timer.Start();
            }
            else
            {
                timer.Stop();
                testMessageTxb.Enabled = true;
                echoerModeChb.Enabled = true;
                sendOnceBtn.Enabled = true;
            }
        }

        #endregion        

        #region commLogToolStrip

        private void commLogClearBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Clear history?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                commLogTxb.Clear();
                bytesReceived = 0;
                bytesSent = 0;
            }
        }

        private void commLogExportBtn_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sDialog = new SaveFileDialog())
            {
                sDialog.Title = "Export history to a text file...";
                sDialog.Filter = "Text files (*.txt)|*.txt";
                sDialog.FileName = Utils.GetTimeFileName(DateTime.Now, "txt");
                sDialog.DefaultExt = "txt";

                if (sDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    try
                    {
                        File.WriteAllText(sDialog.FileName, commLogTxb.Text);
                    }
                    catch (Exception ex)
                    {
                        logger.Write(ex);
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void writeStatisticsBtn_Click(object sender, EventArgs e)
        {
            commLogTxb.AppendText(string.Format("\r\n{0} bytes sent, {1} bytes received.\r\n", bytesSent, bytesReceived));
        }

        #endregion

        #endregion

        #region timer

        private void timer_Tick(object sender, EventArgs e)
        {
            if (++timCnt > tPeriod)
            {
                timCnt = 0;
                Send(testMessageTxb.Text);
            }
        }

        #endregion

        #region port

        private void port_NewNMEAMessage(object sender, NewNMEAMessageEventArgs e)
        {
            InvokeAppendText(commLogTxb, logger.Write(string.Format(">> {0}", e.Message)));
            try
            {
                var parseResult = NMEAParser.Parse(e.Message);                

                if (parseResult is NMEAProprietarySentence)
                {
                    NMEAProprietarySentence pSentence = (parseResult as NMEAProprietarySentence);

                    if (pSentence.Manufacturer == ManufacturerCodes.TNT)
                    {
                        if (pSentence.SentenceIDString == "!") Parse_DEVICE_INFO(pSentence.parameters);
                        else if (pSentence.SentenceIDString == "0") Parse_ACK(pSentence.parameters);
                        else if (pSentence.SentenceIDString == "5") Parse_LOC_DATA_VAL(pSentence.parameters);                        
                        else if (pSentence.SentenceIDString == "9") Parse_SETTINGS(pSentence.parameters);
                        else { InvokeAppendText(commLogTxb, logger.Write(string.Format("ERROR: Unsupported sentence: \"{0}\"", pSentence.SentenceIDString))); }
                    }
                    else { InvokeAppendText(commLogTxb, logger.Write(string.Format("ERROR: Unsupported manufacturer: \"{0}\"", pSentence.Manufacturer))); }
                }
                else { InvokeAppendText(commLogTxb, logger.Write(string.Format("ERROR: Unsupported sentence: \"{0}\"", (parseResult as NMEAStandartSentence).SentenceID))); }
            }
            catch (Exception ex) { InvokeAppendText(commLogTxb, logger.Write(ex)); }
        }

        private void port_Error(object sender, SerialErrorReceivedEventArgs e)
        {            
            InvokeAppendText(commLogTxb, logger.Write(string.Format("ERROR: {0} in {1}", e.EventType.ToString(), settingsProvider.Data.RedLINEPortName)));
        }

        private void port_RawData(object sender, RawDataReceivedEventArgs e)
        {
            if (!isServiceTab)
            {
                bytesReceived += e.Data.Length;
                
                InvokeAppendText(commLogTxb, logger.Write(string.Format(">> {0}", Utils.ToSafeString(e.Data))));

                if (isEchoer)
                    Send(e.Data);
            }
        }

        #endregion                                                

        private void testMessageTxb_TextChanged(object sender, EventArgs e)
        {
            msg = testMessageTxb.Text;
        }

        private void commLogTxb_TextChanged(object sender, EventArgs e)
        {
            commLogTxb.ScrollToCaret();
        }

        #endregion        
    }
}
