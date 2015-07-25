using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppLib.Data;
using System.Reflection;
using System.IO;
using AppLib.Components;
using AppLib.Infos;

namespace AppLib
{
    public class ApplicationManager
    {

        #region VARIABLES

        private Settings m_setting;        
        private Project m_project;
        private Components.ProjectMenuStrip m_projectMenuStrip;
        private ApplicationPathInfo m_applicationPathInfo;
        
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
            m_applicationPathInfo = new ApplicationPathInfo(
                new Infos.ProjectInfo(companyName, applicationName),
                "settings.xml"
                );
            string fileName = APP_PATH_INFO.APP_DATA_INFO.FULL_PATH;
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

        #region PROPERTIES

        public ApplicationPathInfo APP_PATH_INFO
        {
            get
            {
                return m_applicationPathInfo;
            }
        }

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

        #region CALLBACK
        public void onNewProjectFile(string fileName)
        {
            string a = "";
        }
        #endregion
        #region FORM
        /// <summary>
        /// add automatically generic mecanic to create, open and close a project file
        /// </summary>
        /// <param name="form"></param>
        /// <param name="menuStrip"></param>
        public void addProjectMenuStripToThisForm(System.Windows.Forms.Form form, System.Windows.Forms.MenuStrip menuStrip)
        {
            m_projectMenuStrip = new ProjectMenuStrip(this, form, menuStrip, m_setting.getProjectFileExtension());
        }
        #endregion
    }
}
