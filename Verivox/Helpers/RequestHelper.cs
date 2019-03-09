namespace Verivox.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;
    using System.Net.Http;
    using System.ServiceModel.Channels;
    using System.Web;

    /// <summary>
    /// Defines the <see cref="RequestHelper" />
    /// </summary>
    public class RequestHelper
    {
        /// <summary>
        /// Defines the RequestIdHeaderKey
        /// </summary>
        private static readonly string RequestIdHeaderKey = "request-id";

        /// <summary>
        /// Defines the ErrorDetail
        /// </summary>
        private static readonly string ErrorDetail = "error_detail";

        /// <summary>
        /// Gets a value indicating whether IsErrorDetail
        /// </summary>
        public static bool IsErrorDetail => bool.Parse(ConfigurationManager.AppSettings[ErrorDetail]);

        /// <summary>
        /// The GetUserHostAddress
        /// </summary>
        /// <param name="request">The request<see cref="HttpRequestMessage"/></param>
        /// <returns>The <see cref="string"/></returns>
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

        /// <summary>
        /// The GetRequestID
        /// </summary>
        /// <param name="request">The request<see cref="HttpRequestMessage"/></param>
        /// <returns>The <see cref="string"/></returns>
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

        /// <summary>
        /// The NewRequestId
        /// </summary>
        /// <returns>The <see cref="string"/></returns>
        private static string NewRequestId() => Guid.NewGuid().ToString().Replace("-", "").Substring(0, 8);
    }
}
