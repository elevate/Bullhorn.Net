using System;
using System.Configuration;
using Bullhorn.Net.Models.Entitities.Core.Parameters.Standard;
using Bullhorn.Net.Models.Entitities.Core.Standard;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bullhorn.Net.Tests
{
    [TestClass]
    public class BullhornClientQueryTest: BaseTest
    {

        [TestMethod]
        public void QueryCertificationTest()
        {
            var result = bullhornClient.queryForAllRecords<Certification>(Certification.EntityType, "name='*'", null, new StandardQueryParams());

            Console.WriteLine(result);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void QueryCorporateUserTest()
        {
            var result = bullhornClient.queryForAllRecords<CorporateUser>(CorporateUser.EntityType, "enabled=true", null, new StandardQueryParams());

            Console.WriteLine(result);
            Assert.IsNotNull(result);
            Assert.AreNotEqual(0, result.Count);
        }

        [TestMethod]
        public void QueryCategoriesTest()
        {
            var result = bullhornClient.queryForAllRecords<Category>(Category.EntityType, "enabled=true", null, new StandardQueryParams());

            Assert.IsNotNull(result.Count);
            //Assert.AreNotEqual(0, result.Count);
        }
    }
}
