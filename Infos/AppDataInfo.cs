using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppLib.Infos
{
    public class AppDataInfo
    {
        private string m_sFullPath;

        public AppDataInfo(Infos.ProjectInfo projectInfo, string settingsFileName)
        {
            m_sFullPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            if (projectInfo.COMPANY_NAME != "")
            {
                m_sFullPath += @"\" + projectInfo.COMPANY_NAME;
            }
            if (projectInfo.APPLICATION_NAME == "")
            {
                throw new Exception("Application name is missing in " + this.GetType().Name);
            }
            m_sFullPath += @"\" + projectInfo.APPLICATION_NAME + @"\" + settingsFileName;
        }
        #region PROPERTIES

        public string FULL_PATH
        {
            get
            {
                return m_sFullPath;
            }
        }

        #endregion
    }
}
