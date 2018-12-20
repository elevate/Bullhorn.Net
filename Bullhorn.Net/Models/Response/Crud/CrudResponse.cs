using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bullhorn.Net.Models.Response.Crud
{
    public interface CrudResponse
    {
        string ChangedEntityType { get; set; }
        int ChangedEntityId { get; set; }
        string ChangeType { get; set; }

        List<Message> Messages { get; set; }

        string ErrorCode { get; set; }
        string ErrorMessage { get; set; }

        bool HasValidationErrors { get; set; }
        bool HasMessages { get; set; }
        bool HasWarnings { get; set; }
    }
}
