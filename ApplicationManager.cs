using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppLib.Data;
using System.Reflection;
using System.IO;
using AppLib.Components;
using AppLib.Infos;
using AppLib.Forms;

namespace AppLib
{
    public class ApplicationManager
    {

        #region VARIABLES

        private ApplicationData m_applicationData;
        private ApplicationPathInfo m_applicationPathInfo;
        private ApplicationForm m_applicationForm;
        
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
            if (APP_FORM !=null)
            {
                APP_FORM.onOnload();
            }
            APP_DATA.onLoad();
            
            if (APP_FORM != null)
            {
                APP_FORM.onPostload();
            }
        }
        /// <summary>
        /// save the project with the current project filename from settings
        /// </summary>
        public void saveProject()
        {
            APP_DATA.onSave();
        }

        #region PROPERTIES

        public ApplicationForm APP_FORM
        {
            get
            {
                return m_applicationForm;
            }
        }

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
            load(fileName);
            APP_DATA.onSave();
        }

        public void onOpenProjectFile(string fileName)
        {
            load(fileName);
        }

        private void load(string fileName)
        {
            APP_DATA.onLoad(fileName);
        }
        #endregion
        
        #region FORM

        /// <summary>
        /// add automatically generic mecanic to create, open and close a project file
        /// </summary>
        /// <param name="mainForm"></param>
        /// <param name="menuStrip"></param>
        public void initApplicationForm(System.Windows.Forms.Form mainForm, System.Windows.Forms.MenuStrip menuStrip)
        {
            m_applicationForm = new ApplicationForm(this, mainForm, menuStrip);
        }
        #endregion
    }
}
