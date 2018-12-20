using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bullhorn.Net.Models.Entitities.Core.Standard
{
    public class File
    {
        public decimal LuceneScore { get; set; }

        public int Id { get; set; }

        public int CompanyID { get; set; }

        public DateTime DateAdded { get; set; }

        public string Description { get; set; }

        public string FileName { get; set; }

        public string FirstName { get; set; }

        public int JobPostingID { get; set; }

        public string LastName { get; set; }

        public string Name { get; set; }

        public string Title { get; set; }

        public string Type { get; set; }

        public int UserID { get; set; }

        public string UserType { get; set; }
    }
}
