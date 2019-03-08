namespace Verivox.Models.Log
{
    using Newtonsoft.Json;
    using System.Net.Http;
    using Helpers;
    using System.IO;

    public class Request
    {
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

        public string UserAgent { get; set; }

        public string Method { get; set; }

        public string Url { get; set; }

        public string RequestBody { get; set; }

        public string IP { get; set; }
    }
}