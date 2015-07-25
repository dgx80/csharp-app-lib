using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppLib.Data
{
    public class ApplicationData
    {
        private Settings m_setting;
        
        private Project m_project;
        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="settings"></param>
        /// <param name="project"></param>
        /// <param name="settingFileName"></param>
        public ApplicationData(Settings settings, Project project, string settingFileName)
        {
            m_setting = settings;
            m_setting.Load(settingFileName);
            m_project = project;
        }
        /// <summary>
        /// 
        /// </summary>
        public void onLoad()
        {
            m_project.Load(m_setting.CURRENT_PROJECT_PATH);
        }
        /// <summary>
        /// 
        /// </summary>
        public void onSave()
        {
            m_project.write();
            m_setting.write();
        }
        #region PROPERTIES

        /// <summary>
        /// 
        /// </summary>
        public Project PROJECT
        {
            get
            {
                return m_project;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Settings SETTINGS
        {
            get
            {
                return m_setting;
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
    }
}
