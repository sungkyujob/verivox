namespace Verivox.Errors
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Web.Http;
    using Helpers;
    using Models;
    using Logger;

    public class ErrorHttpActionResult : IHttpActionResult
    {
        private Error error;
        private HttpRequestMessage request;
        private HttpStatusCode statusCode;
        private ILogger _logger;

        public ErrorHttpActionResult(HttpRequestMessage request)
        {
            this.request = request;
            this._logger = GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(ILogger)) as ILogger;
        }

        public ErrorHttpActionResult(HttpRequestMessage request, Exception ex) : this(request)
        {
            var requestID = RequestHelper.GetRequestID(request);
            var customError = (ex is ErrorException) ? ex as ErrorException : new InternalServerException(ex);
            error = new Error(customError.ErrorCode, requestID);
            if (RequestHelper.IsErrorDetail)
            {
                error.Detail = ex.Message;
            }
            statusCode = customError.ErrorCode.StatusCode;
            _logger.Error(requestID, customError);
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage(this.statusCode)
            {
                RequestMessage = request,
                Content = new ObjectContent<Error>(this.error, Formatters.JsonFormatter.Get())
            };
            return Task.FromResult(response);
        }
    }
}