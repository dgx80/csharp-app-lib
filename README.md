# csharp-app-lib
my generic code cross project

For the moment it is working at 90%

    using AppLib.Data;
    
    namespace Met.Data.File
    {
        //define a specific setting propertie that override AppLib.Data.Settings for that be automatically
        //serialized in AppData of your application as xml file
        public class MetaliaSettings : Settings
        {
            private string m_specificValue = "";
            
            //argument passed is the normal project extension, here is *.met
            public MetaliaSettings()
                : base("met")
            {
            }
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

    //do the same thing for the project data propertie that you want to save
    using AppLib.Data;
    
    namespace Met.Data.File
    {
        public class MetaliaProject : Project
        {
            private string m_specificValue = "";
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

    //define a specific application instance
    namespace Met
    {
        /// <summary>
        /// This class is an Application instance that you override defaut project and setting data
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
                Metalia.APPLICATION_MANAGER.addProjectMenuStripToThisForm(this, menuStrip1);
            }
        }
    }