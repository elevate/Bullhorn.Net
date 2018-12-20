using Bullhorn.Net.Models.Entitities.Core.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bullhorn.Net.Helper
{
    public class RestUriVariablesFactory
    {
        private BullhornClient bullhornClient;

        //private RestFileManager restFileManager;

        // url parameter names
        public const string BH_REST_TOKEN = "bhRestToken";
        public const string ENTITY_TYPE = "entityType";
        public const string FIELDS = "fields";
        public const string META = "meta";
        public const string WHERE = "where";
        public const string QUERY = "query";
        public const string FORMAT = "format";
        public const string ENTITY_ID = "entityId";
        public const string FILE_ID = "fileId";
        public const string EXTERNAL_ID = "externalID";
        public const string ID = "id";
        public const string ACCOCIATION_NAME = "associationName";
        public const string ACCOCIATION_IDS = "associationIds";
        public const string CLIENT_CORP_ID = "clientCorpId";
        public const string SETTINGS = "settings";
        public const string SUBSCRIPTION_ID = "subscriptionId";
        public const string MAX_EVENTS = "maxEvents";
        public const string REQUEST_ID = "requestId";
        public const string PRIVATE_LABEL_ID = "privateLabelId";

        public RestUriVariablesFactory(BullhornClient bullhornClient/**, RestFileManager restFileManager**/)
        {
            this.bullhornClient = bullhornClient;
            //this.restFileManager = restFileManager;
        }

        public Dictionary<string, string> getUriVariablesForQuery(string entityType, String where, string[] fieldSet)
        {

            Dictionary<string, string> uriVariables = new Dictionary<string, string>();

            this.addCommonUriVariables(fieldSet, entityType, uriVariables);
            uriVariables.Add(WHERE, where);

            return uriVariables;
        }

        public void addCommonUriVariables(string[] fieldSet, string entityType, Dictionary<string, string> uriVariables)
        {
            string bhRestToken = bullhornClient.getBhRestToken();
            string fields = convertFieldSetToString(fieldSet);

            uriVariables.Add(BH_REST_TOKEN, bhRestToken);
            uriVariables.Add(FIELDS, fields);
            uriVariables.Add(ENTITY_TYPE, entityType);

        }

        public string convertFieldSetToString(string[] fieldSet)
        {

            if (fieldSet == null || fieldSet.Length == 0 || fieldSet.Contains("*"))
            {
                return "*";
            }

            List<string> interim = fieldSet.ToList().Where(p=>!String.IsNullOrEmpty(p)).ToList();

            if (interim.Count == 0)
            {
                interim.Add(ID);
            }

            return string.Join(",",interim);

        }

        public  Dictionary<string, string> getUriVariablesForSearch(string entityType, string query, string[] fieldSet )
        {
            Dictionary<string, string> uriVariables = new Dictionary<string, string>();

            this.addCommonUriVariables(fieldSet, entityType, uriVariables);
            uriVariables.Add(QUERY, query);

            return uriVariables;
        }

        
    }
}
