using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppLib.Components;
using System.Windows.Forms;
using System.IO;

namespace AppLib.Forms
{
    public class ApplicationForm
    {
        #region ATTRIBUTES

        private ApplicationManager m_applicationManager;
        private Components.ProjectMenuStrip m_projectMenuStrip;
        private Forms.ProgressBarDialog m_progressBar;
        System.Windows.Forms.Form m_form;

        #endregion

        #region CONSTRUCTOR

        
        public ApplicationForm(ApplicationManager applicationManager, System.Windows.Forms.Form form, System.Windows.Forms.MenuStrip menuStrip)
        {
            m_form = form;
            string ext = applicationManager.APP_DATA.SETTINGS.getProjectFileExtension();
            m_projectMenuStrip = new ProjectMenuStrip(this, form, menuStrip, ext);
            m_progressBar = new Forms.ProgressBarDialog();
            m_applicationManager = applicationManager;
        }

        #endregion

        #region EVENTS

        public void onOnload()
        {
            m_progressBar.Show();
        }
        public void onPostload()
        {
            m_progressBar.Close();
        }
        /// <summary>
        /// when a new project is called..from menustrip of shortcut
        /// </summary>
        public void OnNewProject()
        {
            string fullName = APP_SAVE_FILE_DIALOG.askAFileName();
            if (fullName != "")
            {
                m_applicationManager.onNewProjectFile(fullName);
            }
        }
        /// <summary>
        /// when you open a project file
        /// </summary>
        public void OnOpenProject()
        {

        }
        /// <summary>
        /// when you duit application
        /// </summary>
        public void OnQuitApplication()
        {

        }
        #endregion

        #region UPDATE



        #endregion

        #region ACTIONS

        #endregion

        #region PROPERTIES

        public ApplicationSaveFileDialog APP_SAVE_FILE_DIALOG
        {
            get
            {
                string ext = m_applicationManager.APP_DATA.SETTINGS.getProjectFileExtension();
                string currentProjectName = m_applicationManager.APP_DATA.CURRENT_PROJECT_NAME;
                return new ApplicationSaveFileDialog(ext, currentProjectName);
            }
        }

        #endregion

        #region UTILITY



        #endregion
    }
}
