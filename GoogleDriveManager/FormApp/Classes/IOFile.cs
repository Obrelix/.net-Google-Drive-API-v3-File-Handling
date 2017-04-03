using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GoogleDriveManager
{
    public class IOFile
    {
        public string path { get; set; }
        public string name { get; }

        public IOFile(string path)
        {
            this.path = path;
            name = Path.GetFileName(path);
        }
    }
}
