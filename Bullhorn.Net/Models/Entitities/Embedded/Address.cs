using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Bullhorn.Net.Models.Entitities.Embedded
{
    public class Address
    {
        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string City { get; set; }

        [JsonIgnore]
        public string State { get; set; }

        public string Zip { get; set; }

        [JsonProperty("countryID")]
        public int CountryID { get; set; }
        public string CountryName { get; set; }

        public Address()
        {

        }

        public Address(string address1, string address2, string zip, string city, string countryName)
        {
            this.Address1 = address1;
            this.Address2 = address2;
            this.Zip = zip;
            this.City = city;
            this.CountryName = countryName;
        }


        public override string ToString()
        {
            string result = "";

            List<string> data = new List<string> { this.Address1, this.Address2, this.Zip, this.City, this.CountryName};

            data.ForEach(p => {
                if (!String.IsNullOrEmpty(p))
                {
                    result += p + " ";
                }   
             });

            return result.Trim();
        }
    }
}