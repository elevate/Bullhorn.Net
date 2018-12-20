using Bullhorn.Net.Models.Entitities.Core.Type;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bullhorn.Net.Models.Response
{
    public class StandardListWrapper<T> : IListWrapper<T>
    {
        [JsonProperty("data")]
        public List<T> Data { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("start")]
        public int Start { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }

        public StandardListWrapper()
        {

        }

        public StandardListWrapper(List<T> data)
        {
            this.Data = data;
            this.Count = data.Count;
        }
    }
}
