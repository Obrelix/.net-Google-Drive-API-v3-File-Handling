using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleDriveManager
{
    public class User
    {
        public string userName { get; set; }
        public string clientSecretPath { get; set; }

        public User(string name, string path)
        {
            userName = name;
            clientSecretPath = path;
        }
    }
}
