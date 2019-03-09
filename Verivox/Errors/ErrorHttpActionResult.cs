namespace Verivox.Errors
{
    using Helpers;
    using Logger;
    using Models;
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Web.Http;

    /// <summary>
    /// Defines the <see cref="ErrorHttpActionResult" />
    /// </summary>
    public class ErrorHttpActionResult : IHttpActionResult
    {
        /// <summary>
        /// Defines the error
        /// </summary>
        private Error error;

        /// <summary>
        /// Defines the request
        /// </summary>
        private HttpRequestMessage request;

        /// <summary>
        /// Defines the statusCode
        /// </summary>
        private HttpStatusCode statusCode;

        /// <summary>
        /// Defines the _logger
        /// </summary>
        private ILogger _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorHttpActionResult"/> class.
        /// </summary>
        /// <param name="request">The request<see cref="HttpRequestMessage"/></param>
        public ErrorHttpActionResult(HttpRequestMessage request)
        {
            this.request = request;
            this._logger = GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(ILogger)) as ILogger;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorHttpActionResult"/> class.
        /// </summary>
        /// <param name="request">The request<see cref="HttpRequestMessage"/></param>
        /// <param name="ex">The ex<see cref="Exception"/></param>
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

        /// <summary>
        /// The ExecuteAsync
        /// </summary>
        /// <param name="cancellationToken">The cancellationToken<see cref="CancellationToken"/></param>
        /// <returns>The <see cref="Task{HttpResponseMessage}"/></returns>
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
