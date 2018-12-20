using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bullhorn.Net.Models.Entitities.Core.Parameters
{
    public interface RequestParameters
    {
        string getUrlString();
        Dictionary<string, string> ParameterMap { get; set; }

    }
}
