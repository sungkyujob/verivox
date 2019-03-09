namespace Verivox.Test.Controllers
{
    using Errors;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Web.Http.Results;
    using TestUtil;
    using Verivox.Controllers;

    /// <summary>
    /// Defines the <see cref="BaseControllerTest" />
    /// </summary>
    [TestClass]
    public class BaseControllerTest
    {
        /// <summary>
        /// Defines the _controller
        /// </summary>
        private BaseController _controller;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseControllerTest"/> class.
        /// </summary>
        public BaseControllerTest()
        {
            _controller = new BaseController();
        }

        /// <summary>
        /// The WelcomeTest
        /// </summary>
        [TestMethod]
        public void WelcomeTest()
        {
            var expectedOutput = Expected.WelCome;
            var result = _controller.Welcome() as OkNegotiatedContentResult<string>;
            Assert.AreEqual(result.Content, expectedOutput);
        }

        /// <summary>
        /// The HealthCheckTest
        /// </summary>
        [TestMethod]
        public void HealthCheckTest()
        {
            var result = _controller.HealthCheck();
            Assert.IsInstanceOfType(result, typeof(OkResult));
        }

        /// <summary>
        /// The ForbiddenTest
        /// </summary>
        [TestMethod]
        public void ForbiddenTest()
        {
            try
            {
                var result = _controller.Forbidden();
            }
            catch (Exception ex)
            {
                var got = ex as ForbiddenException;
                Assert.IsInstanceOfType(got, typeof(ForbiddenException));
            }
        }
    }
}
