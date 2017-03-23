using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleDriveManager
{
    public static class Gtools
    {

        public static string compressFile(string path)
        {

            string zipPath = path.Split('.').First() + ".zip";
            try
            {
                using (ZipFile zip = new ZipFile(Encoding.UTF8))
                {
                    if (Path.HasExtension(path)) zip.AddFile(@path);
                    else
                    {
                        zip.AddDirectory(@path);
                    }
                    zip.Save(@zipPath);
                }
                return @zipPath;
            }
            catch (Exception exc)
            {
                System.Diagnostics.Debug.WriteLine(exc.Message);
                return null;
            }

        }

        public static bool createFile(string saveFile, string contentToWrite)
        {
            try
            {
                using (System.IO.FileStream fs = System.IO.File.Create(saveFile))
                {
                    for (byte i = 0; i < 100; i++)
                    {
                        fs.WriteByte(i);
                    }
                }

                System.IO.File.WriteAllText(saveFile, contentToWrite);
                return true;
            }
            catch (Exception exc)
            {
                System.Diagnostics.Debug.WriteLine(exc.Message);
                return false;
            }

        }


        public static string md5ChecksumGenerator(string filePath)
        {
            if (Path.HasExtension(filePath))
            {
                try
                {
                    using (var md5 = System.Security.Cryptography.MD5.Create())
                    {
                        using (var stream = System.IO.File.OpenRead(filePath))
                        {
                            return BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", null).ToLower();
                            // "" is 8203 ascii character and the total lenght of string doesnt change 
                            //return BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", "").ToLower();
                        }
                    }
                }
                catch (Exception exc)
                {
                    System.Diagnostics.Debug.WriteLine(exc.Message);
                    return null;
                }

            }
            else
            {
                return null;
            }

        }

        public static bool compareHash(string hashToCompare)
        {
            foreach (string[] array in GoogleDriveAPIV3.listDriveFiles())
            {
                if (Array.FindAll(array, s => s.Equals(hashToCompare)).Length > 0) return true;
                //array[5] = UnicodeEncoding.UTF8.g
                //if (@array[5][0] == hashToCompare[0])
                //{
                //    return true;
                //}
            }
            return false;
        }



        public static void deleteCredFile(string savePath, string userName)
        {
            string[] files = Directory.GetFiles(Path.Combine(savePath, ".credentials"));
            foreach (string file in files)
            {
                if (userName == file.Split('-').Last())
                {
                    System.IO.File.Delete(file);
                }
            }
        }

    }


    
}
