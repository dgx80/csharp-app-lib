using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AppLib.Forms
{
    public class ApplicationMainForm
    {
        private System.Windows.Forms.Form m_mainForm;
        private ApplicationForm m_applicationForm;

        public ApplicationMainForm(ApplicationForm applicationForm, System.Windows.Forms.Form mainForm)
        {
            m_applicationForm = applicationForm;
            m_mainForm = mainForm;
            m_mainForm.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.mainFormClosing);
            //m_mainForm.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mainFormKeyPress);
        }

        public void close()
        {
            m_mainForm.Close();
        }

        private void mainFormKeyPress(object sender, KeyPressEventArgs e)
        {
            
        }
        private void mainFormClosing(object sender, FormClosingEventArgs e)
        {
            if (!m_applicationForm.isQuitApplicationAccepted())
            {
                e.Cancel = true;
            }
        }
        
    }
}
