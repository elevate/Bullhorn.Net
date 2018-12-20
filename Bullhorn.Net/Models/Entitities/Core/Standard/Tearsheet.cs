using Bullhorn.Net.Models.Entitities.Embedded;
using System;

namespace Bullhorn.Net.Models.Entitities.Core.Standard
{
    public class Tearsheet
    {
        public int Id { get; set; }

        public OneToMany<Candidate> Candidates { get; set; }

        public OneToMany<ClientContact> ClientContacts { get; set; }

        public DateTime DateAdded { get; set;}

        public string Description { get; set;}

        public bool IsDeleted { get; set;}

        public bool Ispublic { get; set;}

        public OneToMany<JobOrder> jobOrders { get; set;}

        public string Name { get; set;}

        public CorporateUser Owner { get; set;}

        public Tearsheet()
        {
            
        }

        public Tearsheet instantiateForInsert()
        {
            Tearsheet entity = new Tearsheet();
            entity.IsDeleted = false;
            entity.Name = "Test Tearsheet";
            return entity;
        }
    }
}