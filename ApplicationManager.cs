using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppLib.Data;
using System.Reflection;
using System.IO;

namespace AppLib
{
    public class ApplicationManager
    {

        #region VARIABLES

        private IO.Path m_path;
        private Infos.ProjectInfo m_projectInfo;
        private Settings m_setting;
        private Project m_project;
        #endregion


        #region CONSTRUCTOR

        public ApplicationManager(Settings settings, Project project, string companyName, string applicationName)
        {
            m_projectInfo = new Infos.ProjectInfo(companyName, applicationName);
            m_path = new IO.Path(m_projectInfo);
            string fileName = m_path.APP_DATA + "settings.xml";
            m_setting = settings;
            m_setting.Load(fileName);
            loadProject(m_setting.CURRENT_PROJECT_PATH);
        }
        #endregion

        public void loadProject(string fileName)
        {
            if (File.Exists(fileName))
            {
                m_project.Load(fileName);
            }
        }
        #region PROPERTIES

        #endregion
    }
}
