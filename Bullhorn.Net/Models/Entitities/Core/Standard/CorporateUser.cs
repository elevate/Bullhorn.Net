using Bullhorn.Net.Models.Entitities.Embedded;
using Newtonsoft.Json;

namespace Bullhorn.Net.Models.Entitities.Core.Standard
{
    /// <summary>
    /// Represents an Internal user at your organisation. CorporateUser is read-only
    /// </summary>
    public class CorporateUser
    {
        public static string EntityType = "CorporateUser";

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("address")]
        public Address Address { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("email2")]
        public string Email2 { get; set; }

        [JsonProperty("email3")]
        public string Email3 { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        /// <summary>
        /// Name of the CorporateUser
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Occupation of the CorporateUser
        /// </summary>
        [JsonProperty("occupation")]
        public string Occupation { get; set; }

        public CorporateUser(int id)
        {
            this.Id = id;
        }
    }
}