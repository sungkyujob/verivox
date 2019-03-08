namespace Verivox.Models.Log
{
    using Errors;
    using System.Text.RegularExpressions;

    public class ErrorLog
    {
        public ErrorLog(string requestID, ErrorException ex)
        {
            RequestID = requestID;
            Exception = ex;
        }
        public string RequestID { get; set; }
        public ErrorException Exception { get; set; }
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