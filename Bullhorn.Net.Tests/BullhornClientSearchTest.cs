using Bullhorn.Net.Models.Entitities.Core.Parameters.Standard;
using Bullhorn.Net.Models.Entitities.Core.Standard;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bullhorn.Net.Tests
{
    [TestClass]
    public class BullhornClientSearchTest : BaseTest
    {
        [TestMethod]
        public void SearchCandidatesTest()
        {
            var result = bullhornClient.SearchForList<Candidate>(Candidate.EntityType, "isDeleted=-1");
            Console.WriteLine(result);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void SearchExistingCandidate()
        {

            string query = $"firstName:Janiek AND lastName:Colpaert AND email:janiek@oakstreet.be";
            string[] fields = new string[] { "id", "firstName", "lastName", "email"};
            List<Candidate> candidates = bullhornClient.SearchForList<Candidate>(Candidate.EntityType, query, fields);

            Assert.AreNotEqual(0, candidates.Count);

        }

        [TestMethod]
        public void GetJobOrdersTest()
        {
            var result = bullhornClient.SearchForList<JobOrder>(JobOrder.EntityType, "isPublic:1");
            Assert.IsNotNull(result);
            Assert.AreNotEqual(0, result.Count);
        }

        [TestMethod]
        public void SearchForAllJobOrdersTest()
        {
            var result = bullhornClient.SearchForAllRecords<JobOrder>(JobOrder.EntityType, "isPublic:1", new string[] {
                "title","numOpenings", "publicDescription", "owner", "categories",
                "isPublic", "dateClosed", "employmentType", "certificationList", "hoursPerWeek",
                "id", "isOpen", "address", "dateAdded", "responseUser","yearsRequired", "externalCategoryID" }, new StandardSearchParams());

            Assert.IsNotNull(result);
            Assert.AreNotEqual(0, result.Count);
        }
    }
}
