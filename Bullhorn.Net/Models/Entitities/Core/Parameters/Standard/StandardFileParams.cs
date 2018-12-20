using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bullhorn.Net.Models.Enums;

namespace Bullhorn.Net.Models.Entitities.Core.Parameters.Standard
{
    public class StandardFileParams : FileParams
    {
        public Dictionary<string, string> ParameterMap { get; set; }

        public string FileType { get; set; }

        public string getUrlString()
        {
            StringBuilder url = new StringBuilder();

            if (ContentType != null)
            {
                url.Append($"&contentType={ContentType}");
            }
            if (Description != null)
            {
                url.Append($"&description={Description}");
            }
            if (Type != null)
            {
                url.Append($"&type={Type}");
            }
            if (FileType != null)
            {
                url.Append($"&fileType={FileType}");
            }

            return url.ToString();
        }

        public FileContentType ContentType { get; set; }

        public string Description { get; set; }
        

        public string Type { get; set; }
    }
}
