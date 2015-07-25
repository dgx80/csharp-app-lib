using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppLib.Components;
using System.Windows.Forms;

namespace AppLib.Forms
{
    public class ApplicationForm
    {
        #region ATTRIBUTES

        private ApplicationManager m_applicationManager;
        private Components.ProjectMenuStrip m_projectMenuStrip;
        private Forms.ProgressBarDialog m_progressBar;

        #endregion

        #region CONSTRUCTOR

        
        public ApplicationForm(ApplicationManager applicationManager, System.Windows.Forms.Form form, System.Windows.Forms.MenuStrip menuStrip)
        {
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
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.DefaultExt = m_applicationManager.APP_DATA.SETTINGS.getProjectFileExtension();
            sfd.AddExtension = true;
            string s = m_applicationManager.APP_DATA.CURRENT_PROJECT_NAME;

            if (s != "")
            {
                System.IO.FileInfo fileInfo = new System.IO.FileInfo(s);
                if (System.IO.Directory.Exists(fileInfo.DirectoryName))
                {
                    sfd.InitialDirectory = fileInfo.DirectoryName;
                }
            }
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                m_applicationManager.onNewProjectFile(sfd.FileName);
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



        #endregion

        #region UTILITY



        #endregion
    }
}
