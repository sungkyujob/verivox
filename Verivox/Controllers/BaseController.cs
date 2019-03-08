namespace Verivox.Controllers
{
    using System;
    using System.Web.Http;
    using Errors;
    using Helpers;

    public class BaseController : ApiController
    {
        protected string RequestId {
            get {
                return RequestHelper.GetRequestID(ActionContext.Request);
            }
        }

        [HttpGet]
        [ActionName("welcome")]
        public IHttpActionResult Welcome()
        {
            return Ok("Welcome to Verivox API");
        }

        [HttpGet]
        [ActionName("healthcheck")]
        public IHttpActionResult HealthCheck()
        {
            return Ok();
        }

        [AllowAnonymous]
        [ActionName("forbidden")]
        [HttpGet, HttpPost, HttpPut, HttpDelete, HttpPatch]
        public IHttpActionResult Forbidden()
        {
            throw new ForbiddenException(new Exception("Endpoint Not Found"));
        }
    }
}
