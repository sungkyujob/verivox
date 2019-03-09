namespace Verivox.Models
{
    using Errors;

    /// <summary>
    /// Defines the <see cref="Error" />
    /// </summary>
    public class Error
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Error"/> class.
        /// </summary>
        /// <param name="error">The error<see cref="ErrorCode"/></param>
        /// <param name="requestID">The requestID<see cref="string"/></param>
        public Error(ErrorCode error, string requestID)
        {
            ErrorCode = error.Code;
            Message = error.Message;
            RequestID = requestID;
        }

        /// <summary>
        /// Gets or sets the ErrorCode
        /// </summary>
        public string ErrorCode { get; set; }

        /// <summary>
        /// Gets or sets the Message
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the Detail
        /// </summary>
        public string Detail { get; set; }

        /// <summary>
        /// Gets or sets the RequestID
        /// </summary>
        public string RequestID { get; set; }
    }
}
