namespace Verivox.Models.Log
{
    using Errors;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Defines the <see cref="ErrorLog" />
    /// </summary>
    public class ErrorLog
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorLog"/> class.
        /// </summary>
        /// <param name="requestID">The requestID<see cref="string"/></param>
        /// <param name="ex">The ex<see cref="ErrorException"/></param>
        public ErrorLog(string requestID, ErrorException ex)
        {
            RequestID = requestID;
            Exception = ex;
        }

        /// <summary>
        /// Gets or sets the RequestID
        /// </summary>
        public string RequestID { get; set; }

        /// <summary>
        /// Gets or sets the Exception
        /// </summary>
        public ErrorException Exception { get; set; }

        /// <summary>
        /// Gets the Message
        /// </summary>
        public string Message
        {
            get
            {
                var message = Regex.Replace(Exception.Message, @"\r\n?|\n| ", "");
                var trace = Regex.Replace(Exception.StackTrace, @"\r\n?|\n| ", "");
                var source = Regex.Replace(Exception.Source, @"\r\n?|\n| ", "");
                return $"{RequestID} - {Exception.ErrorCode.Code} - {Exception.ErrorCode.Message} - {message} - {trace} - {source}";
            }
        }
    }
}
