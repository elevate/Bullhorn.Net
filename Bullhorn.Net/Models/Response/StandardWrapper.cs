using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bullhorn.Net.Models.Response
{
    public class StandardWrapper<T>
    {
        [JsonProperty("data")]
        public T Data { get; set; }
    }
}
