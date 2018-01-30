using System;
using System.IO;
using System.Text;

namespace NATRIX_Host
{
    public enum LOC_DATA_IDs
    {
        LOC_DATA_DEVICE_INFO = 0,
        LOC_DATA_MAX_SUBSCRIBERS = 2,
        LOC_DATA_PRESSURE_RATING = 6,
        LOC_DATA_UNKNOWN
    }

    public enum DEVICE_TYPE
    {
        RedBASE,
        RedNODE,
        RedNAV,
        RedGTR,
        RedLINE,
        Unknown
    }

    public enum LOC_ERR_IDs
    {
        NO_ERROR = 0,
        INVALID_SYNTAX = 1,
        UNSUPPORTED = 2,
        TRANSMITTER_BUSY = 3,
        ARGUMENT_OUT_OF_RANGE = 4,
        INVALID_OPERATION = 5,
        UNKNOWN_FIELD_ID = 6,
        VALUE_UNAVAILIBLE = 7,
        RECEIVER_BUSY = 8,
        LOC_ERR_UNKNOWN
    }

    public static class Utils
    {
        public const int MAX_SUBSCRIBERS = 24;


        #region Methods

        public static string BCDVersionToStr(int versionData)
        {
            return string.Format("{0}.{1}", (versionData >> 0x08).ToString(), (versionData & 0xff).ToString("X2"));
        }


        public static string GetDateDirTree(string appPath, string targetPath, DateTime dateFix)
        {
            string dateFolderName = string.Format("{0}_{1:00}_{2:00}", dateFix.Year, dateFix.Month, dateFix.Day);
            return Path.Combine(Path.Combine(Path.GetDirectoryName(appPath), targetPath), dateFolderName);
        }

        public static string GetTimeFileName(DateTime timeFix, string extension)
        {
            return string.Format("{0:00}-{1:00}-{2:00}.{3}",
                timeFix.Hour,
                timeFix.Minute,
                timeFix.Second,
                extension);
        }

        public static string ToSafeString(byte[] data)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                if ((data[i] >= 32) && (data[i] <= 125))
                {
                    sb.Append(Encoding.ASCII.GetString(data, i, 1));
                }
                else
                {
                    sb.AppendFormat("0x{0:X2} ", data[i]); 
                }
            }

            return sb.ToString();
        }
        
        #endregion
    }

}
