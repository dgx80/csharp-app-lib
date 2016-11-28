using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppLib.Data
{
    public class VersionBuilder
    {
        public string getStringVersion(int major, int minor, int build)
        {
            return major.ToString() + "." + minor.ToString() + "." + build.ToString();
        }
    }
}
