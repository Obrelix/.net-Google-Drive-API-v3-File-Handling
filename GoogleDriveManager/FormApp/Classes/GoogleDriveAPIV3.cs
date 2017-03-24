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
using System.Windows.Forms;


namespace GoogleDriveManager
{

    public class GoogleDriveFile
    {
        public string name { get; set; }
        public string size { get; set; }
        public string lastModified { get; set; }
        public string type { get; set; }
        public string id { get; set; }
        public string hash { get; set; }

        public GoogleDriveFile(string name, string size, string lastModified, string type, string id, string hash)
        {
            this.name = name;
            this.size = size;
            this.lastModified = lastModified;
            this.type = type;
            this.id = id;
            this.hash = hash;
        }
    }

    public static class GoogleDriveAPIV3
    {
        private static string[] Scopes = { DriveService.Scope.Drive };

        private static UserCredential credential;
        private static DriveService service;


        private static string appDataSavePath = Environment.GetFolderPath(
            Environment.SpecialFolder.ApplicationData)
            + "\\BackUpManager";
        private static string applicationName = "Google Drive Manager";

        
        private static readonly string[] SizeSuffixes =
                  { "bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };


        public static bool GoogleDriveConnection(string jsonSecretPath, string userName)
        {

            return (getCredential(jsonSecretPath, userName) && createDriveService());

        }

        public static List<GoogleDriveFile> listDriveFiles(string fileName = null, string fileType = null)
        {
            List<GoogleDriveFile> filesList = new List<GoogleDriveFile>();

            try
            {
                if(fileName == null && fileType == null)
                {
                    FilesResource.ListRequest listRequest = service.Files.List();
                    listRequest.PageSize = 1000;
                    listRequest.Fields = "nextPageToken, files(mimeType, id, name, parents, size, modifiedTime, md5Checksum)";
                    //listRequest.OrderBy = "mimeType";
                    // List files.
                    IList<Google.Apis.Drive.v3.Data.File> files = listRequest.Execute().Files;

                    filesList.Clear();
                    if (files != null && files.Count > 0)
                    {
                        foreach (var file in files)
                        {
                            filesList.Add(new GoogleDriveFile(
                            file.Name,
                            sizeFix(file.Size.ToString(), file.MimeType),
                            file.ModifiedTime.ToString(),
                            file.MimeType,
                            file.Id, file.Md5Checksum));
                            System.Diagnostics.Debug.WriteLine("{0} {1} {2} {3}",
                                file.Name, file.Id, file.MimeType, file.Size.ToString());
                        }
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine("No files found.");
                    }
                }
                else
                {
                    string pageToken = null;
                    do
                    {
                        FilesResource.ListRequest request = service.Files.List();
                        request.PageSize = 1000;
                        //request.Q = "mimeType='image/jpeg'";
                        request.Q = "name contains '" + fileName + "'";
                        if (fileType != null)
                        {
                            request.Q += "and (mimeType contains '" + fileType + "')";
                        }
                        request.Spaces = "drive";
                        request.Fields = "nextPageToken, files(mimeType, id, name, parents, size, modifiedTime, md5Checksum)";
                        request.PageToken = pageToken;
                        var result = request.Execute();
                        foreach (var file in result.Files)
                        {
                            filesList.Add(new GoogleDriveFile(
                                file.Name,
                                sizeFix(file.Size.ToString(), file.MimeType),
                                file.ModifiedTime.ToString(),
                                file.MimeType,
                                file.Id, file.Md5Checksum));
                        }
                        pageToken = result.NextPageToken;
                    } while (pageToken != null);
                }

                
            }
            catch (Exception exc)
            {
                System.Diagnostics.Debug.WriteLine(exc.Message);
            }
            return filesList;
        }


        public static bool compareHash(string hashToCompare)
        {
            foreach (GoogleDriveFile file in GoogleDriveAPIV3.listDriveFiles())
            {
                if (file.hash == hashToCompare) return true;
            }
            return false;
        }
        
        private static string sizeFix(string bytesString, string type, int decimalPlaces = 1)
        {
            long value;
            if (long.TryParse(bytesString, out value))
            {
                if (value < 0) { return "-" + sizeFix((-value).ToString(), type); }

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
                return type.Split('.').Last();
            }
            
        }

        private static bool getCredential(string clientSecretPath, string userName)
        {
            string savePath = Path.Combine(appDataSavePath , Path.GetFileName(clientSecretPath));
            if (System.IO.File.Exists(savePath))
            {
                try
                {
                    using (var stream = new FileStream(savePath, FileMode.Open, FileAccess.Read))
                    {
                        string  credPath = Path.Combine(appDataSavePath, ".credentials");

                        credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                            GoogleClientSecrets.Load(stream).Secrets,
                            Scopes,
                            userName,
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
            else
            {
                System.IO.File.Copy(clientSecretPath, Path.Combine(appDataSavePath, Path.GetFileName(clientSecretPath)));
                return getCredential(clientSecretPath, userName);
            }
            
        }

        private static bool createDriveService()
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
                                    //MessageBox.Show("File failed to upload!!!", "Upload Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        public static string createFolderToDrive(string folderName, string parentId)
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
                System.Diagnostics.Debug.WriteLine("{0} {1}",file.Name, file.Id);
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
                    parentId,
                    name,
                    path,
                    getMimeType(Path.GetFileName(path)));
            }
            else
            {
                directoryUpload(path, parentId);
            }
        }

        public static void directoryUpload(string path, string parentId)
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


                FileInfo[] files = dir.GetFiles();
                foreach (FileInfo file in files)
                {
                    uploadFileToDrive(
                        folderId, file.Name,
                        Path.Combine(path, file.Name),
                        getMimeType(file.Name));
                }

                DirectoryInfo[] dirs = dir.GetDirectories();
                foreach (DirectoryInfo subdir in dirs)
                {
                    directoryUpload(subdir.FullName,  folderId);
                }
            }
            catch (Exception exc)
            {
                System.Diagnostics.Debug.WriteLine(exc.Message);
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
        public static void downloadFromDrive(string filename, string fileId, string savePath, string mimeType)
        {
            try
            {
                if (Path.HasExtension(filename))
                {
                    var request = service.Files.Get(fileId);
                    
                    var stream = new System.IO.MemoryStream();
                    System.Diagnostics.Debug.WriteLine(fileId);
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
                                        MessageBox.Show("File failed to download!!!", "Download Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        break;
                                    }
                            }
                        };
                    request.Download(stream);
                    convertMemoryStreamToFileStream(stream, savePath + @"\" + @filename);
                    stream.Dispose();
                }
                else
                {
                    string extension = "", converter = "";
                    foreach(MimeTypeConvert obj in MimeConverter.mimeList())
                    {
                        if (mimeType == obj.mimeType)
                        {
                            extension = obj.extension;
                            converter = obj.converterType;
                        }
                    }
                    System.Diagnostics.Debug.WriteLine("{0} {1} {2}", fileId, extension, mimeType);
                    var request = service.Files.Export(fileId, converter);
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
                                            Console.WriteLine(progress.BytesDownloaded);
                                            break;
                                        }
                                    case DownloadStatus.Completed:
                                        {
                                            Console.WriteLine("Download complete.");
                                            break;
                                        }
                                    case DownloadStatus.Failed:
                                        {
                                            Console.WriteLine("Download failed.");
                                            MessageBox.Show("File failed to download!!!", "Download Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            break;
                                        }
                                }
                            };
                    request.Download(stream);
                    convertMemoryStreamToFileStream(stream, savePath + @"\" + @filename + extension);
                    stream.Dispose();
                }

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

        

        private static void notify(string title, string text)
        {
            Application.Run(new NotifyIcon(title , text));
        }

        
    }
}
