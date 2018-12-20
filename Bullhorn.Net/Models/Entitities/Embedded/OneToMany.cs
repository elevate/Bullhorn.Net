using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bullhorn.Net.Models.Entitities.Embedded
{
    public class OneToMany<T>
    {
        [JsonProperty("data")]
        public List<T> Data { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }
    }
}
