namespace Verivox.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;
    using System.Net.Http;
    using System.ServiceModel.Channels;
    using System.Web;
    public class RequestHelper
    {
        private static readonly string RequestIdHeaderKey = "request-id";
        private static readonly string ErrorDetail = "error_detail";

        public static bool IsErrorDetail => bool.Parse(ConfigurationManager.AppSettings[ErrorDetail]);
        public static string GetUserHostAddress(HttpRequestMessage request)
        {
            if (request.Properties.ContainsKey("MS_HttpContext"))
            {
                return ((HttpContextWrapper)request.Properties["MS_HttpContext"]).Request.UserHostAddress;
            }
            else if (request.Properties.ContainsKey(RemoteEndpointMessageProperty.Name))
            {
                RemoteEndpointMessageProperty prop;
                prop = (RemoteEndpointMessageProperty)request.Properties[RemoteEndpointMessageProperty.Name];
                return prop.Address;
            }
            return string.Empty;
        }

        public static string GetRequestID(HttpRequestMessage request)
        {
            IEnumerable<string> requestIds;
            var requestID = (request.Headers.TryGetValues(RequestIdHeaderKey, out requestIds)) ? requestIds.First() : string.Empty;
            if (string.IsNullOrEmpty(requestID))
            {
                requestID = NewRequestId();
                request.Headers.Add(RequestIdHeaderKey, requestID);
            }
            return requestID;
        }
        private static string NewRequestId() => Guid.NewGuid().ToString().Replace("-", "").Substring(0, 8);
    }
}