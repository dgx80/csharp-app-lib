using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppLib.Components;
using System.Windows.Forms;
using System.IO;

namespace AppLib.Forms
{
    public class ApplicationForm : ApplicationFormInterface
    {
        #region ATTRIBUTES

        private ApplicationManager m_applicationManager;
        private Components.ProjectMenuStrip m_projectMenuStrip;
        private Forms.ProgressBarDialog m_progressBar;
        private ApplicationMainForm m_applicationMainForm;
        private AppFormContainer m_appFormContainer;

        #endregion

        #region CONSTRUCTOR

        
        public ApplicationForm(
            ApplicationManager applicationManager,
            AppFormContainer mainForm,
            System.Windows.Forms.MenuStrip menuStrip
            ) 
        {
            m_appFormContainer = mainForm;
            m_applicationMainForm = new ApplicationMainForm(this, mainForm);
            string ext = applicationManager.APP_DATA.SETTINGS.getProjectFileExtension();
            m_projectMenuStrip = new ProjectMenuStrip(this, mainForm, menuStrip, ext);
            m_progressBar = new Forms.ProgressBarDialog();
            m_applicationManager = applicationManager;
        }

        #endregion

        #region EVENTS
        /// <summary>
        /// 
        /// </summary>
        public void onOnload()
        {
            m_progressBar.Show();
            m_appFormContainer.onOnload();
        }
        /// <summary>
        /// 
        /// </summary>
        public void onPostload()
        {
            m_progressBar.Close();
            m_appFormContainer.onPostload();
        }
        /// <summary>
        /// when a new project is called..from menustrip of shortcut
        /// </summary>
        public void onNewProject()
        {
            string fullName = APP_SAVE_FILE_DIALOG.askAFileName();
            if (fullName != "")
            {
                m_applicationManager.onNewProjectFile(fullName);
            }
            m_appFormContainer.onNewProject();
        }
        /// <summary>
        /// when you open a project file
        /// </summary>
        public void onOpenProject()
        {
            string fullName = APP_OPEN_FILE_DIALOG.askAFileName();
            if (fullName != "")
            {
                m_applicationManager.onOpenProjectFile(fullName);
            }
            m_appFormContainer.onOpenProject();
        }

        /// <summary>
        /// when you open a project file
        /// </summary>
        public void onSaveProject()
        {
            if (m_applicationManager.APP_DATA.CURRENT_PROJECT_NAME == "")
            {
                this.onNewProject();
                return;
            }
            m_applicationManager.saveProject();
            m_appFormContainer.onSaveProject();
        }
        #endregion

        #region AUTHORIZATION
        /// <summary>
        /// when you quit application
        /// </summary>
        /// <returns>true if close accepted</returns>
        public bool isQuitApplicationAccepted()
        {
            bool bClose = true;
            if (m_applicationManager.APP_DATA.isDataChanged())
            {
                DialogResult result = MessageBox.Show("The data is change, do you want to save", "Save", MessageBoxButtons.YesNoCancel);
                switch (result)
                {
                    case DialogResult.Yes:
                        m_applicationManager.APP_DATA.save();
                        break;
                    case DialogResult.No:
                        break;
                    case DialogResult.Cancel:
                        bClose = false;
                        break;
                }
            }
            return bClose;
        }

        #endregion

        #region UPDATE



        #endregion


        #region PROPERTIES

        public ApplicationMainForm APP_MAIN_FORM
        {
            get
            {
                return m_applicationMainForm;
            }
            set
            {
                m_applicationMainForm = value;
            }
        }

        public ApplicationSaveFileDialog APP_SAVE_FILE_DIALOG
        {
            get
            {
                string ext = m_applicationManager.APP_DATA.SETTINGS.getProjectFileExtension();
                string currentProjectName = m_applicationManager.APP_DATA.CURRENT_PROJECT_NAME;
                return new ApplicationSaveFileDialog(ext, currentProjectName);
            }
        }

        public ApplicationOpenFileDialog APP_OPEN_FILE_DIALOG
        {
            get
            {
                string ext = m_applicationManager.APP_DATA.SETTINGS.getProjectFileExtension();
                string currentProjectName = m_applicationManager.APP_DATA.CURRENT_PROJECT_NAME;
                return new ApplicationOpenFileDialog(ext, currentProjectName);
            }
        }
        #endregion

        #region UTILITY



        #endregion
    }
}
