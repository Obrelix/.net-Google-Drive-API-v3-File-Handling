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
        static List<IOFile> IOFileList = new List<IOFile>();
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
            string uploadFilePath, filename, backupName, parentID;
            int user, compressing = 0, onlyNew = 0;
            try
            {
                if (loadUsers() && args.Length > 5 )
                {
                    loadFileList(args[0]);
                    backupName = args[1];
                    parentID = (args[2] != "0") ? args[2] : null;
                    int.TryParse(args[3], out user);
                    int.TryParse(args[4], out onlyNew);
                    int.TryParse(args[5], out compressing);


                    if (GoogleDriveAPIV3.GoogleDriveConnection(
                        UserList[user].clientSecretPath,
                        UserList[user].userName))
                    {
                        parentID = GoogleDriveAPIV3.createFolderToDrive(
                        Gtools.getTimeStamp() + "_" + backupName,
                        parentID);
                        foreach(IOFile file in IOFileList)
                        {
                            uploadFilePath = (compressing == 0) ? file.path : Gtools.compressFile(file.path);
                            filename = (compressing == 0) ? file.name : file.name.Split('.').First() + ".zip";
                            GoogleDriveAPIV3.uploadToDrive(uploadFilePath, filename, parentID, (onlyNew != 0), new frmMain());
                        }
                        
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

        private static bool loadFileList(string saveFile)
        {
            try
            {
                if (!System.IO.File.Exists(saveFile)) throw new Exception("File not found!");

                IOFileList.Clear();
                IOFileList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<IOFile>>(System.IO.File.ReadAllText(saveFile));
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
