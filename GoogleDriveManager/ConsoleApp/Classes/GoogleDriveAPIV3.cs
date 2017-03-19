using Google.Apis.Auth.OAuth2;
using Google.Apis.Download;
using Google.Apis.Drive.v3;
using Google.Apis.Drive.v3.Data;
using Google.Apis.Services;
using Google.Apis.Upload;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleAppUploaderWithArgs
{
    public static class GoogleDriveAPIV3
    {
        private static string[] Scopes = { DriveService.Scope.Drive };
        private static UserCredential credential;
        private static DriveService service;

        private static readonly string[] SizeSuffixes =
                  { "bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };

        public static bool GoogleDriveConnection(string jsonSecretPath, string appName, string userName)
        {

            return (getCredential(jsonSecretPath, appName, userName) && createDriveService(appName));

        }

        public static List<string[]> updateDriveFiles()
        {
            List<string[]> filesList = new List<string[]>();

            try
            {
                FilesResource.ListRequest listRequest = service.Files.List();
                listRequest.PageSize = 1000;
                listRequest.Fields = "nextPageToken, files(mimeType, id, name, parents, size, modifiedTime)";

                // List files.
                IList<Google.Apis.Drive.v3.Data.File> files = listRequest.Execute().Files;

                filesList.Clear();
                if (files != null && files.Count > 0)
                {
                    foreach (var file in files)
                    {

                        filesList.Add(new string[5] {
                            file.Name, file.Size.ToString(),
                            file.Id,
                            file.ModifiedTime.ToString(), file.MimeType });
                        System.Diagnostics.Debug.WriteLine("{0} {1} {2} {3}", 
                            file.Name, file.Id, file.MimeType, file.Size.ToString());
                    }
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("No files found.");
                }
            }
            catch (Exception exc)
            {
                System.Diagnostics.Debug.WriteLine(exc.Message);
            }

            foreach(string[] array in filesList)
            {
                array[1] = sizeFix(array[1]);
            }
            return filesList;
        }


        private static string sizeFix(string bytesString, int decimalPlaces = 1)
        {
            long value;
            if (long.TryParse(bytesString, out value))
            {
                if (value < 0) { return "-" + sizeFix((-value).ToString()); }

                int i = 0;
                decimal dValue = (decimal)value;
                while (Math.Round(dValue, decimalPlaces) >= 1000)
                {
                    dValue /= 1024;
                    i++;
                }
                return string.Format("{0:n" + decimalPlaces + "} {1}", dValue, SizeSuffixes[i]);
            }
            else
            {
                return "";
            }
            
        }

        private static bool getCredential(string clientSecretPath, string applicationName, string userName)
        {
            try
            {
                using (var stream = new FileStream(clientSecretPath, FileMode.Open, FileAccess.Read))
                {
                    string credPath = System.Environment.GetFolderPath(
                        System.Environment.SpecialFolder.Personal);
                    credPath = Path.Combine(credPath, ".credentials/"+ userName);

                    credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                        GoogleClientSecrets.Load(stream).Secrets,
                        Scopes,
                        "user",
                        CancellationToken.None,
                        new FileDataStore(credPath, true)).Result;
                }
                return true;

            }
            catch (Exception exc)
            {
                System.Diagnostics.Debug.WriteLine(exc.Message);
                return false;
            }
        }

        private static bool createDriveService(string applicationName)
        {
            try
            {
                // Create Drive API service.
                service = new DriveService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = applicationName,
                });
                return true;
            }
            catch (Exception exc)
            {
                System.Diagnostics.Debug.WriteLine(exc.Message);
                return false;
            }

        }

        


        private static void uploadFileToDrive(string folderId, string fileName, string filePath, string fileType)
        {
            try
            {
                var fileMetadata = new Google.Apis.Drive.v3.Data.File()
                {
                    Name = fileName
                };
                if (folderId != null)
                {
                    fileMetadata.Parents = new List<string>
                    {
                        folderId
                    };
                }
                FilesResource.CreateMediaUpload request;
                using (var stream = new System.IO.FileStream(filePath, System.IO.FileMode.Open))
                {
                    request = service.Files.Create(
                        fileMetadata, stream, fileType);
                    request.ChunkSize = FilesResource.CreateMediaUpload.MinimumChunkSize;
                    request.ProgressChanged += (IUploadProgress progress) =>
                    {
                        switch (progress.Status)
                        {
                            case UploadStatus.Uploading:
                                {
                                    System.Diagnostics.Debug.WriteLine(progress.BytesSent);
                                    break;
                                }
                            case UploadStatus.Completed:
                                {
                                    System.Diagnostics.Debug.WriteLine("Upload complete.");
                                    break;
                                }
                            case UploadStatus.Failed:
                                {
                                    System.Diagnostics.Debug.WriteLine("Upload failed.");
                                    break;
                                }
                        }
                    };
                    request.Fields = "id";
                    request.Upload();
                }
                var file = request.ResponseBody;
                System.Diagnostics.Debug.WriteLine("File ID: " + file.Id);
            }
            catch (Exception exc)
            {
                System.Diagnostics.Debug.WriteLine(exc.Message);
            }
        }

        private static string createFolderToDrive(string folderName, string parentId)
        {
            try
            {
                
                var fileMetadata = new Google.Apis.Drive.v3.Data.File()
                {
                    Name = folderName,
                    MimeType = "application/vnd.google-apps.folder",
                    
                };
                if(parentId != null)
                {
                    fileMetadata.Parents = new List<string>
                    {
                        parentId
                    };
                }
                
                var request = service.Files.Create(fileMetadata);
                request.Fields = "id";
                var file = request.Execute();
                System.Diagnostics.Debug.WriteLine(file.Name);
                return file.Id;
            }
            catch(Exception exc)
            { 
                System.Diagnostics.Debug.WriteLine(exc.Message);
                return null;
            }
        }
        


        public static void uploadToDrive(string path, string name, string parentId)
        {
            if (Path.HasExtension(path))
            {
                uploadFileToDrive(
                        null,
                        name,
                        path, 
                        getMimeType(Path.GetFileName(path)));
            }
            else
            {
                try
                {
                    // Get the subdirectories for the specified directory.
                    string folderId = createFolderToDrive(
                            Path.GetFileName(path),
                            parentId);
                    System.Diagnostics.Debug.WriteLine(folderId);

                    DirectoryInfo dir = new DirectoryInfo(path);
                    if (!dir.Exists)
                    {
                        throw new DirectoryNotFoundException(
                            "Source directory does not exist or could not be found: "
                            + path);
                    }


                    DirectoryInfo[] dirs = dir.GetDirectories();
                    FileInfo[] files = dir.GetFiles();
                    foreach (FileInfo file in files)
                    {
                        uploadFileToDrive(
                            folderId, file.Name,
                            Path.Combine(path, file.Name),
                            getMimeType(file.Name));
                    }

                    foreach (DirectoryInfo subdir in dirs)
                    {
                        uploadToDrive(subdir.FullName, null, folderId);
                    }
                }
                catch (Exception exc)
                {
                    System.Diagnostics.Debug.WriteLine(exc.Message);
                }

            }
        }

        private static void convertMemoryStreamToFileStream(MemoryStream stream, string savePath)
        {
            FileStream fileStream;
            using (fileStream = new System.IO.FileStream(savePath, FileMode.OpenOrCreate, FileAccess.Write))
            {
                try
                {
                    // System.IO.File.Create(saveFile)
                    stream.WriteTo(fileStream);
                    fileStream.Close();
                }
                catch (Exception exc)
                {
                    System.Diagnostics.Debug.WriteLine(exc.Message);
                }
            }
        }
        public static void removeFile(string fileID)
        {
            try
            {
                var request = service.Files.Delete(fileID);
                request.Execute();
            }
            catch (Exception exc)
            {
                System.Diagnostics.Debug.WriteLine(exc.Message);
            }
        }
        public static void downloadFromDrive(string filename, string fileId, string savePath)
        {
            try
            {
               
                var request = service.Files.Get(fileId);
                var stream = new System.IO.MemoryStream();
                
                // Add a handler which will be notified on progress changes.
                // It will notify on each chunk download and when the
                // download is completed or failed.
                request.MediaDownloader.ProgressChanged +=
                    (IDownloadProgress progress) =>
                    {
                        switch (progress.Status)
                        {
                            case DownloadStatus.Downloading:
                                {
                                    System.Diagnostics.Debug.WriteLine(progress.BytesDownloaded);
                                    break;
                                }
                            case DownloadStatus.Completed:
                                {
                                    System.Diagnostics.Debug.WriteLine("Download complete.");
                                    break;
                                }
                            case DownloadStatus.Failed:
                                {
                                    System.Diagnostics.Debug.WriteLine("Download failed.");
                                    break;
                                }
                        }
                    };
                request.Download(stream);
                convertMemoryStreamToFileStream(stream, savePath + @"\" + @filename);
                stream.Dispose();
            }
            catch (Exception exc)
            {
                System.Diagnostics.Debug.WriteLine(exc.Message);
            }
        }

        private static string getMimeType(string fileName)
        {
            string mimeType = "application/unknown";
            string ext = System.IO.Path.GetExtension(fileName).ToLower();
            Microsoft.Win32.RegistryKey regKey = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(ext);
            if (regKey != null && regKey.GetValue("Content Type") != null)
                mimeType = regKey.GetValue("Content Type").ToString();
            System.Diagnostics.Debug.WriteLine(mimeType);
            return mimeType;
        }

        private static String GetFileType(string file)
        {
            try
            {
                string extension = Path.GetExtension(file);
                System.Diagnostics.Debug.WriteLine("extension: " + extension);
                string mime;
                switch (extension.ToLower())
                {
                    //image files
                    case ".svg":
                        mime = "image/svg+xml";
                        break;
                    case ".jpg":
                        mime = "image/jpeg";
                        break;
                    case ".jpeg":
                        mime = "image/jpeg";
                        break;
                    case ".png":
                        mime = "image/png";
                        break;

                    //Documents
                    //Excel Formats
                    case ".xlt":
                        mime = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                        break;
                    case ".xlsx":
                        mime = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                        break;
                    case ".xlsm":
                        mime = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                        break;
                    case ".xlsb":
                        mime = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                        break;
                    case ".xltx":
                        mime = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                        break;
                    case ".xltm":
                        mime = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                        break;
                    case ".xls":
                        mime = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                        break;

                    //PowerPoint Formats
                    case ".pptx":
                        mime = "application/vnd.openxmlformats-officedocument.presentationml.presentation";
                        break;
                    case ".ppt":
                        mime = "application/vnd.openxmlformats-officedocument.presentationml.presentation";
                        break;

                    case ".bat":
                        mime = "application/vnd.google-apps.script+json";
                        break;

                    case ".csv":
                        mime = "text/csv";
                        break;
                    case ".doc":
                        mime = "application/msword";
                        break;
                    case ".pdf":
                        mime = "application/pdf";
                        break;

                    case ".html":
                        mime = "text/html";
                        break;

                    default:
                        mime = "text/plain";
                        break;
                }
                return mime;
            }
            catch (Exception exc)
            {
                System.Diagnostics.Debug.WriteLine(exc.Message);
                return null;
            }
            
        }
    }
}
