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

        //private Settings m_setting;        
        //private Project m_project;
        private ApplicationData m_applicationData;
        
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
            string settingFileName = APP_PATH_INFO.APP_DATA_INFO.FULL_PATH;
            m_applicationData = new ApplicationData(settings, project, settingFileName);
        }
        #endregion

        /// <summary>
        /// load the project with the current project filename from settings
        /// </summary>
        public void loadProject()
        {
            Forms.ProgressBarDialog progress = new Forms.ProgressBarDialog();
            progress.Show();
            APP_DATA.onLoad();
            progress.Close();
        }
        /// <summary>
        /// save the project with the current project filename from settings
        /// </summary>
        public void saveProject()
        {
            APP_DATA.onSave();
        }

        #region PROPERTIES

        public ApplicationData APP_DATA
        {
            get
            {
                return m_applicationData;
            }
            set
            {
                m_applicationData = value;
            }
        }

        public ApplicationPathInfo APP_PATH_INFO
        {
            get
            {
                return m_applicationPathInfo;
            }
        }

        #endregion

        #region CALLBACK

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        public void onNewProjectFile(string fileName)
        {
            APP_DATA.CURRENT_PROJECT_NAME = fileName;
            APP_DATA.onSave();
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
            string ext = APP_DATA.SETTINGS.getProjectFileExtension();
            m_projectMenuStrip = new ProjectMenuStrip(this, form, menuStrip, ext);
        }
        #endregion
    }
}
