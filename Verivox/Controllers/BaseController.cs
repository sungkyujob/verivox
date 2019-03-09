namespace Verivox.Controllers
{
    using Errors;
    using Helpers;
    using System;
    using System.Web.Http;

    /// <summary>
    /// Defines the <see cref="BaseController" />
    /// </summary>
    public class BaseController : ApiController
    {
        /// <summary>
        /// Gets the RequestId
        /// </summary>
        protected string RequestId
        {
            get
            {
                return RequestHelper.GetRequestID(ActionContext.Request);
            }
        }

        /// <summary>
        /// The Welcome
        /// </summary>
        /// <returns>The <see cref="IHttpActionResult"/></returns>
        [HttpGet]
        [ActionName("welcome")]
        public IHttpActionResult Welcome()
        {
            return Ok("Welcome to Verivox API");
        }

        /// <summary>
        /// The HealthCheck
        /// </summary>
        /// <returns>The <see cref="IHttpActionResult"/></returns>
        [HttpGet]
        [ActionName("healthcheck")]
        public IHttpActionResult HealthCheck()
        {
            return Ok();
        }

        /// <summary>
        /// The Forbidden
        /// </summary>
        /// <returns>The <see cref="IHttpActionResult"/></returns>
        [AllowAnonymous]
        [ActionName("forbidden")]
        [HttpGet, HttpPost, HttpPut, HttpDelete, HttpPatch]
        public IHttpActionResult Forbidden()
        {
            throw new ForbiddenException(new Exception("Endpoint Not Found"));
        }
    }
}
