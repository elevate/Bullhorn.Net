using System;
using System.Collections.Generic;
using Bullhorn.Net.Helper;
using Bullhorn.Net.Models;
using Bullhorn.Net.Models.Entitities.Core.Parameters;
using Bullhorn.Net.Models.Entitities.Core.Parameters.Standard;
using Bullhorn.Net.Models.Entitities.Core.Standard;
using Bullhorn.Net.Models.Response;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bullhorn.Net.Tests
{
    [TestClass]
    public class BullhornClientTest: BaseTest
    {

        [TestMethod]
        public void FindCandidateTest()
        {
            var result = bullhornClient.findEntity<Candidate>(Candidate.EntityType, 8138);
            Console.WriteLine(result);
            Assert.IsNotNull(result);
        }

     

        [TestMethod]
        public void FindJobOrderTest()
        {
            var result = bullhornClient.findEntity<JobOrder>(JobOrder.EntityType, 76);
            Assert.IsNotNull(result);
            Assert.AreNotEqual(0, result.Id);
        }

        [TestMethod]
        public void FindJobSubmissionTest()
        {
            var result = bullhornClient.findEntity<JobSubmission>(JobSubmission.EntityType, 76);
            Assert.IsNotNull(result);
            Assert.AreNotEqual(0, result.Id);
        }

        //[TestMethod]
        public void AddFile()
        {
            var result = bullhornClient.addFile(Candidate.EntityType, 10792, base64encodedCV, "test", new StandardFileParams());
            Assert.IsNotNull(result);
            Assert.AreNotEqual(0, result.FileId);
        }


        private string base64encodedCV = "***";

    }
}
