﻿using System;
using System.IO;
using System.Xml.Serialization;

namespace NATRIX_Host
{   
    public class SettingsProviderXML<T> : SettingsProvider<T> where T : class, new()
    {
        #region Mehtods

        public override void Load(string fileName)
        {
            FileStream fStream;
            try
            {
                fStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));

                try
                {
                    Data = (T)xmlSerializer.Deserialize(fStream);
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    fStream.Close();
                }
            }
            catch (Exception)
            {
                Data = new T();

                if (!isSwallowExceptions)
                    throw;
            }
        }

        public override void Save(string fileName)
        {
            FileStream fStream;
            try
            {
                fStream = new FileStream(fileName, FileMode.Create, FileAccess.ReadWrite);
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));

                try
                {
                    xmlSerializer.Serialize(fStream, Data);
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    fStream.Close();
                }
            }
            catch (Exception)
            {
                if (!isSwallowExceptions)
                    throw;
            }
        }

        #endregion
    }
}
