using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Reflection;

namespace AppLib.Data
{
    public abstract class XMLData
    {
        private string m_sFilename = "";

        public XMLData()
        {
        }

        #region XML

        public static T load<T>(string sFilename) where T : new()
        {
            XmlSerializer xs = new XmlSerializer(typeof(Settings));

            if (File.Exists(sFilename))
            {
                using (StreamReader fr = new StreamReader(sFilename))
                {
                    T data = (T)xs.Deserialize(fr);
                    XMLData.filenameReflection<T>(data, sFilename);
                    return data;
                }
            }
            else
            {
                string directory = Path.GetDirectoryName(sFilename);
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }  
            }
            T o = new T();
            XMLData.filenameReflection<T>(o, sFilename);
            return o;
        }

        public void write()
        {
            if (!File.Exists(m_sFilename))
            {
                return;
            }
            XmlSerializer xs = new XmlSerializer(this.GetType());
            using (StreamWriter fw = new StreamWriter(m_sFilename))
            {
                xs.Serialize(fw, this);
            }
        }

        #endregion

        #region UTILITY

        private static void filenameReflection<T>(T o, string sFilename)
        {
            Type type2 = o.GetType();
            MethodInfo methodInfo2 = type2.GetMethod("setFilename");
            object[] parametersArray = new object[] { sFilename };
            methodInfo2.Invoke(o, parametersArray);
        }

        #endregion

        #region ACCESSORS

        public string getFilename()
        {
            return m_sFilename;
        }
        public void setFilename(string value)
        {
            m_sFilename = value;
        }

        #endregion
    }
}
