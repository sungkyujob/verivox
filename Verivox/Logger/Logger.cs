namespace Verivox.Logger
{
    using Errors;
    using Models.Log;
    using NLog;
    using System.Net.Http;

    /// <summary>
    /// Defines the <see cref="Logger" />
    /// </summary>
    public class Logger : ILogger
    {
        /// <summary>
        /// Defines the _request
        /// </summary>
        private NLog.Logger _request;

        /// <summary>
        /// Defines the _error
        /// </summary>
        private NLog.Logger _error;

        /// <summary>
        /// Initializes a new instance of the <see cref="Logger"/> class.
        /// </summary>
        /// <param name="configPath">The configPath<see cref="string"/></param>
        public Logger(string configPath)
        {
            LogManager.Configuration = new NLog.Config.XmlLoggingConfiguration(configPath, true);
            _request = LogManager.GetLogger("request");
            _error = LogManager.GetLogger("error");
        }

        /// <summary>
        /// The Request
        /// </summary>
        /// <param name="requestID">The requestID<see cref="string"/></param>
        /// <param name="request">The request<see cref="HttpRequestMessage"/></param>
        /// <param name="response">The response<see cref="HttpResponseMessage"/></param>
        /// <param name="elapsedMilliseconds">The elapsedMilliseconds<see cref="long"/></param>
        public void Request(string requestID, HttpRequestMessage request, HttpResponseMessage response, long elapsedMilliseconds)
        {
            var requestLog = new RequestLog(requestID, request, response, elapsedMilliseconds);
            _request.Info(requestLog.Message);
        }

        /// <summary>
        /// The Error
        /// </summary>
        /// <param name="requestID">The requestID<see cref="string"/></param>
        /// <param name="ex">The ex<see cref="ErrorException"/></param>
        public void Error(string requestID, ErrorException ex)
        {
            var error = new ErrorLog(requestID, ex);
            _error.Error(error.Message);
        }
    }
}
