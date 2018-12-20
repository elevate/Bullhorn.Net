using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bullhorn.Net.Models.Entitities.Core.Parameters
{
    public interface QueryParams : RequestParameters
    {
        /// <summary>
        /// Limit on the number of entities to return. default is 15.
        /// </summary>
        int Count { get; set; }

        /// <summary>
        /// From the set of matched results, return item numbers start through (start + count)
        /// </summary>
        int Start { get; set; }

        /// <summary>
        /// Comma-separated list of field names on which to base the order of returned entities. Precede field name with a
        ///minus sign(-) or plus sign(+) to sort results in descending or ascending order based on that field; default is
        ///ascending order.
        /// </summary>
        string OrderBy { get; set; }

        /// <summary>
        /// Whether to show the total number of items that match the query
        /// </summary>
        bool ShowTotalMatched { get; set; }

        /// <summary>
        /// Whether to use the default part of the query
        /// </summary>
        bool UseDefaultQueryFilter { get; set; }

    }
}
