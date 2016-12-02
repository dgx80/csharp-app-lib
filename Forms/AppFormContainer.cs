using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AppLib.Forms
{
    public abstract class AppFormContainer : Form, ApplicationFormInterface
    {
        public void onOnload() { }

        public void onPostload() { }

        public void onNewProject() { }

        public void onOpenProject() { }

        public void onSaveProject() { }
    }
}
