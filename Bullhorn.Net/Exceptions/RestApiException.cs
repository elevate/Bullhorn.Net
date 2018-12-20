using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bullhorn.Net.Exceptions
{
    public class RestApiException : SystemException
    {
        public RestApiException(): base()
        {
            
        }

        public RestApiException(string message): base(message)
        {
            
        }

        public RestApiException(string message, Exception exception): base(message, exception)
        {
            
        }
    }
}
