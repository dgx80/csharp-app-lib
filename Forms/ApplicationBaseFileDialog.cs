using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppLib.Forms
{
    public class ApplicationBaseFileDialog
    {        
        #region ATTRIBUTES

        private string m_authorisedEntension;
        private string m_currentFullName;        
        private string m_currentWorkingDirectory;
        
        #endregion

        #region DECLARATION



        #endregion

        #region CONSTRUCTOR

        protected ApplicationBaseFileDialog(string authorisedEntension, string currentFullName = "")
        {
            m_authorisedEntension = authorisedEntension;

            if (currentFullName != "")
            {
                if (System.IO.File.Exists(currentFullName))
                {
                    m_currentFullName = currentFullName;
                }

                System.IO.FileInfo fileInfo = new System.IO.FileInfo(currentFullName);
                if (System.IO.Directory.Exists(fileInfo.DirectoryName))
                {
                    m_currentWorkingDirectory = fileInfo.DirectoryName;
                }
            }
        }

        #endregion

        #region PROPERTIES

        public string EXTENSION
        {
            get
            {
                return m_authorisedEntension;
            }
        }

        protected string FULL_NAME
        {
            get
            {
                return m_currentFullName;
            }
        }

        protected string WORKING_DIRECTORY
        {
            get
            {
                return m_currentWorkingDirectory;
            }
        }

        protected string FILTER
        {
            get
            {
                return "Files (*." + EXTENSION + "*)|*." + EXTENSION + "*";
            }
        }
        protected string getUnAuthoriedMessage()
        {
            return "only (*." + EXTENSION + ") extention is authorized as project format";
        }
        #endregion

    }
}
