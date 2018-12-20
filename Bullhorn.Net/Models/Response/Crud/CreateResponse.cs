using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bullhorn.Net.Models.Response.Crud
{
    public class CreateResponse: AbstractCrudResponse
    {
        public CreateResponse()
        {
            this.ChangeType = Models.Enums.ChangeType.INSERT.ToString();
        }
    }
}
