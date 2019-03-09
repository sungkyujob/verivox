namespace Verivox.Models.Log
{
    using System.Net.Http;

    /// <summary>
    /// Defines the <see cref="Response" />
    /// </summary>
    public class Response
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Response"/> class.
        /// </summary>
        /// <param name="response">The response<see cref="HttpResponseMessage"/></param>
        public Response(HttpResponseMessage response)
        {
            StatusCode = (int)response.StatusCode;
            ResponseMessage = (response.Content != null) ? response.Content.ReadAsStringAsync().Result : string.Empty;
        }

        /// <summary>
        /// Gets or sets the StatusCode
        /// </summary>
        public int StatusCode { get; set; }

        /// <summary>
        /// Gets or sets the ResponseMessage
        /// </summary>
        public string ResponseMessage { get; set; }
    }
}
