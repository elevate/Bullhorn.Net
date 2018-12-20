using Bullhorn.Net.Helper;
using Bullhorn.Net.Models.Entitities.Embedded;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bullhorn.Net.Models.Entitities.Core.Standard
{
    /// <summary>
    /// This entity represents a category in which a Candidate or JobOrder can be placed. 
    /// A category that has a value for parentCategoryId greater than zero is anty.
    /// </summary>
    public class Category
    {
        [JsonIgnore]
        public static string EntityType = "Category";

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonConverter(typeof(UnixTimeConverter))]
        public DateTime DateAdded { get; set; }

        public string Description { get; set; }

        public bool Enabled { get; set; }

        public object ExternalID { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
       
        public string Occupation { get; set; }

        public OneToMany<PrivateLabel> PrivateLabels { get; set; }
        public OneToMany<Skill> Skills { get; set; }
        public OneToMany<Category> Specialties { get; set; }

        [JsonIgnore()]
        public string Type { get; set; }

        public Category()
        {

        }

        public Category(int id)
        {
            this.Id = id;
        }



    }
}
