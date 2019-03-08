namespace Verivox.Models.Log
{
    using System.Net;
    using System.Net.Http;

    public class Response
    {
        public Response(HttpResponseMessage response)
        {
            StatusCode = (int)response.StatusCode;
            ResponseMessage = (response.Content != null) ? response.Content.ReadAsStringAsync().Result : string.Empty;
        }
        public int StatusCode { get; set; }

        public string ResponseMessage { get; set; }
    }
}