namespace Verivox.Test.Controllers
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Web.Http.Results;
    using Verivox.Controllers;
    using Errors;

    [TestClass]
    public class BaseControllerTest
    {
        private BaseController _controller;
        public BaseControllerTest()
        {
            _controller = new BaseController();
        }

        [TestMethod]
        public void WelcomeTest()
        {
            var expectedOutput = "Welcome to Verivox API";
            var result = _controller.Welcome();
            var ok = result as OkNegotiatedContentResult<string>;
            Assert.AreEqual(ok.Content, expectedOutput);
        }

        [TestMethod]
        public void HealthCheckTest()
        {
            var result = _controller.HealthCheck();
            Assert.IsInstanceOfType(result, typeof(OkResult));
        }

        [TestMethod]
        public void ForbiddenTest()
        {
            try
            {
                var result = _controller.Forbidden();
            }
            catch(Exception ex)
            {
                var got = ex as ForbiddenException;
                Assert.IsInstanceOfType(got, typeof(ForbiddenException));
            }
        }
    }
}
