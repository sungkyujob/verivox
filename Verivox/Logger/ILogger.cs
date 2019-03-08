namespace Verivox.Logger
{
    using Errors;
    using System;
    using System.Net.Http;

    public interface ILogger
    {
        void Request(string requestID, HttpRequestMessage request, HttpResponseMessage response, long ElapsedMilliseconds);
        void Error(string requestID, ErrorException ex);
    }
}
