namespace Verivox.Models.Log
{
    using System.Net;
    using System.Net.Http;

    public class RequestLog
    {
        public RequestLog(string requestID, HttpRequestMessage request, HttpResponseMessage response, long elapsedMilliseconds)
        {
            RequestID = requestID;
            Request = new Request(request);
            Response = new Response(response);
            ElapsedMilliseconds = elapsedMilliseconds;
        }
        public string RequestID { get; set; }
        public Request Request { get; set; }
        public Response Response { get; set; }
        public long ElapsedMilliseconds { get; set; }

        public string Message
        {
            get
            {
                return $"{RequestID} - {Request.Method} - {Request.Url} - {Request.RequestBody} - {Request.IP} - {Request.UserAgent} - {Response.StatusCode} - {Response.ResponseMessage} - {ElapsedMilliseconds}ms";
            }
        }
    }
}