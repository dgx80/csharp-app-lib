using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppLib.Components;

namespace AppLib.Forms
{
    public class ApplicationForm
    {
        #region ATTRIBUTES

        private ApplicationManager m_applicationManager;
        private Components.ProjectMenuStrip m_projectMenuStrip;
        private Forms.ProgressBarDialog m_progressBar;

        #endregion

        #region DECLARATION
        
        #endregion

        #region CONSTRUCTOR

        
        public ApplicationForm(ApplicationManager applicationManager, System.Windows.Forms.Form form, System.Windows.Forms.MenuStrip menuStrip)
        {
            string ext = applicationManager.APP_DATA.SETTINGS.getProjectFileExtension();
            m_projectMenuStrip = new ProjectMenuStrip(applicationManager, form, menuStrip, ext);
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
