using Bullhorn.Net.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bullhorn.Net.Models.Entitities.Core.Parameters
{
    public interface FileParams: RequestParameters
    {
        FileContentType ContentType { get; set; }
        string Description { get; set; }
        string Type { get; set; }
    }
}
