namespace Verivox.Logger
{
    using Errors;
    using System.Net.Http;

    /// <summary>
    /// Defines the <see cref="ILogger" />
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// The Request
        /// </summary>
        /// <param name="requestID">The requestID<see cref="string"/></param>
        /// <param name="request">The request<see cref="HttpRequestMessage"/></param>
        /// <param name="response">The response<see cref="HttpResponseMessage"/></param>
        /// <param name="ElapsedMilliseconds">The ElapsedMilliseconds<see cref="long"/></param>
        void Request(string requestID, HttpRequestMessage request, HttpResponseMessage response, long ElapsedMilliseconds);

        /// <summary>
        /// The Error
        /// </summary>
        /// <param name="requestID">The requestID<see cref="string"/></param>
        /// <param name="ex">The ex<see cref="ErrorException"/></param>
        void Error(string requestID, ErrorException ex);
    }
}
