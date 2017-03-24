using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
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
                System.Diagnostics.Debug.WriteLine(exc.Message + " Compress IO.File Error");
                Gtools.writeToFile(frmMain.errorLog, Environment.NewLine + DateTime.Now.ToString() +
                    Environment.NewLine + exc.Message + " Compress IO.File Error.\n");
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
                System.Diagnostics.Debug.WriteLine(exc.Message +" Create IO.File Error");
                writeToFile(frmMain.errorLog, DateTime.Now.ToString() +
                    Environment.NewLine + exc.Message + " Create IO.File Error.\n");
                return false;
            }
        }

        public static bool writeToFile(string saveFile, string contentToWrite)
        {
            try
            {
                using (StreamWriter w = File.AppendText(saveFile))
                {
                    w.WriteLine(contentToWrite);
                }
                return true;
            }
            catch (Exception exc)
            {
                System.Diagnostics.Debug.WriteLine(exc.Message + " Write to IO.File Error");
                writeToFile(frmMain.errorLog, DateTime.Now.ToString() +
                    Environment.NewLine + exc.Message + " Write to IO.File Error.\n");
                return false;
            }
        }


        public static string hashGenerator(string filePath)
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
                            // "" is the 8203 ascii character and the total lenght of the string doesnt change 
                            //return BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", "").ToLower();
                        }
                    }
                }
                catch (Exception exc)
                {
                    System.Diagnostics.Debug.WriteLine(exc.Message + " Hash Generator Error");
                    writeToFile(frmMain.errorLog, DateTime.Now.ToString() +
                    Environment.NewLine + exc.Message + " Hash Generator Error.\n");
                    return null;
                }

            }
            else
            {
                return null;
            }

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

        public static DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            try
            {
                //Get all the properties
                PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
                foreach (PropertyInfo prop in Props)
                {
                    //Defining type of data column gives proper data table 
                    var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);
                    //Setting column names as Property names
                    dataTable.Columns.Add(prop.Name, type);
                }
                foreach (T item in items)
                {
                    var values = new object[Props.Length];
                    for (int i = 0; i < Props.Length; i++)
                    {
                        //inserting property values to datatable rows
                        values[i] = Props[i].GetValue(item, null);
                    }
                    dataTable.Rows.Add(values);
                }
                //put a breakpoint here and check datatable
                return dataTable;
            }

            catch (Exception exc)
            {
                System.Diagnostics.Debug.WriteLine(exc.Message + " Convert to DataTable Error");
                writeToFile(frmMain.errorLog, DateTime.Now.ToString() +
                    Environment.NewLine + exc.Message + " Convert to DataTable Error.\n");
                return null;
            }

            
        }

    }


    
}
