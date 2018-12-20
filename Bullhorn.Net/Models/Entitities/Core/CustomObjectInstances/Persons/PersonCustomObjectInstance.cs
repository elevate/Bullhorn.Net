using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bullhorn.Net.Models.Entitities.Core.Standard;
using Newtonsoft.Json;

namespace Bullhorn.Net.Models.Entitities.Core.CustomObjectInstances.Persons
{
    public abstract class PersonCustomObjectInstance
    {
        [JsonProperty("person")]
        public Person Person { get; set; }
    }
}
