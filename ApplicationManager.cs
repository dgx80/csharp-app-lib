using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppLib.Data;
using System.Reflection;

namespace AppLib
{
    public class ApplicationManager
    {

        #region VARIABLES

        private IO.Path m_path;
        private Infos.ProjectInfo m_projectInfo;
        private Settings m_setting;

        #endregion


        #region CONSTRUCTOR

        public ApplicationManager(Settings settings, Project project, string companyName, string applicationName)
        {
            m_projectInfo = new Infos.ProjectInfo(companyName, applicationName);
            m_path = new IO.Path(m_projectInfo);
            string filename = m_path.APP_DATA + "settings.xml";
            m_setting = settings;
            m_setting.FILENAME = filename;
            m_setting.Load();
            //maintenant il faut load le projet courant sil y en a un
        }
        #endregion

        public void load()
        {
            
        }
        #region PROPERTIES

        #endregion
    }
}
