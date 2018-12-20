using Bullhorn.Net.Models.Response.Crud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Bullhorn.Net.Helper
{
    public class RestErrorHandler
    {
        public CrudResponse handleHttpFourAndFiveHundredErrors(CrudResponse response, HttpException error, int id)
        {
            response.ChangedEntityId = id;

            Message message = new Message();
            message.DetailMessage  = error.GetHtmlErrorMessage();
            message.Severity = error.ErrorCode.ToString();
            message.Type = error.GetType().ToString();

            response.Messages.Add(message);

            response.ErrorCode = error.GetHttpCode().ToString();
            response.ErrorMessage = error.Message;
            return response;

        }

        public void handleValidationErrors(CrudResponse response, List<Exception> validationErrors)
        {
            //TODO add handle validation errors

            //foreach (FieldException fieldError in validationErrors.Where(p=>p.)
            //{
            //    Message message = new Message(fieldError);
            //    response.Messages.Add(message);
            //}

        }
    }
}
