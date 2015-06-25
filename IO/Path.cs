using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppLib.IO
{
    class Path
    {
        private string m_appData;

        public Path(Infos.ProjectInfo projectInfo)
        {
            initAppData(projectInfo);
        }

        #region INIT

        private void initAppData(Infos.ProjectInfo projectInfo)
        {
            m_appData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            if (projectInfo.COMPANY_NAME != "")
            {
                m_appData += @"\" + projectInfo.COMPANY_NAME;
            }
            if (projectInfo.APPLICATION_NAME == "")
            {
                throw new Exception("Application name is missing in " + this.GetType().Name);
            }
            m_appData += @"\" + projectInfo.APPLICATION_NAME + @"\";
        }

        #endregion

        #region PROPERTIES

        public string APP_DATA
        {
            get
            {
                return m_appData;
            }
        }

        #endregion

    }
}
