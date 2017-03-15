using Google.Apis.Auth.OAuth2;
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
    public  class GoogleDriveAPIV3
    {
        private static string[] Scopes = { DriveService.Scope.Drive };
        private static UserCredential credential;
        private static DriveService service;

        public static bool GoogleDriveConnection(string jsonSecretPath, string appName)
        {

            return (getCredential(jsonSecretPath) && createDriveService(appName));

        }


        private static bool getCredential(string clientSecretPath)
        {
            try
            {
                using (var stream = new FileStream(clientSecretPath, FileMode.Open, FileAccess.Read))
                {
                    string credPath = System.Environment.GetFolderPath(
                        System.Environment.SpecialFolder.Personal);
                    credPath = Path.Combine(credPath, ".credentials/User");

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

        public static void uploadToDrive(string fileName, string filePath, string fileType)
        {
            try
            {
                var fileMetadata = new Google.Apis.Drive.v3.Data.File()
                {
                    Name = fileName
                };
                FilesResource.CreateMediaUpload request;
                using (var stream = new System.IO.FileStream(filePath,
                                        System.IO.FileMode.Open))
                {
                    request = service.Files.Create(
                        fileMetadata, stream, fileType);
                    request.Fields = "id";
                    request.Upload();
                }
                var file = request.ResponseBody;
            }
            catch (Exception exc)
            {
                System.Diagnostics.Debug.WriteLine(exc.Message);
            }

        }


    }
}
