using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System.IO;
using System.Threading;

namespace GoogleDriveManager
{

    public class GoogleCaledar
    {
        public string summary { get; set; }
        public string when { get; set; }
        public string udpated { get; set; }
        public string id { get; set; }
        public string status { get; set; }
        public string updatedRaw { get; set; }

        public GoogleCaledar(string summary, string when, string updated, string id, string status, string updatedRaw)
        {
            this.summary = summary;
            this.when = when;
            this.udpated = udpated;
            this.id = id;
            this.status = status;
            this.updatedRaw = updatedRaw;
        }
    }

    public static class GoogleCalendarAPIV3
    {
        static string[] Scopes = { CalendarService.Scope.Calendar };
        static UserCredential credential;
        static CalendarService calendarService;

        private static string appDataSavePath = Environment.GetFolderPath(
            Environment.SpecialFolder.ApplicationData)
            + "\\BackUpManager";
        private static string applicationName = "Google Calendar Manager";

        public static bool GoogleCalendarConnection(string jsonSecretPath, string userName)
        {
            return (getCredential(jsonSecretPath, userName) && createCalendarService());
        }

        private static bool getCredential(string clientSecretPath, string userName)
        {
            string savePath = Path.Combine(appDataSavePath, Path.GetFileName(clientSecretPath));
            if (System.IO.File.Exists(savePath))
            {
                try
                {
                    using (var stream = new FileStream(savePath, FileMode.Open, FileAccess.Read))
                    {
                        string credPath = Path.Combine(appDataSavePath, ".credentials");

                        credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                            GoogleClientSecrets.Load(stream).Secrets,
                            Scopes,
                            "Calendar-" + userName,
                            CancellationToken.None,
                            new FileDataStore(credPath, true)).Result;
                    }
                    return true;

                }
                catch (Exception exc)
                {
                    System.Diagnostics.Debug.WriteLine(exc.Message + " Get Credential Error");
                    Gtools.writeToFile(frmMain.errorLog, Environment.NewLine + DateTime.Now.ToString() +
                            Environment.NewLine + exc.Message + " Get Credential Error.\n");
                    return false;
                }
            }
            else
            {
                System.IO.File.Copy(clientSecretPath, Path.Combine(appDataSavePath, Path.GetFileName(clientSecretPath)));
                return getCredential(clientSecretPath, userName);
            }

        }

        private static bool createCalendarService()
        {
            try
            {
                // Create Drive API service.
                calendarService = new CalendarService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = applicationName,
                });
                return true;
            }
            catch (Exception exc)
            {
                System.Diagnostics.Debug.WriteLine(exc.Message + " Create Calendar Service Error.\n");
                Gtools.writeToFile(frmMain.errorLog, Environment.NewLine + DateTime.Now.ToString() +
                            Environment.NewLine + exc.Message + " Create Calendar Service Error.\n");
                return false;
            }

        }

        public static List<GoogleCaledar> listCalendar()
        {
            List<GoogleCaledar> calList = new List<GoogleCaledar>();
            try
            {
                EventsResource.ListRequest request = calendarService.Events.List("primary");
                request.TimeMin = DateTime.Now;
                request.ShowDeleted = false;
                request.SingleEvents = true;
                request.MaxResults = 10;
                request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;

                // List events.
                Events events = request.Execute();
                System.Diagnostics.Debug.WriteLine("Upcoming events:");
                if (events.Items != null && events.Items.Count > 0)
                {
                    foreach (var eventItem in events.Items)
                    {
                        string when = eventItem.Start.DateTime.ToString();
                        if (String.IsNullOrEmpty(when))
                        {
                            when = eventItem.Start.Date;
                        }
                        System.Diagnostics.Debug.WriteLine("{0} ({1})", eventItem.Summary, when);
                        calList.Add(new GoogleCaledar(eventItem.Summary, when, eventItem.Updated.ToString(), eventItem.Id, eventItem.Status, eventItem.UpdatedRaw.ToString()));
                    }
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("No upcoming events found.");
                }
            }
            catch (Exception exc)
            {
                System.Diagnostics.Debug.WriteLine(exc.Message + " Create Drive Service Error.\n");
                Gtools.writeToFile(frmMain.errorLog, Environment.NewLine + DateTime.Now.ToString() +
                            Environment.NewLine + exc.Message + " Create Drive Service Error.\n");
            }

            return calList;
        }

    }
}
