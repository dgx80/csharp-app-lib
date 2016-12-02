using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppLib.Forms
{
    public interface ApplicationFormInterface
    {
        void onOnload();

        void onPostload();

        void onNewProject();

        void onOpenProject();

        void onSaveProject();
    }
}
