namespace Verivox.Logger
{
    using System;
    using System.Net.Http;
    using NLog;
    using Models.Log;
    using Errors;

    public class Logger : ILogger
    {
        private NLog.Logger _request;
        private NLog.Logger _error;
        public Logger(string configPath)
        {
            LogManager.Configuration = new NLog.Config.XmlLoggingConfiguration(configPath, true);
            _request = LogManager.GetLogger("request");
            _error = LogManager.GetLogger("error");
        }

        public static NLog.Logger Instance { get; private set; }

        public void Request(string requestID, HttpRequestMessage request, HttpResponseMessage response, long elapsedMilliseconds)
        {
            var requestLog = new RequestLog(requestID, request, response, elapsedMilliseconds);
            _request.Info(requestLog.Message);
        }
        public void Error(string requestID, ErrorException ex)
        {
            var error = new ErrorLog(requestID, ex);
            _error.Error(error.Message);
        }
    }
}
