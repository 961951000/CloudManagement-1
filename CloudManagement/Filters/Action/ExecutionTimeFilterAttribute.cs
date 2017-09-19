using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using CloudManagement.Helper;

namespace CloudManagement.Filters.Action
{
    public class ExecutionTimeFilterAttribute : ActionFilterAttribute
    {
        public override async Task OnActionExecutingAsync(HttpActionContext context, CancellationToken cancellationToken)
        {
            await base.OnActionExecutingAsync(context, cancellationToken);
            context.Request.Properties[context.ActionDescriptor.ActionName] = Stopwatch.StartNew();
        }

        public override async Task OnActionExecutedAsync(HttpActionExecutedContext context, CancellationToken cancellationToken)
        {
            await base.OnActionExecutedAsync(context, cancellationToken);
            Stopwatch stopwatch = (Stopwatch)context.Request.Properties[context.ActionContext.ActionDescriptor.ActionName];
            Logger.Debug(context.ActionContext.ActionDescriptor.ActionName + "-Elapsed = " + stopwatch.Elapsed);
            stopwatch.Stop();
        }
    }
}