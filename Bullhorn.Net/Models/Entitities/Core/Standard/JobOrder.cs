using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bullhorn.Net.Models.Entitities.Core.Standard
{
    public class JobOrder : JobData
    {
        public static string EntityType = "JobOrder";

        public JobOrder()
        {

        }

        public JobOrder(int id)
        {
            this.Id = id;
        }
    }
}
