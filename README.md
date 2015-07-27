# csharp-app-lib

To start an application with the data serialization as most quickly as possible

1. Automatic File menu strip to administrate specific extention file
  * File, new
  * File, open
  * File, quit
2. Automatic settings
  * AppData folder of the application is created
  * Remember last project data loaded and reload it at opening
3.  Data overriding
  * add every Property in your project and setting file of your application.



# Specific Project PROPERTIES class
	//define a specific project properties that wrapped on AppLib.Data.Project
	//serialized in AppData of your application as xml file
    using AppLib.Data;
    
    namespace Met.Data.File
    {
        public class MetaliaProject : Project
        {
            private string m_specificValue = "";
            
            //pull every propertie that you need here
            #region PROPERTIES
    
            public string SPECIFIC_VALUE
            {
                get
                {
                    return m_specificValue;
                }
                set
                {
                    m_specificValue = value;
                }
            }
            #endregion
        }
    }
# (optional) Specific Application Settings PROPERTIES class
	//define a specific settings properties that wrapped on AppLib.Data.Settings
    using AppLib.Data; 
    namespace Met.Data.File
    {

        public class MetaliaSettings : Settings
        {
            private string m_specificValue = "";
            
            //argument passed is the normal project extension, here is *.met
            public MetaliaSettings()
                : base("met")
            {
            }
            //pull every propertie that you need here
            #region PROPERTIES
    
            public string SPECIFIC_VALUE
            {
                get
                {
                    return m_specificValue;
                }
                set
                {
                    m_specificValue = value;
                }
            }
    
            #endregion
        }
    }
# Application instance
    //define a specific application instance
    namespace Met
    {
        /// <summary>
        /// This class is an Application instance that you inject specific or default project and setting data
        /// </summary>
        public static class Metalia
        {
            private static AppLib.ApplicationManager s_applicationManager = null;
            
            public static AppLib.ApplicationManager APPLICATION_MANAGER
            {
                get
                {
                    if (s_applicationManager == null)
                    {
                        s_applicationManager = new AppLib.ApplicationManager(new MetaliaSettings(), new MetaliaProject(), Definitions.NAME.COMPANY_NAME, Definitions.NAME.APP_NAME);
                    }
                    return s_applicationManager;
                }
            }
        }
    }
# Main Form    
    //here in the mainForm
    namespace Met.Forms
    {
        public partial class FormItems : Form
        {
            public FormItems()
            {
                InitializeComponent();
                //injection of main form and menuStrip
                //every action of File: new,open,save,quit is automatically implemented
                Metalia.APPLICATION_MANAGER.initApplicationForm(this, menuStrip1);
                Metalia.APPLICATION_MANAGER.loadProject();
            }
        }
    }
