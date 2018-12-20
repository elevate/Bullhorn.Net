using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bullhorn.Net.Models.Enums
{
    //[Flags]
    //public enum FileContentType : string
    //{
    //    DOC = "application/msword",
    //    DOCX("application/vnd.openxmlformatsofficedocument.wordprocessingml.document"),
    //    HTML("text/html"),
    //    ODT("application/vnd.oasis.opendocument.text"),
    //    PDF("application/pdf"),
    //    RTF("application/rtf"),
    //    TXT("text/plain")
    //}

    public class FileContentType
    {
        public static string DOC = "application/msword";
        public static string DOCX = "application/vnd.openxmlformatsofficedocument.wordprocessingml.document";
        public static string HTML = "text/html";
        public static string ODT = "application/vnd.oasis.opendocument.text";
        public static string PDF = "application/pdf";
        public static string RTF = "application/rtf";
        public static string TXT = "text/plain";
    }
}
