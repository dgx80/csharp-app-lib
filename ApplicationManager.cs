using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppLib.Data;
using System.Reflection;

namespace AppLib
{
    public class ApplicationManager
    {

        #region VARIABLES

        private IO.Path m_path;
        private Infos.ProjectInfo m_projectInfo;
        private Settings m_setting;

        #endregion


        #region CONSTRUCTOR

        public ApplicationManager(Settings settings, Project project, string companyName, string applicationName)
        {
            m_projectInfo = new Infos.ProjectInfo(companyName, applicationName);
            m_path = new IO.Path(m_projectInfo);
            string filename = m_path.APP_DATA;
            MethodInfo method = settings.GetType().GetMethod("load");
            MethodInfo genericMethod = method.MakeGenericMethod(settings.GetType());
            object[] parametersArray = new object[] { sFilename };
            genericMethod.Invoke(null, parametersArray);

            m_setting = Data.Settings.load<typeof(settings).Name>(filename);
        }
        #endregion

        public void load()
        {
            
        }
        #region PROPERTIES

        #endregion
    }
}
