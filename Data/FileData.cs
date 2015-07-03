using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppLib.Formatter;
using System.Reflection;
using System.IO;

namespace AppLib.Data
{
    public class FileData
    {
        private string m_sFilename = "";
        private XMLFormatter m_xmlFormatter;

        public FileData()
        {
            m_xmlFormatter = new XMLFormatter();
        }
        /**
         * @return false is load nothing
         * 
         */
        public bool Load(string sFilename)
        {
            m_sFilename = sFilename;

            if (File.Exists(m_sFilename))
            {
                MethodInfo method = m_xmlFormatter.GetType().GetMethod("load");
                MethodInfo genericMethod = method.MakeGenericMethod(this.GetType());
                object[] parametersArray = new object[] { m_sFilename };
                FileData result = (FileData)genericMethod.Invoke(m_xmlFormatter, parametersArray);
                Type t = result.GetType();
                foreach (PropertyInfo propertyInfo in t.GetProperties())
                {
                    if (propertyInfo.CanRead)
                    {
                        object value = propertyInfo.GetValue(result, null);
                        propertyInfo.SetValue(this, value, null);
                    }
                }
                return true;
            }
            return false;
        }
        public void write()
        {
            MethodInfo method = m_xmlFormatter.GetType().GetMethod("write");
            MethodInfo genericMethod = method.MakeGenericMethod(this.GetType());
            object[] parametersArray = new object[] { m_sFilename, this };
            genericMethod.Invoke(m_xmlFormatter, parametersArray);
        }

        #region ACCESSORS

        public string FILENAME
        {
            get
            {
                return m_sFilename;
            }
            set
            {
                m_sFilename = value;
            }
        }

        #endregion
    }
}
