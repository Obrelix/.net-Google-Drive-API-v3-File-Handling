using Google.Apis.Auth.OAuth2;
using Google.Apis.Download;
using Google.Apis.Drive.v3;
using Google.Apis.Drive.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GDUploaderForm
{
    public static class GoogleDriveAPIV3
    {
        private static string[] Scopes = { DriveService.Scope.Drive };
        private static UserCredential credential;
        private static DriveService service;

        public static bool GoogleDriveConnection(string jsonSecretPath, string appName)
        {

            return (getCredential(jsonSecretPath, appName) && createDriveService(appName));

        }

        public static List<string[]> updateDriveFiles()
        {
            List<string[]> filesList = new List<string[]>();
            FilesResource.ListRequest listRequest = service.Files.List();
            listRequest.PageSize = 1000;
            listRequest.Fields = "nextPageToken, files(id, name)";

            // List files.
            IList<Google.Apis.Drive.v3.Data.File> files = listRequest.Execute().Files;
            
            filesList.Clear();
            if (files != null && files.Count > 0)
            {
                foreach (var file in files)
                {
                    
                    filesList.Add(new string[2] { file.Name, file.Id });
                    System.Diagnostics.Debug.WriteLine("{0} ({1} {2})", file.Name, file.Id, file.ModifiedByMeTime);
                }
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("No files found.");
            }

            return filesList;
        }


        private static bool getCredential(string clientSecretPath, string applicationName)
        {
            try
            {
                using (var stream = new FileStream(clientSecretPath, FileMode.Open, FileAccess.Read))
                {
                    string credPath = System.Environment.GetFolderPath(
                        System.Environment.SpecialFolder.Personal);
                    credPath = Path.Combine(credPath, ".credentials/"+ applicationName);

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
                return "";
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

                // Get the subdirectories for the specified directory.
                DirectoryInfo dir = new DirectoryInfo(path);
                string folderId;
                if (parentId == null)
                {
                    folderId = createFolderToDrive(Path.GetFileName(path), null);
                    System.Diagnostics.Debug.WriteLine(folderId);
                }
                else
                {
                    folderId = createFolderToDrive(
                        Path.GetFileName(path),
                        parentId);
                    System.Diagnostics.Debug.WriteLine(folderId);
                }
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
            
            
        }

        public static void downloadFromDrive(string fileId, string filename)
        {
            string savePath = @"C:\Users\Developer\Desktop" + @"\"+ @filename;
            //var fileId = "0BwwA4oUTeiV1UVNwOHItT0xfa2M";
            var request = service.Files.Get(fileId);
            var stream = new System.IO.MemoryStream();
            FileStream fs;
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

            using ( fs  = new System.IO.FileStream(savePath, FileMode.OpenOrCreate, FileAccess.Write))
            {
                try
                {
                    // System.IO.File.Create(saveFile)
                    stream.WriteTo(fs);                    
                    fs.Close();
                }
                catch { }
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
    }
}
