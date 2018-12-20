using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bullhorn.Net.Models.Entitities.Core.Parameters.Standard
{
    public class StandardQueryParams : QueryParams
    {
        public int Count { get; set; }
        public int Start { get; set; }
        public string OrderBy { get; set; }
        public bool ShowTotalMatched { get; set; }
        public bool UseDefaultQueryFilter { get; set; }
       
        public Dictionary<string, string> ParameterMap { get; set; }

        public bool ShowEditable { get; set; }
        

        public StandardQueryParams()
        {
            this.ShowEditable = false;

            this.Count = 20;
            this.Start = 0;

            this.OrderBy = null;
            this.ShowTotalMatched = true;
            this.UseDefaultQueryFilter = true;
        }

        public string getUrlString()
        {
            StringBuilder url = new StringBuilder();

            if (ShowEditable != false)
            {
                url.Append($"&showEditable={ShowEditable}");
            }
            if (Count != 0)
            {
                url.Append($"&count={Count}");
            }
            if (Start != 0)
            {
                url.Append($"&start={Start}");
            }
            if (OrderBy != null)
            {
                url.Append($"&orderBy={OrderBy}");
            }
            if (ShowTotalMatched != false)
            {
                url.Append($"&showTotalMatched={ShowTotalMatched}");
            }
            if (UseDefaultQueryFilter != true)
            {
                url.Append($"&useDefaultQueryFilter={UseDefaultQueryFilter}");
            }

            return url.ToString();
        }
    }

}
