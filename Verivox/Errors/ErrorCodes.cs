namespace Verivox.Errors
{
    using System.Net;

    /// <summary>
    /// Defines the <see cref="ErrorCode" />
    /// </summary>
    public class ErrorCode
    {
        /// <summary>
        /// Gets the Code
        /// </summary>
        public string Code { get; }

        /// <summary>
        /// Gets or sets the Message
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Gets the StatusCode
        /// </summary>
        public HttpStatusCode StatusCode { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorCode"/> class.
        /// </summary>
        /// <param name="code">The code<see cref="string"/></param>
        /// <param name="message">The message<see cref="string"/></param>
        /// <param name="statusCode">The statusCode<see cref="HttpStatusCode"/></param>
        protected ErrorCode(string code, string message, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
        {
            Code = code;
            Message = message;
            StatusCode = statusCode;
        }

        /// <summary>
        /// Defines the InvalidRequest
        /// </summary>
        public static ErrorCode InvalidRequest = new ErrorCode("000-400-0000", "Invalid Request");

        /// <summary>
        /// Defines the Forbidden
        /// </summary>
        public static ErrorCode Forbidden = new ErrorCode("000-403-0000", "Forbidden", HttpStatusCode.Forbidden);

        /// <summary>
        /// Defines the InternalServer
        /// </summary>
        public static ErrorCode InternalServer = new ErrorCode("000-500-0000", "Internal Server Error", HttpStatusCode.InternalServerError);
    }
}
