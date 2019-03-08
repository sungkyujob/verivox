namespace Verivox.Models
{
    using Newtonsoft.Json;
    using Errors;
    public class Error
    {
        public Error(ErrorCode error, string requestID)
        {
            ErrorCode = error.Code;
            Message = error.Message;
            RequestID = requestID;
        }

        public string ErrorCode { get; set; }

        public string Message { get; set; }

        public string Detail { get; set; }

        public string RequestID { get; set; }
    }
}