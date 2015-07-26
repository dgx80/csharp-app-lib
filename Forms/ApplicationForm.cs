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
        /// <param name="defaultFileName">when you want to load a default file name</param>
        public void OnNewProject(string defaultFileName = "")
        {
            SaveFileDialog sfd = new SaveFileDialog();
            string ext = m_applicationManager.APP_DATA.SETTINGS.getProjectFileExtension();
            sfd.DefaultExt = ext;
            sfd.AddExtension = true;
            sfd.Filter = "Files (*." + ext + "*)|*." + ext + "*";
            string s = m_applicationManager.APP_DATA.CURRENT_PROJECT_NAME;

            if (s != "")
            {
                System.IO.FileInfo fileInfo = new System.IO.FileInfo(s);
                if (System.IO.Directory.Exists(fileInfo.DirectoryName))
                {
                    sfd.InitialDirectory = fileInfo.DirectoryName;
                }
            }
            if (defaultFileName != "")
            {
                sfd.FileName = defaultFileName;
            }
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string fullName = sfd.FileName;
                //validate if the extension is authorised
                FileInfo fi = new FileInfo(fullName);
                string currentExtention = fi.Extension;
                string expectedExtension = "." + ext;
                if (currentExtention == expectedExtension)
                {
                    m_applicationManager.onNewProjectFile(fullName);
                    return;
                }
                else
                {
                    // reload the saveFileDialog with the same name and extention is replaced
                    MessageBox.Show("only (*." + ext + ") extention is authorized as project format");
                    string fileName = fi.Name.Replace(currentExtention, expectedExtension);
                    OnNewProject(fileName);
                }
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
