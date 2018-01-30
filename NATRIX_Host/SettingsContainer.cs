using System;
using System.Text;

namespace NATRIX_Host
{
    [Serializable]
    public class SettingsContainer
    {
        #region Properties

        public string RedLINEPortName;                     

        #endregion

        #region Constructor

        public SettingsContainer()
        {
            SetDefaults();
        }

        #endregion

        #region Methods

        public void SetDefaults()
        {
            RedLINEPortName = "COM1";           
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Settings:\r\nREDNodePortName: {0}\r\n", RedLINEPortName);            

            return sb.ToString();
        }

        #endregion
    }
}
