using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bullhorn.Net.Models.Response.Crud
{
    public class DeleteResponse: AbstractCrudResponse
    {
        public DeleteResponse()
        {
            this.ChangeType = Enums.ChangeType.DELETE.ToString();
        }
    }
}
