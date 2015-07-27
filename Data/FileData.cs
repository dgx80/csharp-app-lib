using System;
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
        /// <summary>
        /// Load Data with XMLFormatter
        /// </summary>
        /// <value>
        /// This function try to load this file with the XMLFormatter
        /// </value>
        /// <param name="sFilename"></param>
        /// <returns>
        /// false is load nothing
        /// </returns>
        public bool Load(string sFilename)
        {
            FILENAME = sFilename;

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
        /// <summary>
        /// Write Data with XMLFormatter
        /// </summary>
        public void write()
        {
            MethodInfo method = m_xmlFormatter.GetType().GetMethod("write");
            MethodInfo genericMethod = method.MakeGenericMethod(this.GetType());
            object[] parametersArray = new object[] { m_sFilename, this };
            genericMethod.Invoke(m_xmlFormatter, parametersArray);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>true if data changed</returns>
        public bool isDataChanged()
        {
            Type type = this.GetType();
            FileData writtenFileData = (FileData)Activator.CreateInstance(type);
            writtenFileData.Load(FILENAME);
            foreach (PropertyInfo mi in type.GetProperties())
            {
                object value1 = mi.GetValue(this, null);
                object value2 = mi.GetValue(writtenFileData, null);
                if (value1.ToString() != value2.ToString())
                {
                    return true;
                }
            }
            return false;
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
