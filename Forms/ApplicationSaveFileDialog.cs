using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace AppLib.Forms
{
    public class ApplicationSaveFileDialog : ApplicationBaseFileDialog
    {
        public ApplicationSaveFileDialog(string authorisedEntension, string currentFullName = "")
            : base(authorisedEntension, currentFullName)
        {
            
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
            sfd.DefaultExt = EXTENSION;
            sfd.AddExtension = true;
            sfd.Filter = FILTER;

            if (WORKING_DIRECTORY != "")
            {
                sfd.InitialDirectory = WORKING_DIRECTORY;
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
                string expectedExtension = "." + EXTENSION;
                if (currentExtention == expectedExtension)
                {
                    return fullName;
                }
                else
                {
                    // reload the saveFileDialog with the same name and extention is replaced
                    MessageBox.Show("only (*." + EXTENSION + ") extention is authorized as project format");
                    string fileName = fi.Name.Replace(currentExtention, expectedExtension);
                    return askAFileName(fileName);
                }
            }
            return "";
        }
    }
}
