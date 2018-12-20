using Bullhorn.Net.Helper;
using Bullhorn.Net.Models.Entitities.Core.Type;
using Bullhorn.Net.Models.Entitities.Embedded;
using Newtonsoft.Json;
using System;

namespace Bullhorn.Net.Models.Entitities.Core.Standard
{
    /// <summary>
    /// Represents a formal submission of a Candidate for a particular job. 
    /// A job submission occurs after the Candidate has been evaluated, interviewed, 
    /// and otherwise assessed, and the parties involved have agreed that the Candidate 
    /// may be suitable. The JobSubmission entity is then created with 
    /// references to the Candidate and the JobOrder representing the position. 
    /// If the JobSubmission is approved, a Placement entity is created.
    /// </summary>
    public class JobSubmission: CreateEntity
    {
        public static string EntityType = "JobSubmission";

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonIgnore]
        public OneToManyLinkedId Appointments { get; set; }


        public decimal BillRate { get; set; }

        public Branch Branch { get; set; }

        [JsonProperty("candidate")]
        public Candidate Candidate { get; set; }


        public string CustomText1 { get; set; }
        public string CustomText2 { get; set; }
        public string CustomText3 { get; set; }
        public string CustomText4 { get; set; }
        public string CustomText5 { get; set; }

        [JsonConverter(typeof(UnixTimeConverter))]
        [JsonProperty("dateAdded")]
        public DateTime DateAdded { get; set; }

        [JsonConverter(typeof(UnixTimeConverter))]
        [JsonProperty("dateLastModified")]
        public DateTime DateLastModified { get; set; }

        [JsonConverter(typeof(UnixTimeConverter))]
        [JsonProperty("dateWebResponse")]
        public DateTime DateWebResponse { get; set; }

    
        public bool IsDeleted { get; set; }
    
        public bool IsHidden { get; set; }

        [JsonProperty("jobOrder")]
        public JobOrder JobOrder { get; set; }
        public string MigrateGUID { get; set; }

        public decimal PayRate { get; set; }
        public decimal Salary { get; set; }

        public CorporateUser SendingUser { get; set; }

        public string Status { get; set; }

        public static JobSubmission InstantiateForInsert()
        {
            JobSubmission entity = new JobSubmission();

            entity.IsDeleted = false;
            entity.Status = "Submitted";
            entity.Candidate = new Candidate(1);
            entity.JobOrder = new JobOrder(1);

            entity.DateAdded = DateTime.Now;
            entity.DateLastModified = DateTime.Now;
            entity.DateWebResponse = DateTime.Now;

            return entity;
        }
    }
}