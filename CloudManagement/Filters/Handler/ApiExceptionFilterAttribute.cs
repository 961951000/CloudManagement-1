using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Filters;
using CloudManagement.Helper;
using System;

namespace CloudManagement.Filters.Handler
{
    public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override async Task OnExceptionAsync(HttpActionExecutedContext context, CancellationToken cancellationToken)
        {
            if (context.Exception is ArgumentException)
            {
                context.Response = context.Request.CreateResponse(HttpStatusCode.BadRequest, context.Exception.Message);
            }
            else
            {
                context.Response = context.Request.CreateResponse(HttpStatusCode.InternalServerError, context.Exception.Message);
            }
            Logger.Error(context.Exception);
            await base.OnExceptionAsync(context, cancellationToken);
        }
    }
}