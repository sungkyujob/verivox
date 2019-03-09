namespace Verivox.CustomFilters
{
    using Errors;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Web.Http.Filters;

    /// <summary>
    /// Defines the <see cref="CustomExceptionFilter" />
    /// </summary>
    public class CustomExceptionFilter : FilterAttribute, IExceptionFilter
    {
        /// <summary>
        /// The ExecuteExceptionFilterAsync
        /// </summary>
        /// <param name="actionContext">The actionContext<see cref="HttpActionExecutedContext"/></param>
        /// <param name="cancellationToken">The cancellationToken<see cref="CancellationToken"/></param>
        /// <returns>The <see cref="Task"/></returns>
        public async Task ExecuteExceptionFilterAsync(HttpActionExecutedContext actionContext, CancellationToken cancellationToken)
        {
            var response = await new ErrorHttpActionResult(actionContext.Request, actionContext.Exception).ExecuteAsync(cancellationToken);
            actionContext.Response = response;
        }
    }
}
