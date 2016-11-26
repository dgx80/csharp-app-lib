using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;

namespace AppLib.Data
{
    public class Settings : FileData
    {
        private string m_sCurrentProjectPath = "";
        private string m_sProjectFileExtension;

        /// <summary>
        /// CONSTRUCTOR
        /// </summary>
        /// <param name="sProjectFileExtension"></param>
        public Settings(string sAppName, string sProjectFileExtension = "")
            : base()
        {
            m_sProjectFileExtension = sProjectFileExtension;
            this.FILE_TYPE = sAppName + ".settings";
        }
        /// <summary>
        /// the current fullname of project
        /// </summary>
        public string CURRENT_PROJECT_PATH
        {
            get
            {
                return m_sCurrentProjectPath;
            }
            set
            {
                m_sCurrentProjectPath = value;
            }
        }
        public string getProjectFileExtension()
        {
            return m_sProjectFileExtension;
        }
    }
}
