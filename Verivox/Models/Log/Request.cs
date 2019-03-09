namespace Verivox.Models.Log
{
    using Helpers;
    using Newtonsoft.Json;
    using System.IO;
    using System.Net.Http;

    /// <summary>
    /// Defines the <see cref="Request" />
    /// </summary>
    public class Request
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Request"/> class.
        /// </summary>
        /// <param name="request">The request<see cref="HttpRequestMessage"/></param>
        public Request(HttpRequestMessage request)
        {
            UserAgent = (request.Headers != null) ? ((request.Headers.UserAgent != null) ? request.Headers.UserAgent.ToString() : string.Empty) : string.Empty;
            Method = request.Method.ToString();
            Url = request.RequestUri.AbsoluteUri;
            IP = RequestHelper.GetUserHostAddress(request);

            if (request.Method != HttpMethod.Get)
            {
                try
                {
                    using (var stream = new StreamReader(request.Content.ReadAsStreamAsync().Result))
                    {
                        stream.BaseStream.Position = 0;
                        var body = JsonConvert.DeserializeObject<dynamic>(stream.ReadToEnd());
                        RequestBody = JsonConvert.SerializeObject(body);
                    }
                }
                catch { }
            }
        }

        /// <summary>
        /// Gets or sets the UserAgent
        /// </summary>
        public string UserAgent { get; set; }

        /// <summary>
        /// Gets or sets the Method
        /// </summary>
        public string Method { get; set; }

        /// <summary>
        /// Gets or sets the Url
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the RequestBody
        /// </summary>
        public string RequestBody { get; set; }

        /// <summary>
        /// Gets or sets the IP
        /// </summary>
        public string IP { get; set; }
    }
}
