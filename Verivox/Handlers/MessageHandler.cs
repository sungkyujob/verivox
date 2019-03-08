namespace Verivox.Handlers
{
    using Helpers;
    using Logger;
    using System.Diagnostics;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Web.Http;

    public class MessageHandler : DelegatingHandler
    {
        private ILogger _logger;

        public MessageHandler()
        {
            _logger = GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(ILogger)) as ILogger;
        }

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