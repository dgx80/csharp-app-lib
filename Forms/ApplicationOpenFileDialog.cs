using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace AppLib.Forms
{
    public class ApplicationOpenFileDialog : ApplicationBaseFileDialog
    {
        public ApplicationOpenFileDialog(string authorisedEntension, string currentFullName = "")
            : base(authorisedEntension, currentFullName)
        {
        }
        public string askAFileName()
        {
            string fullName = "";
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.DefaultExt = EXTENSION;
            ofd.AddExtension = true;
            ofd.Filter = FILTER;

            if (WORKING_DIRECTORY != "")
            {
                ofd.InitialDirectory = WORKING_DIRECTORY;
            }
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                fullName = ofd.FileName;
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
                    // recurcive call
                    MessageBox.Show(getUnAuthoriedMessage());
                    return askAFileName();
                }
            }
            return "";
        }
    }
}
