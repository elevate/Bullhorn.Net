using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bullhorn.Net.Models.Entitities.Core.Parameters.Standard
{
    public class StandardSearchParams : SearchParams
    {
        public int Count { get; set; }
        public string Sort { get; set; }
        public int Start { get; set; }
        public Dictionary<string, string> ParameterMap { get; set; }

        public bool ShowEditable { get; set; }

        public StandardSearchParams()
        {
            this.ShowEditable = false;
            this.Count = 20;
            this.Start = 0;
            this.Sort = null;
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
            if (Sort != null)
            {
                url.Append($"&sort={Sort}");
            }

            return url.ToString();
        }
    }
}
