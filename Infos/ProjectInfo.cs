using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppLib.Infos
{
    class ProjectInfo
    {
        #region VARIABLES
        
        private string m_appplicationName;        
        private string m_companyName;
        
        #endregion

        #region CONSTRUCTORS

        public ProjectInfo(string companyName, string applicationName)
        {
            m_appplicationName = applicationName;
            m_companyName = companyName;
        }

        #endregion

        #region PROPERTIES

        public string COMPANY_NAME
        {
            get
            {
                return m_companyName;
            }
            set
            {
                m_companyName = value;
            }
        }

        public string APPLICATION_NAME
        {
            get
            {
                return m_appplicationName;
            }
            set
            {
                m_appplicationName = value;
            }
        }

        #endregion
    }
}
