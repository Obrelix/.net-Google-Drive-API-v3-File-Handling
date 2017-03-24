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
                            // "" is the 8203 ascii character and the total lenght of the string doesnt change 
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

    }


    
}
