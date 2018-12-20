using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bullhorn.Net.Models.Response.Crud
{
    public class AbstractCrudResponse : CrudResponse
    {
        public string ChangedEntityType { get; set; }
        public int ChangedEntityId { get; set; }
        public string ChangeType { get; set; }
        public List<Message> Messages { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public bool HasValidationErrors { get; set; }
        public bool HasMessages { get; set; }
        public bool HasWarnings { get; set; }

        public void addOneMessage(Message message)
        {
            this.Messages.Add(message);
        }
    }
}
