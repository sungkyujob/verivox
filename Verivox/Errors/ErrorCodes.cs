namespace Verivox.Errors
{
    using System.Net;
    public class ErrorCode
    {
        public string Code { get; }
        public string Message { get; set; }
        public HttpStatusCode StatusCode { get; }

        protected ErrorCode(string code, string message, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
        {
            Code = code;
            Message = message;
            StatusCode = statusCode;
        }

        public static ErrorCode InvalidRequest = new ErrorCode("000-400-0000", "Invalid Request");
        public static ErrorCode Forbidden = new ErrorCode("000-403-0000", "Forbidden", HttpStatusCode.Forbidden);
        public static ErrorCode InternalServer = new ErrorCode("000-500-0000", "Internal Server Error", HttpStatusCode.InternalServerError);
    }
}