using Bullhorn.Net.Models.Entitities.Core.Type;
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
    /// Represents a person seeking a job
    /// </summary>
    public class Candidate: SearchEntity, CreateEntity
    {
        public static string EntityType = "Candidate";

        [JsonIgnore]
        public decimal LuceneScore { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        public Address address { get; set; }

        public Branch branch { get; set; }

        public List<BusinessSector> businessSectors{get;set;}

        public bool canEnterTime { get; set; }

        [JsonProperty("categories")]
        public List<Category> Categories { get; set; }

        [JsonProperty("category")]
        public Category Category { get; set; }

        public List<CandidateCertification> certificationList { get; set; }

        [JsonIgnore]
        public string certifications { get; set; }

        public List<ClientCorporation> clientCorporationBlackList { get; set; }

        public List<ClientCorporation> clientCorporationWhiteList { get; set; }

        [JsonProperty("comments")]
        public string Comments { get; set; }

        [JsonIgnore]


        public string companyName { get; set; }



        public string companyURL { get; set; }

        public DateTime dateAdded { get; set; }

        public DateTime dateAvailable { get; set; }

        public DateTime dateAvailableEnd { get; set; }

        public DateTime dateI9Expiration { get; set; }

        public DateTime dateLastComment { get; set; }

        public DateTime dateLastModified { get; set; }

        public DateTime dateNextCall { get; set; }

        public DateTime dateOfBirth { get; set; }

        public decimal dayRate { get; set; }

        public decimal dayRateLow { get; set; }

        

        [JsonIgnore]
        public string degreeList { get; set; }

        [JsonIgnore]
        public string description { get; set; }

        [JsonIgnore]
        public string desiredLocations { get; set; }

        [JsonIgnore]
        public string disability { get; set; }

        [JsonIgnore]
        public string educationDegree { get; set; }

        public List<CandidateEducation> educations { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        public string Email2 { get; set; }
        public string Email3 { get; set; }

        [JsonIgnore]
        public string employeeType { get; set; }

        [JsonIgnore]
        public string employmentPreference { get; set; }

        [JsonIgnore]
        public string ethnicity { get; set; }

        public int experience { get; set; }

        [JsonIgnore]
        public string externalID { get; set; }

        [JsonIgnore]
        public string fax { get; set; }

        [JsonIgnore]
        public string fax2 { get; set; }

        [JsonIgnore]
        public string fax3 { get; set; }

        public decimal federalAddtionalWitholdingsAmount { get; set; }

        public int federalExemptions { get; set; }

        [JsonIgnore]
        public string federalFilingStatus { get; set; }

        public List<StandardFileAttachment> fileAttachments { get; set; }

        public string firstName { get; set; }

        [JsonIgnore]
        public string gender { get; set; }

        public decimal hourlyRate { get; set; }

        public decimal hourlyRateLow { get; set; }

        [JsonIgnore]
        public List<Appointment> interviews { get; set; }

        public int i9OnFile { get; set; }

        public bool isDayLightSavings { get; set; }

        public bool isDeleted { get; set; }

        public bool isEditable { get; set; }

        public bool isLockedOut { get; set; }

        public bool isAnonymized { get; set; }

        public string lastName { get; set; }

        public Person linkedPerson { get; set; }

        public List<Lead> leads { get; set; }

        public decimal localAddtionalWitholdingsAmount { get; set; }

        public int localExemptions { get; set; }

        [JsonIgnore]
        public string localFilingStatus { get; set; }

        [JsonIgnore]
        public string localTaxCode { get; set; }

        public bool massMailOptOut { get; set; }

        [JsonIgnore]
        public string middleName { get; set; }

        public Object migrateGUID { get; set; }

        [JsonIgnore]
        public string mobile { get; set; }

        public string name { get; set; }

        [JsonIgnore]
        public string namePrefix { get; set; }

        [JsonIgnore]
        public string nameSuffix { get; set; }

        [JsonIgnore]
        public string nickName { get; set; }

        public List<Note> notes { get; set; }

        public int numCategories { get; set; }

        public int numOwners { get; set; }

        [JsonIgnore]
        public string occupation { get; set; }

        public CorporateUser owner { get; set; }

        [JsonIgnore]
        public string pager { get; set; }

        [JsonIgnore]
        public string paperWorkOnFile { get; set; }

        public string password { get; set; }

        public string phone { get; set; }

        [JsonIgnore]

        public string phone2 { get; set; }

        [JsonIgnore]
        public string phone3 { get; set; }

        public List<Placement> placements { get; set; }

        [JsonProperty("preferredContact")]
        public string PreferredContact { get; set; }

        public List<Skill> primarySkills { get; set; }

        [JsonIgnore]
        public string recentClientList { get; set; }

        [JsonIgnore]
        public string referredBy { get; set; }

        public Person referredByPerson { get; set; }

        public List<CandidateReference> references { get; set; }

        public decimal salary { get; set; }

        public decimal salaryLow { get; set; }

        public Address secondaryAddress { get; set; }

        public List<CorporateUser> secondaryOwners { get; set; }

        public List<Skill> secondarySkills { get; set; }

        public List<Sendout> sendouts { get; set; }

        [JsonIgnore]
        public string skillSet { get; set; }

        public bool smsOptIn { get; set; }

        [JsonIgnore]
        public string source { get; set; }

        public List<Specialty> specialties { get; set; }

        [JsonIgnore]
        public string ssn { get; set; }

        public decimal stateAddtionalWitholdingsAmount { get; set; }

        public int stateExemptions { get; set; }

        [JsonIgnore]
        public string stateFilingStatus { get; set; }

        public string status { get; set; }

        public List<JobSubmission> submissions { get; set; }

        public List<Task> tasks { get; set; }

        [JsonIgnore]
        public string taxID { get; set; }

        [JsonIgnore]
        public string taxState { get; set; }

        public List<Tearsheet> tearsheets { get; set; }

        public int timeZoneOffsetEST { get; set; }

        public int travelLimit { get; set; }

        [JsonIgnore]
        public string type { get; set; }

        public string username { get; set; }

        [JsonIgnore]
        public string veteran { get; set; }

        public List<JobSubmission> webResponses { get; set; }

        public bool willRelocate { get; set; }

        public bool workAuthorized { get; set; }

        public List<CandidateWorkHistory> workHistories { get; set; }

        [JsonIgnore]
        public string workPhone { get; set; }

        [JsonIgnore]
        public string customEncryptedText1 { get; set; }

        [JsonIgnore]
        public string customEncryptedText2 { get; set; }

        [JsonIgnore]
        public string customEncryptedText3 { get; set; }

        [JsonIgnore]
        public string customEncryptedText4 { get; set; }

        [JsonIgnore]
        public string customEncryptedText5 { get; set; }

        [JsonIgnore]
        public string customEncryptedText6 { get; set; }

        [JsonIgnore]
        public string customEncryptedText7 { get; set; }

        [JsonIgnore]
        public string customEncryptedText8 { get; set; }

        [JsonIgnore]
        public string customEncryptedText9 { get; set; }

        [JsonIgnore]
        public string customEncryptedText10 { get; set; }




        //public List<PersonCustomObjectInstance1> customObject1s;

        //public List<PersonCustomObjectInstance2> customObject2s;

        //public List<PersonCustomObjectInstance3> customObject3s;

        //public List<PersonCustomObjectInstance4> customObject4s;

        //public List<PersonCustomObjectInstance5> customObject5s;

        //public List<PersonCustomObjectInstance6> customObject6s;

        //public List<PersonCustomObjectInstance7> customObject7s;

        //public List<PersonCustomObjectInstance8> customObject8s;

        //public List<PersonCustomObjectInstance9> customObject9s;

        //public List<PersonCustomObjectInstance10> customObject10s;

        public Candidate()
        {

        }

        public Candidate(int id)
        {
            this.Id = id;
        }

        public static Candidate InstantiateForInsert()
        {
            Candidate entity = new Candidate();
            entity.Category = new Category(2000000);
            entity.isDeleted = false;
            entity.employeeType = "W2";
            entity.Comments = "test candidate by API, janiek";
            entity.PreferredContact = "Email";
            entity.firstName = "";
            entity.name = "";
            entity.lastName = "";
            entity.status = "New Lead";
            entity.username = DateTime.Now.ToShortTimeString();
            entity.password = "secret";

            entity.owner = new CorporateUser(1);

            return entity;
        }

        public static void setRequiredFieldsForInsert(Candidate candidate)
        {
            if (candidate.Category == null)
            {
                candidate.Category = new Category(512973);
            }
            if (candidate.Comments == null)
            {
                candidate.Comments = "New lead candidate";
            }
            if (candidate.employeeType == null)
            {
                candidate.employeeType = "W2";
            }
            if (candidate.PreferredContact == null)
            {
                candidate.PreferredContact = "Email";
            }
            if (candidate.status == null)
            {
                candidate.status = "New Lead";
            }
            if (candidate.owner == null)
            {
                candidate.owner = new CorporateUser(1);
            }
            if (candidate.username == null)
            {
                candidate.username = DateTime.Now.ToShortTimeString();
            }
            if (candidate.password == null)
            {
                candidate.password= "secret";
            }

            if (candidate.name == null)
            {
                if (candidate.firstName != null && candidate.lastName != null)
                {
                    candidate.name = candidate.firstName + " " + candidate.lastName;
                }
                else
                {
                    candidate.name = "";
                }
            }

        }
    }
}
