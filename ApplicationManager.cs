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
        /// <summary>
        /// Argument is a base class of Settings and Project that implement variable that you want to serialize
        /// </summary>
        /// <param name="settings"></param>
        /// <param name="project"></param>
        /// <param name="companyName"></param>
        /// <param name="applicationName"></param>
        public ApplicationManager(Settings settings, Project project, string companyName, string applicationName)
        {
            m_projectInfo = new Infos.ProjectInfo(companyName, applicationName);
            m_path = new IO.Path(m_projectInfo);
            string fileName = m_path.APP_DATA + "settings.xml";
            m_setting = settings;
            m_setting.Load(fileName);
            m_project = project;
        }
        #endregion

        /// <summary>
        /// load the project with the current project filename from settings
        /// </summary>
        public void loadProject()
        {
            Forms.ProgressBarDialog progress = new Forms.ProgressBarDialog();
            progress.Show();
            string fileName = m_setting.CURRENT_PROJECT_PATH;
            m_project.Load(fileName);
            progress.Close();
        }
        /// <summary>
        /// save the project with the current project filename from settings
        /// </summary>
        public void saveProject()
        {
            m_project.write();
        }

        public void addProjectMenuToThisForm(System.Windows.Forms.Form form)
        {

        }
        #region PROPERTIES

        /// <summary>
        /// This Property store the current project name
        /// </summary>
        public string CURRENT_PROJECT_NAME
        {
            get
            {
                return m_setting.CURRENT_PROJECT_PATH;
            }
            set
            {
                m_project.FILENAME = value;
                m_setting.CURRENT_PROJECT_PATH = value;
            }
        }
        
        #endregion
    }
}
