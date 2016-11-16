
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
        /// <param name="fileName">when you want to load another than the default name in memory</param>
        public void load(string fileName = "")
        {
            if (fileName != "")
            {
                CURRENT_PROJECT_NAME = fileName;
            }
            m_project.Load(CURRENT_PROJECT_NAME);
            m_setting.write();
        }
        /// <summary>
        /// 
        /// </summary>
        public void save()
        {
            m_project.write();
            m_setting.write();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>true if data changed</returns>
        public bool isDataChanged()
        {
            return m_project.isDataChanged();
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
            private set
            {
                m_project.FILENAME = value;
                m_setting.CURRENT_PROJECT_PATH = value;
            }
        }
        #endregion
    }
}
