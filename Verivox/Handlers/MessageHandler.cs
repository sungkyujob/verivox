namespace Verivox.Handlers
{
    using Helpers;
    using Logger;
    using System.Diagnostics;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Web.Http;

    /// <summary>
    /// Defines the <see cref="MessageHandler" />
    /// </summary>
    public class MessageHandler : DelegatingHandler
    {
        /// <summary>
        /// Defines the _logger
        /// </summary>
        private ILogger _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="MessageHandler"/> class.
        /// </summary>
        public MessageHandler()
        {
            _logger = GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(ILogger)) as ILogger;
        }

        /// <summary>
        /// The SendAsync
        /// </summary>
        /// <param name="request">The request<see cref="HttpRequestMessage"/></param>
        /// <param name="cancellationToken">The cancellationToken<see cref="CancellationToken"/></param>
        /// <returns>The <see cref="Task{HttpResponseMessage}"/></returns>
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var requestID = RequestHelper.GetRequestID(request);
            var sw = Stopwatch.StartNew();
            var response = await base.SendAsync(request, cancellationToken);
            sw.Stop();
            _logger.Request(requestID, request, response, sw.ElapsedMilliseconds);
            return response;
        }
    }
}
