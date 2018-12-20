using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bullhorn.Net.Models.Response.File
{
    public interface FileApiResponse
    {
        int FileId { get; set; }

        string ChangeType { get; set; }
    }
}
