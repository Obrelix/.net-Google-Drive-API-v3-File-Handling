using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleDriveManager
{
    public class MimeTypeConvert
    {
        public string extension { get; set; }

        public string mimeType { get; set; }
        public string converterType { get; set; }
        public MimeTypeConvert()
        {

        }
        public MimeTypeConvert(string extension, string type, string converter)
        {
            this.extension = extension;
            mimeType = type;
            converterType = converter;
        }
    }
    public static class MimeConverter
    {
        public static List<MimeTypeConvert> mimeList()
        {
            List<MimeTypeConvert> list = new List<MimeTypeConvert>();
            list.Add(new MimeTypeConvert(".xlsx", "application/vnd.google-apps.spreadsheet", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"));
            list.Add(new MimeTypeConvert(".doc", "application/vnd.google-apps.document", "application/vnd.openxmlformats-officedocument.wordprocessingml.document"));
            list.Add(new MimeTypeConvert(".pptx", "application/vnd.google-apps.presentation", "application/vnd.openxmlformats-officedocument.presentationml.presentation"));
            list.Add(new MimeTypeConvert(".html", "application/vnd.google-apps.site", "text/html"));
            list.Add(new MimeTypeConvert(".zip", "application/vnd.google-apps.folder", "application/vnd.google-apps.folder"));
            
            return list;
        }
    }
}
