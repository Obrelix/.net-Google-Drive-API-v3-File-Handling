using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoogleDriveManager
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// 
        /// </summary>

        static List<User> UserList = new List<User>();
        static string saveFile = Environment.GetFolderPath(
            Environment.SpecialFolder.ApplicationData)
            + "\\BackUpManager\\GDASaves.json";

        [STAThread]
        static void Main(string[] args)
        {
            if(args.Length > 0)
            {
                startWithArgs(args);
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new frmMain());
            }
        }

        private static void startWithArgs(string[] args)
        {
            string uploadFilePath, filename, parentID;
            int user;
            int i = 0;
            foreach (string arg in args)
            {
                Console.WriteLine("arg{0} : {1}", i, arg);
                i++;
            }
            try
            {
                if (loadUsers() &&
                args.Length > 2 &&
                int.TryParse(args[0], out user))
                {
                    uploadFilePath = args[1];
                    filename = args[2];
                    parentID = (args.Length > 3) ? args[3] : null;
                    Console.WriteLine("{0} \n{1} \n{2} \n{3}",
                        UserList[user].userName, uploadFilePath, filename, parentID);
                    if (GoogleDriveAPIV3.GoogleDriveConnection(
                        UserList[user].clientSecretPath,
                        UserList[user].appName,
                        UserList[user].userName))
                    {
                        GoogleDriveAPIV3.uploadToDrive(uploadFilePath, filename, parentID);
                        Console.WriteLine("Upload Completed");
                    }
                    else throw new Exception("Connection Error");
                }
                else throw new Exception("Arguments Error");
            }
            catch (Exception exc)
            {
                System.Diagnostics.Debug.WriteLine(exc.Message);
                Console.WriteLine(exc.Message);
            }
        }

        private static bool loadUsers()
        {
            try
            {
                if (!System.IO.File.Exists(saveFile)) throw new Exception("File not found!");

                UserList.Clear();
                UserList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<User>>(System.IO.File.ReadAllText(saveFile));
                return true;
            }
            catch (Exception exc)
            {
                System.Diagnostics.Debug.WriteLine(exc.Message + " LoadUser Error");
                Console.WriteLine(exc.Message + " LoadUser Error");
                return false;
            }
        }

    }
}
