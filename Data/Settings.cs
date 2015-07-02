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
        public bool isCurrentProjectExist()
        {
            if (m_sCurrentProjectPath != "")
            {
                if (File.Exists(m_sCurrentProjectPath))
                {
                    return true;
                }
                else
                {
                    m_sCurrentProjectPath = "";
                    this.write();
                }
            }
            return false;
        }
    }
}
