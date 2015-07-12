using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace AppLib.Formatter
{
    class XMLFormatter
    {
        #region XML

        public T load<T>(string sFilename) where T : new()
        {
            T o = new T();
            XmlSerializer xs = new XmlSerializer(o.GetType());

            if (File.Exists(sFilename))
            {
                using (StreamReader fr = new StreamReader(sFilename))
                {
                    T data = (T)xs.Deserialize(fr);
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
            return o;
        }

        public void write<T>(string sFilename, object file)
        {
            if (sFilename == "")
            {
                return;
            }

            XmlSerializer xs = new XmlSerializer(file.GetType());
            using (StreamWriter fw = new StreamWriter(sFilename))
            {
                xs.Serialize(fw, file);
            }
        }
        #endregion
    }
}
