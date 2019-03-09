namespace Verivox.Test.Controllers
{
    using Helpers;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Net.Http;
    using TestUtil;

    /// <summary>
    /// Defines the <see cref="RequestHelperTest" />
    /// </summary>
    [TestClass]
    public class RequestHelperTest
    {
        /// <summary>
        /// Defines the request
        /// </summary>
        private HttpRequestMessage request;

        /// <summary>
        /// Initializes a new instance of the <see cref="RequestHelperTest"/> class.
        /// </summary>
        public RequestHelperTest()
        {
            request = new HttpRequestMessage();
            request.Headers.Add("request-id", Expected.RequestID);
        }

        /// <summary>
        /// The GetRequestIDTest
        /// </summary>
        [TestMethod]
        public void GetRequestIDTest()
        {
            var requestID = RequestHelper.GetRequestID(request);
            Assert.AreEqual(Expected.RequestID, requestID);
        }
    }
}
