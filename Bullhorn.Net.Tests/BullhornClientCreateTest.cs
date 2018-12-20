using System;
using Bullhorn.Net.Models.Entitities.Core.Standard;
using Bullhorn.Net.Models.Entitities.Core.Type;
using Bullhorn.Net.Models.Response.Crud;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bullhorn.Net.Tests
{
    [TestClass]
    public class BullhornClientCreateTest: BaseTest
    {
        private int entityId;
        private string deleteType;

        [TestCleanup]
        public void CleanUp()
        {
            if (entityId != 0 && deleteType != null)
            {
                //DeleteResponse response = bullhornClient.deleteEntity(deleteType, entityId) as DeleteResponse;
                //Assert.IsNotNull(response, "Error deleting response");
            }

        }

        [TestMethod]
        public void CreateCandidateTest()
        {
            Candidate entity = Candidate.InstantiateForInsert();
            entity.name = "Janiek Colpaert";
            entity.firstName = "Janiek";
            entity.lastName = "Colpaert";
            entity.Email = "janiek@oakstreet.be";
            entity.status = "Pre-Registered";
            entity.owner = new CorporateUser(3);

            entity.address = new Models.Entitities.Embedded.Address("Sint-Pietersmolenstraat 3E", "", "8000", "Brugge", "België");

            CreateResponse response = bullhornClient.insertEntity(Candidate.EntityType, entity) as CreateResponse;

            Assert.IsNotNull(response);

            this.entityId = response.ChangedEntityId;
            this.deleteType = Candidate.EntityType;
            Console.WriteLine(entityId);
            if(response.ChangedEntityId != 0)
            {
                Candidate newEntity = bullhornClient.findEntity<Candidate>(Candidate.EntityType, Convert.ToInt32(response.ChangedEntityId)) as Candidate;
                Assert.IsNotNull(newEntity);
            }
            else
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void CreateJobSubmissionTest()
        {
            JobSubmission entity = JobSubmission.InstantiateForInsert();
            entity.Candidate = new Candidate(10795);
            entity.JobOrder = new JobOrder(33);

            CreateResponse response = bullhornClient.insertEntity<JobSubmission>(JobSubmission.EntityType, entity) as CreateResponse;

            this.entityId = response.ChangedEntityId;
            this.deleteType = JobSubmission.EntityType;

            JobSubmission newEntity = bullhornClient.findEntity<JobSubmission>(JobSubmission.EntityType, response.ChangedEntityId);

            runAssertions(response, entity, newEntity);
        }


        private  void runAssertions(CreateResponse response, CreateEntity oldEntity, CreateEntity newEntity)
        {
            Assert.IsNotNull(response, "response is null");
            Assert.IsFalse(response.HasValidationErrors,"Validation failed");
            Assert.IsNotNull( response.ChangedEntityId, "no entityId in response");
            //Assert.IsFalse(, response.isError, "response is error");
            Assert.IsNotNull(newEntity, "new entity null");
            Assert.IsFalse(newEntity.Id == 0, "new entity id null");
            Assert.IsFalse( oldEntity.Id == newEntity.Id, "new and old entity ids are the same");
        }

    }
}
