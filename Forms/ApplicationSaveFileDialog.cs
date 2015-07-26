using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace AppLib.Forms
{
    public class ApplicationSaveFileDialog
    {
        private string m_authorisedEntension;
        private string m_currentWorkingDirectory = "";

        public ApplicationSaveFileDialog(string authorisedEntension, string currentProjectName = "")
        {
            m_authorisedEntension = authorisedEntension;
            string s = currentProjectName;
            if (s != "")
            {
                System.IO.FileInfo fileInfo = new System.IO.FileInfo(s);
                if (System.IO.Directory.Exists(fileInfo.DirectoryName))
                {
                    m_currentWorkingDirectory = fileInfo.DirectoryName;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="defaultFileName">
        /// when you want to load a default file name,
        /// because this function is recucive when you have an error with unauthoriezed extention
        /// </param>
        /// <returns>
        /// fullname of file or an empty string when is interrupted
        /// </returns>
        public string askAFileName(string defaultFileName = "")
        {
            string fullName = "";
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.DefaultExt = m_authorisedEntension;
            sfd.AddExtension = true;
            sfd.Filter = "Files (*." + m_authorisedEntension + "*)|*." + m_authorisedEntension + "*";

            if (m_currentWorkingDirectory != "")
            {
                sfd.InitialDirectory = m_currentWorkingDirectory;
            }
            if (defaultFileName != "")
            {
                sfd.FileName = defaultFileName;
            }
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                fullName = sfd.FileName;
                //validate if the extension is authorised
                FileInfo fi = new FileInfo(fullName);
                string currentExtention = fi.Extension;
                string expectedExtension = "." + m_authorisedEntension;
                if (currentExtention == expectedExtension)
                {
                    return fullName;
                }
                else
                {
                    // reload the saveFileDialog with the same name and extention is replaced
                    MessageBox.Show("only (*." + m_authorisedEntension + ") extention is authorized as project format");
                    string fileName = fi.Name.Replace(currentExtention, expectedExtension);
                    return askAFileName(fileName);
                }
            }
            return "";
        }
    }
}
