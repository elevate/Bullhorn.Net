using Bullhorn.Net.Exceptions;
using Bullhorn.Net.Helper;
using Bullhorn.Net.Models;
using Bullhorn.Net.Models.Entitities.Core;
using Bullhorn.Net.Models.Entitities.Core.Parameters;
using Bullhorn.Net.Models.Entitities.Core.Parameters.Standard;
using Bullhorn.Net.Models.Entitities.Core.Type;
using Bullhorn.Net.Models.Response;
using Bullhorn.Net.Models.Response.Crud;
using Bullhorn.Net.Models.Response.File;
using Bullhorn.Net.Models.Response.File.Standard;
using Microsoft.Rest;
using Microsoft.Rest.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace Bullhorn.Net
{
    public class BullhornClient : IBullhornClient
    {
        private RestApiSession restApiSession;
        private HttpClient httpClient;

        private RestUrlFactory restUrlFactory;
        private RestUriVariablesFactory restUriVariablesFactory;
        private RestErrorHandler restErrorHandler;
        private RestFileManager restFileManager;
        private string restUrl;

        private static int RESUME_PARSE_RETRY = 10;
        private static int API_RETRY = 3;
        private int MAX_RECORDS_TO_RETURN_IN_ONE_PULL = 500;
        private int MAX_RECORDS_TO_RETURN_IN_ONE_PULL_FOR_SEARCH = 50;
        private static int MAX_RECORDS_TO_RETURN_TOTAL = 20000;


        public BullhornClient(BullhornRestCredentials credentials)
        {
            this.restApiSession = new RestApiSession(credentials);
            this.httpClient = HttpClientFactory.httpClient;

            this.restUrl = restApiSession.RestUrl;
            this.restUrlFactory = new RestUrlFactory(restUrl);
            this.restUriVariablesFactory = new RestUriVariablesFactory(this);
            this.restErrorHandler = new RestErrorHandler();
            this.restFileManager = new RestFileManager();
        }


        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public string getBhRestToken()
        {
            string bhRestToken = null;
            try
            {
                bhRestToken = restApiSession.GetBhRestToken();
            }
            catch (RestApiException e)
            {
                //log.error("Error getting bhRestToken! ", e);
            }
            return bhRestToken;
        }

        public string refreshBhRestToken()
        {
            string bhRestToken = null;
            try
            {
                bhRestToken = restApiSession.refreshBhRestToken();
            }
            catch (RestApiException e)
            {
                //log.error("Error getting bhRestToken! ", e);
            }
            return bhRestToken;
        }

        public T findEntity<T>(string entityType, int id) where T : BullhornEntity
        {
            return this.handleGetEntity<T>(entityType, id);
        }

        public List<T> queryForList<T>(string entityType, string where, string[] fieldSet, QueryParams queryParams)
        {
            IListWrapper<T> wrapper = this.handleQueryForEntities<T>(entityType, where, fieldSet, queryParams);
            if (wrapper == null)
            {
                return new List<T>();
            }
            return wrapper.Data;
        }

        public IListWrapper<T> queryForAllRecords<T>(string entityType, string where, string[] fieldset, QueryParams queryParams)
        {
            return this.handleQueryForAllRecords<T>(entityType, where, fieldset, queryParams);
        }

        public CrudResponse insertEntity<T>(string entityType, T entity)
        {
            return this.handleInsertEntity(entityType, entity);
        }

        public CrudResponse deleteEntity(string entityType, int id)
        {
            return this.handleDeleteEntity(entityType, id);
        }

        public List<T> SearchForAllRecords<T>(string entityType, string query, string[] fieldset, SearchParams searchParams)
        {
            return this.handleSearchForAllRecords<T>(entityType, query, fieldset, searchParams);
        }

        public List<T> SearchForList<T>(string entityType, string query, string[] fields = null, SearchParams searchParams = null)
        {
            if (searchParams == null)
            {
                searchParams = new StandardSearchParams();
            }
            IListWrapper<T> wrapper = this.handleSearchForEntities<T>(entityType, query, fields, searchParams);
            if (wrapper == null)
            {
                return new List<T>();
            }
            return wrapper.Data;

            //string url = String.Format("{0}search/{1}?BhRestToken={2}&query=*:*&fields={3}&count={4}", restApiSession.RestUrl, entityType, restApiSession.GetBhRestToken(), string.Join(",", fields), count);
            //Console.WriteLine(url);
            //var results = PerformGetRequest<T>(url);

            //return results;
        }


        public FileApiResponse addFile(string entityType, int entityId, string base64encodedfile, string externalId, FileParams fileParams)
        {
            return this.handleAddFile(entityType, entityId, base64encodedfile, fileParams);
        }




        #region Rest-calls

        private StandardListWrapper<T> PerformGetRequest<T>(string url)
        {

            for (int tryNumber = 1; tryNumber <= API_RETRY; tryNumber++)
            {
                try
                {
                    HttpRequestMessage _httpRequest = new HttpRequestMessage();
                    _httpRequest.RequestUri = new Uri(url);
                    _httpRequest.Method = HttpMethod.Get;

                    HttpResponseMessage message = httpClient.SendAsync(_httpRequest).Result;

                    if (message.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string result = message.Content.ReadAsStringAsync().Result;
                        return JsonConvert.DeserializeObject<StandardListWrapper<T>>(result);
                    }
                    else
                    {
                        handleHttpStatusCodeError(url, tryNumber, message.StatusCode);
                    }
                }
                catch (Exception e)
                {
                    handleApiError(tryNumber, e);
                }
            }

            throw new RestApiException("Error getting " + typeof(T) + " url variables " + url);


        }

        private void handleApiError(int tryNumber, Exception e)
        {
            //log.error("Error making api call. Try number:" + tryNumber + " out of " + API_RETRY, e);
        }

        private T handleGetEntity<T>(string entityType, int id) where T : BullhornEntity
        {
            String url = restUrlFactory.AssembleEntityUrl(restApiSession.GetBhRestToken(), entityType, id);

            Console.WriteLine(url);

            HttpRequestMessage _httpRequest = new HttpRequestMessage();
            _httpRequest.RequestUri = new Uri(url);
            _httpRequest.Method = HttpMethod.Get;

            HttpResponseMessage message = httpClient.SendAsync(_httpRequest).Result;

            if (message.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string content = message.Content.ReadAsStringAsync().Result;
                T entity = JsonConvert.DeserializeObject<T>(content);

                //try to catch when bullhorns returns dataObject
                if (entity.Id == 0)
                {
                    StandardWrapper<T> standardwrapperEntity = JsonConvert.DeserializeObject<StandardWrapper<T>>(content);
                    if (standardwrapperEntity != null)
                        entity = standardwrapperEntity.Data;
                }
                return entity;
            }
            return default(T);
        }

        private IListWrapper<T> handleQueryForEntities<T>(string entityType, string where, string[] fieldSet, QueryParams queryParams)
        {
            Dictionary<string, string> uriVariables = restUriVariablesFactory.getUriVariablesForQuery(entityType, where, fieldSet);
            string url = restUrlFactory.assembleQueryUrl(uriVariables, queryParams);

            return this.PerformGetRequest<T>(url);
        }

        private IListWrapper<T> handleSearchForEntities<T>(string entityType, string query, string[] fields, SearchParams searchParams)
        {
            Dictionary<string, string> uriVariables = restUriVariablesFactory.getUriVariablesForSearch(entityType, query, fields);

            string url = restUrlFactory.assembleSearchUrl(uriVariables, searchParams);
            Console.WriteLine(url);
            return this.PerformGetRequest<T>(url);
        }

        private CrudResponse handleInsertEntity<T>(string entityType, T entity)
        {
            string url = restUrlFactory.AssembleEntityUrlForInsert(entityType, restApiSession.GetBhRestToken());
            Console.WriteLine(url);
            CrudResponse crudResponse;
            try
            {
                HttpRequestMessage _httpRequest = new HttpRequestMessage();
                _httpRequest.RequestUri = new Uri(url);
                _httpRequest.Method = HttpMethod.Put;
                _httpRequest.Content = new StringContent(
                    JsonConvert.SerializeObject(
                        entity,
                        Formatting.Indented,
                        new JsonSerializerSettings
                        {
                            NullValueHandling = NullValueHandling.Ignore,
                            ContractResolver = new CamelCasePropertyNamesContractResolver(),
                        }), Encoding.UTF8, "application/json");

                Console.WriteLine(JsonConvert.SerializeObject(
                        entity,
                        Formatting.Indented,
                        new JsonSerializerSettings
                        {
                            NullValueHandling = NullValueHandling.Ignore,
                            ContractResolver = new CamelCasePropertyNamesContractResolver(),
                        }));

                crudResponse = JsonConvert.DeserializeObject<CreateResponse>(httpClient.SendAsync(_httpRequest).Result.Content.ReadAsStringAsync().Result);
            }
            catch (Exception e)
            {
                crudResponse = null;
            }
            return crudResponse;
        }

        private CrudResponse handleDeleteEntity(string entityType, int id)
        {
            string url = restUrlFactory.assembleEntityDeleteUrl(entityType, id, restApiSession.GetBhRestToken());

            CrudResponse response = null;

            try
            {
                HttpRequestMessage _httpRequest = new HttpRequestMessage();
                _httpRequest.RequestUri = new Uri(url);
                _httpRequest.Method = HttpMethod.Delete;

                response = JsonConvert.DeserializeObject<DeleteResponse>(httpClient.SendAsync(_httpRequest).Result.Content.ReadAsStringAsync().Result);
            }
            catch (HttpException error)
            {
                response = restErrorHandler.handleHttpFourAndFiveHundredErrors(new DeleteResponse(), error, id);
            }
            return response;
        }

        private IListWrapper<T> handleQueryForAllRecords<T>(string entityType, string where, string[] fieldSet, QueryParams queryParams)
        {
            List<T> allEntities = new List<T>();
            queryParams.Count = MAX_RECORDS_TO_RETURN_IN_ONE_PULL;

            recursiveQueryPull(allEntities, entityType, where, fieldSet, queryParams);
            return new StandardListWrapper<T>(allEntities);
        }

        private List<T> handleSearchForAllRecords<T>(string entityType, string query, string[] fieldset, SearchParams searchParams)
        {
            List<T> allEntities = new List<T>();
            searchParams.Count = MAX_RECORDS_TO_RETURN_IN_ONE_PULL_FOR_SEARCH;

            recursiveSearchPull(allEntities, entityType, query, fieldset, searchParams);
            return allEntities;
        }

        //private FileWrapper handleAddFileWithMultipartFile(string entityType, int entityId, MultipartFormDataContent multipartFile, string externalId, FileParams fileParams, bool v)
        //{

        //    Dictionary<string, string> uriVariables = restUriVariablesFactory.getUriVariablesForAddFile(BullhornEntityInfo.getTypesRestEntityName(type),
        //            entityId, externalId, fileParams);
        //    String url = restUrlFactory.assembleAddFileUrl(params);

        //    return this.handleAddFile(type, entityId, multiValueMap, url, uriVariables, multipartFile.getOriginalFilename(), deleteFile);
        //}


        private FileApiResponse handleAddFile(string entityType, int entityId, string base64encodedFile, FileParams fileParams)
        {

            StandardFileApiResponse fileApiResponse;
            string url = restUrlFactory.assembleFileAddUrl(entityType, entityId, base64encodedFile, restApiSession.GetBhRestToken());
            try
            {
                StandardFileWrapper wrapper = new StandardFileWrapper(base64encodedFile);
                
                HttpRequestMessage _httpRequest = new HttpRequestMessage();
                _httpRequest.RequestUri = new Uri(url);
                _httpRequest.Method = HttpMethod.Put;
                _httpRequest.Content = new StringContent(
                   JsonConvert.SerializeObject(
                       wrapper,
                       Formatting.Indented,
                       new JsonSerializerSettings
                       {
                           NullValueHandling = NullValueHandling.Ignore,
                           ContractResolver = new CamelCasePropertyNamesContractResolver(),
                       }), Encoding.UTF8, "application/json");

                Console.WriteLine(JsonConvert.SerializeObject(
                        wrapper,
                        Formatting.Indented,
                        new JsonSerializerSettings
                        {
                            NullValueHandling = NullValueHandling.Ignore,
                            ContractResolver = new CamelCasePropertyNamesContractResolver(),
                        }));
                var response = httpClient.SendAsync(_httpRequest).Result.Content.ReadAsStringAsync().Result;
                fileApiResponse = JsonConvert.DeserializeObject<StandardFileApiResponse>(response);
            }
            catch (HttpException error)
            {
                fileApiResponse = null;
                //fileApiResponse = restErrorHandler.handleHttpFourAndFiveHundredErrors(new DeleteResponse(), error, entityId);
            }
            return fileApiResponse;

        }
        private void recursiveSearchPull<T>(List<T> allEntities, string entityType, string query, string[] fieldset, SearchParams searchParams)
        {
            IListWrapper<T> onePull = handleSearchForEntities<T>(entityType, query, fieldset, searchParams);

            allEntities.AddRange(onePull.Data);

            if (moreRecordsExist(onePull) && ceilingNotReached(allEntities))
            {
                searchParams.Start = allEntities.Count();
                recursiveSearchPull(allEntities, entityType, query, fieldset, searchParams);
            }
        }

        private void recursiveQueryPull<T>(List<T> allEntities, string entityType, string where, string[] fieldSet, QueryParams queryParams)
        {
            IListWrapper<T> onePull = handleQueryForEntities<T>(entityType, where, fieldSet, queryParams);

            allEntities.AddRange(onePull.Data);

            if (moreRecordsExist(onePull) && ceilingNotReached(allEntities))
            {
                queryParams.Start = allEntities.Count();
                recursiveQueryPull(allEntities, entityType, where, fieldSet, queryParams);
            }
        }


        private bool moreRecordsExist<T>(IListWrapper<T> onePull)
        {
            if ((onePull.Start + onePull.Count >= onePull.Total) || onePull.Count == 0)
            {
                return false;
            }

            return true;
        }

        private bool ceilingNotReached<T>(List<T> allEntities)
        {
            if (allEntities.Count() < MAX_RECORDS_TO_RETURN_TOTAL)
            {
                return true;
            }
            return false;
        }

        #endregion

        #region handle Exceptions
        private void handleHttpStatusCodeError(string url, int tryNumber, HttpStatusCode error)
        {
            if (error == HttpStatusCode.Unauthorized)
            {
                resetBhRestToken(url);
            }
            //log.error(
            //        "HttpStatusCodeError making api call. Try number:" + tryNumber + " out of " + API_RETRY + ". Http status code: "
            //                + error.getStatusCode() + ". Response body: " + error.getResponseBodyAsString(), error);
            if (tryNumber >= API_RETRY)
            {
                throw new RestApiException("HttpStatusCodeError making api call with url " + url
                        + ". Http status code: " + error.ToString() + ". Response body: " + error == null ? ""
                        : error.ToString());
            }
        }

        private void resetBhRestToken(string url)
        {
            url = replaceUrlParam(url, RestUriVariablesFactory.BH_REST_TOKEN, getBhRestToken());
        }

        private string replaceUrlParam(string url, string key, string value)
        {
            return Regex.Replace(
                url,
                @"([?&]" + key + ")=[^?&]+",
                "$1=" + value);
        }

        #endregion
    }
}

