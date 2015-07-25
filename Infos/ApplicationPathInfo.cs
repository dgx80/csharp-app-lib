using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppLib.Infos
{
    public class ApplicationPathInfo
    {
        private AppDataInfo m_appDataInfo;
        private ProjectInfo m_projectInfo;

        public ApplicationPathInfo(ProjectInfo projectInfo, string settingsFileName)
        {
            m_projectInfo = projectInfo;
            m_appDataInfo = new Infos.AppDataInfo(m_projectInfo, settingsFileName);
        }
        #region PROPERTIES

        public ProjectInfo PROJECT_INFO
        {
            get
            {
                return m_projectInfo;
            }
        }

        public AppDataInfo APP_DATA_INFO
        {
            get
            {
                return m_appDataInfo;
            }
        }
        #endregion

    }
}
