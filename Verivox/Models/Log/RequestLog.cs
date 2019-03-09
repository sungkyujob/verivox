namespace Verivox.Models.Log
{
    using System.Net.Http;

    /// <summary>
    /// Defines the <see cref="RequestLog" />
    /// </summary>
    public class RequestLog
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RequestLog"/> class.
        /// </summary>
        /// <param name="requestID">The requestID<see cref="string"/></param>
        /// <param name="request">The request<see cref="HttpRequestMessage"/></param>
        /// <param name="response">The response<see cref="HttpResponseMessage"/></param>
        /// <param name="elapsedMilliseconds">The elapsedMilliseconds<see cref="long"/></param>
        public RequestLog(string requestID, HttpRequestMessage request, HttpResponseMessage response, long elapsedMilliseconds)
        {
            RequestID = requestID;
            Request = new Request(request);
            Response = new Response(response);
            ElapsedMilliseconds = elapsedMilliseconds;
        }

        /// <summary>
        /// Gets or sets the RequestID
        /// </summary>
        public string RequestID { get; set; }

        /// <summary>
        /// Gets or sets the Request
        /// </summary>
        public Request Request { get; set; }

        /// <summary>
        /// Gets or sets the Response
        /// </summary>
        public Response Response { get; set; }

        /// <summary>
        /// Gets or sets the ElapsedMilliseconds
        /// </summary>
        public long ElapsedMilliseconds { get; set; }

        /// <summary>
        /// Gets the Message
        /// </summary>
        public string Message
        {
            get
            {
                return $"{RequestID} - {Request.Method} - {Request.Url} - {Request.RequestBody} - {Request.IP} - {Request.UserAgent} - {Response.StatusCode} - {Response.ResponseMessage} - {ElapsedMilliseconds}ms";
            }
        }
    }
}
