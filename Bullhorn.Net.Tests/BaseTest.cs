using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bullhorn.Net.Tests
{
    public class BaseTest
    {
        protected BullhornRestCredentials bullhornRestCredentials;
        protected BullhornClient bullhornClient;

        [TestInitialize]
        public void Initialize()
        {
            bullhornRestCredentials = new BullhornRestCredentials();
            bullhornRestCredentials.RestAuthorizeUrl = "https://auth.bullhornstaffing.com/oauth/authorize";
            bullhornRestCredentials.RestLoginUrl = "https://rest.bullhornstaffing.com/rest-services/login";
            bullhornRestCredentials.RestTokenUrl = "https://auth.bullhornstaffing.com/oauth/token";
            bullhornRestCredentials.RestSessionMinutesToLive = 1400;
            bullhornRestCredentials.Username = "digitals.api";
            bullhornRestCredentials.Password = "janiek@digitals";
            bullhornRestCredentials.RestClientId = "7575e977-498a-41e7-aeca-dc56101cca31";
            bullhornRestCredentials.RestClientSecret = "eBArvY6fu2iMeox0AxsX5OQY";


            bullhornClient = new BullhornClient(bullhornRestCredentials);
        }
    }
}
