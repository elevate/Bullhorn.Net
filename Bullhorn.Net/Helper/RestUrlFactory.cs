using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bullhorn.Net.Models.Entitities.Core.Parameters;

namespace Bullhorn.Net.Helper
{
    public class RestUrlFactory
    {
        private string restUrl;

        public RestUrlFactory(string restUrl)
        {
            this.restUrl = restUrl;
        }

        /// <summary>
        /// Assemble Url for entity PUT request. These are INSERT requests
        /// </summary>
        /// <returns></returns>
        public string AssembleEntityUrlForInsert(string entityType, string bhRestToken)
        {
            return restUrl + String.Format("entity/{0}?BhRestToken={1}", entityType, bhRestToken);
        }

        public  string AssembleEntityUrl(string bhRestToken, string entityType, int id, string fields = "*")
        {
            return this.restUrl + String.Format("entity/{0}/{1}?fields={2}&BhRestToken={3}", entityType, id, fields, bhRestToken);
        }

        public string assembleEntityDeleteUrl(string entityType, int id, string bhRestToken)
        {
            return restUrl + String.Format("entity/{0}/{1}?BhRestToken={2}", entityType, id, bhRestToken);
        }

        public string assembleQueryUrl(Dictionary<string, string> uriVariables, QueryParams queryParams)
        {
            string entityType = uriVariables[RestUriVariablesFactory.ENTITY_TYPE];
            string where = uriVariables[RestUriVariablesFactory.WHERE];
            string fields = uriVariables[RestUriVariablesFactory.FIELDS];
            string bhRestToken = uriVariables[RestUriVariablesFactory.BH_REST_TOKEN];

            return $"{restUrl}query/{entityType}?where={where}&fields={fields}&BhRestToken={bhRestToken}" + queryParams.getUrlString();
        }

        public string assembleSearchUrl(Dictionary<string, string> uriVariables, SearchParams searchParams)
        {
            string entityType = uriVariables[RestUriVariablesFactory.ENTITY_TYPE];
            string fields = uriVariables[RestUriVariablesFactory.FIELDS];
            string bhRestToken = uriVariables[RestUriVariablesFactory.BH_REST_TOKEN];
            string query = uriVariables[RestUriVariablesFactory.QUERY];

            return restUrl + $"search/{entityType}?query={query}&fields={fields}&BhRestToken={bhRestToken}" + searchParams.getUrlString();
        }

        public  string assembleFileAddUrl(string entityType, int entityId, string base64encodedFile, string bhRestToken)
        {
            return restUrl + $"file/{entityType}/{entityId}?BhRestToken={bhRestToken}";
        }
    }
}
