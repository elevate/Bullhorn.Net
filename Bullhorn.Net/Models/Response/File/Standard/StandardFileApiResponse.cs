using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bullhorn.Net.Models.Response.File.Standard
{
    public class StandardFileApiResponse : FileApiResponse
    {
        public int FileId {get;set;}
        public string ChangeType {get;set;}
    }
}
