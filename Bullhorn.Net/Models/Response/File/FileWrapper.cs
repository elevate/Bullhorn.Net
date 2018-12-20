using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bullhorn.Net.Models.Entitities.Core.Standard;

namespace Bullhorn.Net.Models.Response.File
{
    public interface FileWrapper
    {
        int Id { get; set; }

        Models.Entitities.Core.Standard.File File { get; set; }

        string Type { get; set; }

        string Name { get; set; }

        string Description { get; set; }

        string ContentType { get; set; }

        string ContentSubType { get; set; }

        string FileType { get; set; }

        string ExternalID { get; set; }

        DateTime DateAdded { get; set; }

        string Distribution { get; set; }
    }
}
