using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleDriveManager
{
    public class ListId
    {
        public string name { get; set; }

        public string type { get; set; }
        public ListId()
        {

        }
        public ListId(string name, string type)
        {
            this.name = name;
            this.type = type;
        }
    }


}
