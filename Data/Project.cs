using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;

namespace AppLib.Data
{
    public class Project : FileData
    {

        public Project(string sAppName)
            : base()
        {
            this.FILE_TYPE = sAppName + ".project";
        }
    }
}
