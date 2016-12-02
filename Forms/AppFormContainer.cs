using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AppLib.Forms
{
    public abstract class AppFormContainer : Form, ApplicationFormInterface
    {
        public virtual void onOnload() { }

        public virtual void onPostload() { }

        public virtual void onNewProject() { }

        public virtual void onOpenProject() { }

        public virtual void onSaveProject() { }
    }
}
