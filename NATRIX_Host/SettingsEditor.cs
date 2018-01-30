using System.IO.Ports;
using System.Windows.Forms;

namespace NATRIX_Host
{
    public partial class SettingsEditor : Form
    {
        #region Properties

        string portName
        {
            get
            {
                if (portNameCbx.SelectedIndex >= 0)
                    return portNameCbx.SelectedItem.ToString();
                else
                    return string.Empty;
            }
            set
            {
                int idx = portNameCbx.Items.IndexOf(value);
                if (idx >= 0)
                    portNameCbx.SelectedIndex = idx;
            }
        }
        
        public SettingsContainer Value
        {
            get
            {
                SettingsContainer result = new SettingsContainer();
                result.RedLINEPortName = portName;
                return result;
            }
            set
            {
                portName = value.RedLINEPortName;
            }
        }

        #endregion

        #region Constructor

        public SettingsEditor()
        {
            InitializeComponent();

            portNameCbx.Items.AddRange(SerialPort.GetPortNames());
            if (portNameCbx.Items.Count > 0) portNameCbx.SelectedIndex = 0;
        }

        #endregion
    }
}
