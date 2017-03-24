using System;
using System.Collections.Generic;
using System.IO;
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
            int user, compressing = 0, onlyNew = 0;
            try
            {
                if (loadUsers() && args.Length > 5 )
                {
                    uploadFilePath = (compressing == 0) ? args[0] : Gtools.compressFile(args[1]);
                    filename = (compressing == 0) ? args[1] : args[2].Split('.').First() + ".zip";
                    parentID = (args[2] != "0") ? args[2] : null;
                    int.TryParse(args[3], out user);
                    int.TryParse(args[4], out onlyNew);
                    int.TryParse(args[5], out compressing);


                    if (GoogleDriveAPIV3.GoogleDriveConnection(
                        UserList[user].clientSecretPath,
                        UserList[user].userName))
                    {
                        parentID = GoogleDriveAPIV3.createFolderToDrive(
                        DateTime.Now.Year.ToString() +
                        DateTime.Now.Month.ToString() +
                        DateTime.Now.Day.ToString() + "_" +
                        DateTime.Now.Hour + DateTime.Now.Minute + "_" + filename +"_BackUp",
                        parentID);
                        GoogleDriveAPIV3.uploadToDrive(uploadFilePath, filename, parentID, (onlyNew != 0));
                    }
                    else throw new Exception("Connection Error");
                }
                else throw new Exception("Arguments Error");
            }
            catch (Exception exc)
            {
                System.Diagnostics.Debug.WriteLine(exc.Message + " Start with Args Error.\n");
                Gtools.writeToFile(frmMain.errorLog, Environment.NewLine + DateTime.Now.ToString() +
                    Environment.NewLine + exc.Message + " Start with Args Error.\n");
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
                System.Diagnostics.Debug.WriteLine(exc.Message + " Load User Error");
                Gtools.writeToFile(frmMain.errorLog, Environment.NewLine + DateTime.Now.ToString() +
                   Environment.NewLine + exc.Message + " Load User Error.\n");
                return false;
            }
        }

    }
}
