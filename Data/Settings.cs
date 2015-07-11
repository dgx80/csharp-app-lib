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


        public Settings()
        : base()
        {
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
    }
}
