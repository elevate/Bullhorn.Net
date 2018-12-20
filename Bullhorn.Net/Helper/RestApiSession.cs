using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Bullhorn.Net.Helper
{
    public class RestApiSession
    {
        private static string AUTH_CODE_ACTION = "Login";

        private static string AUTH_CODE_RESPONSE_TYPE = "code";

        private static string ACCESS_TOKEN_GRANT_TYPE = "authorization_code";

        private static string REFRESH_TOKEN_GRANT_TYPE = "refresh_token";

        //private static Logger log = Logger.getLogger(RestApiSession.class);

        private HttpClient httpClient;

        private BullhornRestCredentials restCredentials;

        private AccessTokenInfo accessTokenInfo;

        private string BhRestToken;

        public string RestUrl;

        private string version = "*";

        private DateTime dateTimeBhRestTokenWillExpire;

        private static int SESSION_RETRY = 3;
        public static int MAX_TTL = 2880;

        public RestApiSession()
        {
            this.restCredentials = null;
        }

        public RestApiSession(BullhornRestCredentials bullhornRestCredentials)
        {
            this.restCredentials = bullhornRestCredentials;
            this.httpClient = HttpClientFactory.httpClient;
            this.dateTimeBhRestTokenWillExpire = DateTime.Now;

            createSession();
        }

        private void createSession()
        {
            for (int tryNumber = 1; tryNumber <= SESSION_RETRY; tryNumber++)
            {
                try
                {
                    string authCode = getAuthorizationCode();

                    getAccessToken(authCode);
                    login();
                    break;
                }
                catch (Exception e)
                {

                    if (tryNumber < SESSION_RETRY)
                    {
                        //log.error("Error creating REST session. Try number: " + tryNumber + " out of " + SESSION_RETRY + " trying again.", e);
                    }
                    else
                    {
                        //log.error("Final error creating REST session. Shutting down.", e);
                        //throw new RestApiException("Failed to create rest session", e);
                    }
                }
            }
        }

        public string refreshBhRestToken()
        {
            createSession();

            return this.BhRestToken;

        }

        private string getAuthorizationCode()
        {
            string url = string.Format("{0}?client_id={1}&response_type={2}&action={3}&username={4}&password={5}",
                        restCredentials.RestAuthorizeUrl,
                        restCredentials.RestClientId,
                        AUTH_CODE_RESPONSE_TYPE,
                        AUTH_CODE_ACTION,
                        restCredentials.Username,
                        restCredentials.Password
                    );

            string authCode = null;

            try
            {
                HttpRequestMessage _httpRequest = new HttpRequestMessage();
                _httpRequest.RequestUri = new Uri(url);
                _httpRequest.Method = HttpMethod.Get;
                HttpResponseMessage message = httpClient.SendAsync(_httpRequest).Result;

                authCode = getAuthCode(message.RequestMessage.RequestUri);

            }
            catch (Exception e)
            {
                //TODO implement exceptions
                //log.error("Failed to get authorization code.", e);
                //throw new RestApiException("Failed to get authorization code.", e);
            }

            return authCode;
        }

        private string getAuthCode(Uri uri)
        {
            string query = uri.Query;
            var map = System.Web.HttpUtility.ParseQueryString(query);
            return map["code"];
        }

        private void getAccessToken(string authCode)
        {

            string url = String.Format("{0}?grant_type={1}&code={2}&client_id={3}&client_secret={4}",
                    restCredentials.RestTokenUrl,
                    ACCESS_TOKEN_GRANT_TYPE,
                    authCode,
                    restCredentials.RestClientId,
                    restCredentials.RestClientSecret
                    );

            try
            {
                HttpRequestMessage _httpRequest = new HttpRequestMessage();
                _httpRequest.RequestUri = new Uri(url);
                _httpRequest.Method = HttpMethod.Post;

                HttpResponseMessage message = httpClient.SendAsync(_httpRequest).Result;

                if (message.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    accessTokenInfo = JsonConvert.DeserializeObject<AccessTokenInfo>(message.Content.ReadAsStringAsync().Result);
                }
            }
            catch (Exception e)
            {
                //log.error("Failed to get access token.", e);
                //throw new RestApiException("Failed to get access token.", e);
            }
        }

        private void login()
        {
            //JSONObject responseJson = null;
            try
            {
                string url = String.Format("{0}?version={1}&access_token={2}&ttl={3}",
                    restCredentials.RestLoginUrl,
                    version,
                    accessTokenInfo.AccessToken,
                    restCredentials.RestSessionMinutesToLive);

                HttpRequestMessage _httpRequest = new HttpRequestMessage();
                _httpRequest.RequestUri = new Uri(url);
                _httpRequest.Method = HttpMethod.Get;

                HttpResponseMessage httpResponseMessage = httpClient.SendAsync(_httpRequest).Result;

                string responseStr = httpResponseMessage.Content.ReadAsStringAsync().Result;

                LoginResponseModel responseJson = JsonConvert.DeserializeObject<LoginResponseModel>(responseStr);

                BhRestToken = responseJson.BhRestToken;
                updateDateTimeBhRestTokenWillExpire();
                RestUrl = responseJson.restUrl;
            }
            catch (Exception e)
            {
                //log.error("Failed to login. " + responseJson, e);
                //throw new RestApiException("Failed to login and get BhRestToken: " + responseJson);

            }
        }

        public string GetBhRestToken()
        {
            if (dateTimeBhRestTokenWillExpire < DateTime.Now)
            {
                createSession();
            }
            return this.BhRestToken;
        }


        private void updateDateTimeBhRestTokenWillExpire()
        {
            // set the DateTime the session will expire, subtracting one minute to be on the safe side.
            DateTime timeToExpire = DateTime.Now;
            int sessionMinutesToLive = restCredentials.RestSessionMinutesToLive;
            if (sessionMinutesToLive > MAX_TTL)
            {
                sessionMinutesToLive = MAX_TTL;
            }
            timeToExpire = timeToExpire.AddMinutes(sessionMinutesToLive - 1);
            this.dateTimeBhRestTokenWillExpire = timeToExpire;
        }

    }
}
