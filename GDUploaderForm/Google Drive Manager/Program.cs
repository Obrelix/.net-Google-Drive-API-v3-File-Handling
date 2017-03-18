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
            string uploadFilePath, filename, parentID;
            int user;
            loadUsers(savePath, saveFile);
            uploadFilePath = args[1];
            filename = args[2];
            parentID = args[3];

            if(int.TryParse(args[0], out user))
            {
                if(GoogleDriveAPIV3.GoogleDriveConnection(UserList[user].clientSecretPath,
                    UserList[user].appName, UserList[user].userName) &&
                    filename != null && uploadFilePath != null)
                {
                        GoogleDriveAPIV3.uploadToDrive(uploadFilePath, filename, parentID);
                }
            }
        }

        private static void loadUsers(string savePath, string saveFile)
        {
            Directory.CreateDirectory(savePath);
            try
            {
                if (System.IO.File.Exists(saveFile))
                {
                    UserList.Clear();
                    UserList = JsonConvert.DeserializeObject<List<User>>(System.IO.File.ReadAllText(saveFile));


                }
                else
                {
                    using (System.IO.FileStream fs = System.IO.File.Create(saveFile))
                    {
                        for (byte i = 0; i < 100; i++)
                        {
                            fs.WriteByte(i);
                        }
                    }

                    System.IO.File.WriteAllText(saveFile, "[ ]");
                    loadUsers(savePath, saveFile);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);

            }
        }
    }
}
