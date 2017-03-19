using GDUploaderForm;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Google_Drive_Manager
{
    class Program
    {
        public static List<User> UserList = new List<User>();
        static string savePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\BackUpManager";
        static string saveFile = savePath + "\\GDASaves.json";

        static void Main(string[] args)
        {
            string uploadFilePath, filename, parentID, exceptionMessage;
            int user;
            int i = 0;
            foreach(string arg in args)
            {
                Console.WriteLine("arg{0} : {1}", i, arg);
                i++;
            }
            try
            {
                if (loadUsers(savePath, saveFile) &&
                args.Length > 0 &&
                int.TryParse(args[0], out user))
                {
                    uploadFilePath = args[1];
                    filename = args[2];
                    if (args.Length > 3 ) parentID = args[3];
                    else parentID = null;
                    if (GoogleDriveAPIV3.GoogleDriveConnection(
                        UserList[user].clientSecretPath,
                        UserList[user].appName, 
                        UserList[user].userName))
                    {
                        GoogleDriveAPIV3.uploadToDrive(uploadFilePath, filename, parentID);
                        Console.WriteLine("Upload Completed");
                    }
                    else{throw new Exception("Connection Error");}
                }
                else{throw new Exception("Arguments Error");}
            }
            catch(Exception exc)
            {
                System.Diagnostics.Debug.WriteLine(exc.Message);
                Console.WriteLine(exc.Message);
            }
        }

        private static bool loadUsers(string savePath, string saveFile)
        {
            Directory.CreateDirectory(savePath);
            try
            {
                if (File.Exists(saveFile))
                {
                    UserList.Clear();
                    UserList = JsonConvert.DeserializeObject<List<User>>(System.IO.File.ReadAllText(saveFile));
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception exc)
            {
                System.Diagnostics.Debug.WriteLine(exc.Message + " LoadUser Method");
                Console.WriteLine(exc.Message);
                return false;

            }
        }
    }
}
