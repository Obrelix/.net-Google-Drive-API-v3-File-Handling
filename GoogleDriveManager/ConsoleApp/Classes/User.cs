using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppUploaderWithArgs
{
    public class User
    {
        public string userName { get; set; }
        public string clientSecretPath { get; set; }
        public string appName { get; set; }

        public User(string name, string path, string appName)
        {
            userName = name;
            clientSecretPath = path;
            this.appName = appName;
        }
    }
}
