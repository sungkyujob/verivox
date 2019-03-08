namespace Verivox.CustomFilters
{
    using System.Threading;
    using System.Threading.Tasks;
    using System.Web.Http.Filters;
    using Errors;
    public class CustomExceptionFilter : FilterAttribute, IExceptionFilter
    {
        public async Task ExecuteExceptionFilterAsync(HttpActionExecutedContext actionContext, CancellationToken cancellationToken)
        {
            var response = await new ErrorHttpActionResult(actionContext.Request, actionContext.Exception).ExecuteAsync(cancellationToken);
            actionContext.Response = response;
        }
    }
}