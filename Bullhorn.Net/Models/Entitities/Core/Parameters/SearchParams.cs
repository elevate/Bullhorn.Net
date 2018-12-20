using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bullhorn.Net.Models.Entitities.Core.Parameters
{
    public interface SearchParams : RequestParameters
    {
        int Count { get; set; }

        string Sort { get; set; }

        int Start { get; set; }

    }
}
