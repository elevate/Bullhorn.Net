using System;
using Bullhorn.Net.Helper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bullhorn.Net.Tests.Helper
{
    [TestClass]
    public class RestApiSessionTest
    {
        private RestApiSession restApiSession;

        private BullhornRestCredentials bullhornRestCredentials;

        [TestInitialize]
        public void Initialize()
        {
            bullhornRestCredentials = new BullhornRestCredentials();
            bullhornRestCredentials.RestAuthorizeUrl = "https://auth9.bullhornstaffing.com/oauth/authorize";
            bullhornRestCredentials.RestLoginUrl = "https://rest9.bullhornstaffing.com/rest-services/login";
            bullhornRestCredentials.RestTokenUrl = "https://auth9.bullhornstaffing.com/oauth/token";
            bullhornRestCredentials.RestSessionMinutesToLive = 1400;
            bullhornRestCredentials.Username = "digitals.api";
            bullhornRestCredentials.Password = "janiek@digitals";
            bullhornRestCredentials.RestClientId = "7575e977-498a-41e7-aeca-dc56101cca31";
            bullhornRestCredentials.RestClientSecret = "eBArvY6fu2iMeox0AxsX5OQY";

            restApiSession = new RestApiSession(bullhornRestCredentials);
        }

        [TestMethod]
        public void GetRestUrlTest()
        {
            Assert.IsNotNull(restApiSession.RestUrl);
        }

        [TestMethod]
        public void GetBhRestTokenTest()
        {
            Assert.IsNotNull(restApiSession.GetBhRestToken());
        }

    }
}
