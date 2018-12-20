using Bullhorn.Net.Helper;
using Bullhorn.Net.Models.Entitities.Core.CustomObjectInstances.JobOrders;
using Bullhorn.Net.Models.Entitities.Core.Type;
using Bullhorn.Net.Models.Entitities.Embedded;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Bullhorn.Net.Models.Entitities.Core.Standard
{
    public class JobData: BullhornEntity
    {
        public decimal? luceneScore;

        [JsonProperty("id")]
        public int Id { get; set; }

        public Address address;

        public OneToMany<Specialty> appointments;

        public OneToMany<Placement> approvedPlacements;

        public OneToMany<CorporateUser> assignedUsers;

        [JsonIgnore]
        public string benefits;

        public int? billRateCategoryID;

        [JsonIgnore]
        public string bonusPackage;

        public Branch branch;

        [JsonIgnore]
        public string branchCode;

        public OneToMany<BusinessSector> businessSectors;

        public OneToMany<Category> categories;

        [JsonIgnore]
        public string certificationList;

        public OneToMany<Certification> certifications;

        public OneToMany<CertificationGroup> certificationGroups;

        public decimal? clientBillRate;

        public ClientContact clientContact;

        public ClientCorporation clientCorporation;

        [JsonIgnore]
        public string costCenter;

        [JsonConverter(typeof(UnixTimeConverter))]
        public DateTime? dateAdded;

        [JsonConverter(typeof(UnixTimeConverter))]
        public DateTime? dateClosed;

        [JsonConverter(typeof(UnixTimeConverter))]
        public DateTime? dateEnd;

        [JsonConverter(typeof(UnixTimeConverter))]
        public DateTime? dateLastExported;

        [JsonConverter(typeof(UnixTimeConverter))]
        public DateTime? dateLastModified;

        [JsonIgnore]
        public string degreeList;

        public string description;

        public decimal? durationWeeks;

        [JsonIgnore]
        public string educationDegree;

        public string employmentType;

        public int? externalCategoryID;

        [JsonIgnore]
        public string externalID;

        public decimal? feeArrangement;

        [JsonIgnore]
        public string hoursOfOperation;

        public decimal? hoursPerWeek;

        public OneToMany<Appointment> interviews;

        public bool isClientEditable;

        public bool isDeleted;

        public bool isInterviewRequired;

        public Object isJobcastPublished;

        public bool isOpen;

        public int? isPublic;

        [JsonIgnore]
        public string jobBoardList;

        public OneToMany<Note> notes;

        public int? numOpenings;

        [JsonIgnore]
        public string onSite;

        [JsonIgnore]
        public string optionsPackage;

        public Opportunity opportunity;

        public CorporateUser owner;

        public decimal? payRate;

        public OneToMany<Placement> placements;

        [JsonProperty("publicDescription")]
        public string PublicDescription { get; set; }

        [JsonIgnore]
        public string publishedZip;

        [JsonIgnore]
        public string reasonClosed;

        [JsonIgnore]
        public string reportTo;

        public ClientContact reportToClientContact;

        public CorporateUser responseUser;

        public decimal? salary;

        [JsonIgnore]
        public string salaryUnit;

        public OneToMany<Sendout> sendouts;

        [JsonIgnore]
        public string skillList;

        public OneToMany<Skill> skills;

        [JsonIgnore]
        public string source;

        public OneToMany<Specialty> specialties;

        /// <summary>
        /// When freelancer has to start working on the project
        /// </summary>
        [JsonConverter(typeof(UnixTimeConverter))]
        [JsonProperty("startDate")]
        public DateTime? StartDate;

        [JsonIgnore]
        public string status;

        public OneToMany<JobSubmission> submissions;

        public OneToMany<Task> tasks;

        public decimal? taxRate;

        [JsonIgnore]
        public string taxStatus;

        public OneToMany<Tearsheet> tearsheets;

        public OneToMany<TimeUnit> timeUnits;

        /// <summary>
        /// Job title 
        /// </summary>
        [JsonProperty("title")]
        public string Title;

        [JsonIgnore]
        public string travelRequirements;

        public int? type;

        public OneToMany<JobSubmission> webResponses;

        public bool willRelocate;

        public int? willRelocateInt;

        public bool willSponsor;

        public WorkersCompensationRate workersCompRate;

        public int? yearsRequired;

        public OneToMany<JobOrderCustomObjectInstance1> customObject1s;
        public OneToMany<JobOrderCustomObjectInstance2> customObject2s;
        public OneToMany<JobOrderCustomObjectInstance3> customObject3s;
        public OneToMany<JobOrderCustomObjectInstance4> customObject4s;
        public OneToMany<JobOrderCustomObjectInstance5> customObject5s;
        public OneToMany<JobOrderCustomObjectInstance6> customObject6s;
        public OneToMany<JobOrderCustomObjectInstance7> customObject7s;
        public OneToMany<JobOrderCustomObjectInstance8> customObject8s;
        public OneToMany<JobOrderCustomObjectInstance9> customObject9s;
        public OneToMany<JobOrderCustomObjectInstance10> customObject10s;

        public JobData()
        {

        }

        public JobData(int id)
        {
            this.Id = id;
        }
    }
}