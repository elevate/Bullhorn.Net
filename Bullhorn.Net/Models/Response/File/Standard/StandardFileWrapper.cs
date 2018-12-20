using Bullhorn.Net.Helper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bullhorn.Net.Models.Response.File.Standard
{
    public class StandardFileWrapper
    {
        public byte[] FileContentAsByteArray { get; set; }

        //public Models.Entitities.Core.Standard.File file { get; set; }

        public string base64RawFileContent { get; set; }

        [JsonIgnore]
        public int Id { get; set; }

        public string Type { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string FileContent { get; set; }

        public string ContentType { get; set; }

        public string ContentSubType { get; set; }

        public string FileType { get; set; }

        public string ExternalID { get; set; }

        [JsonConverter(typeof(UnixTimeConverter))]
        public DateTime DateAdded { get; set; }

        public string Distribution { get; set; }

        public StandardFileWrapper()
        {

        }

        public StandardFileWrapper(string base64RawFileContent)
        {
            this.FileContent = base64RawFileContent;
            this.ExternalID = DateTime.Now.ToLongTimeString();
            this.Name = "testFile";
            this.FileType = "SAMPLE";
            this.DateAdded = DateTime.Now;

        }

    }
}
