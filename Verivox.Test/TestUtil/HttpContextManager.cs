namespace Verivox.Test.TestUtil
{
    using Moq;
    using System;
    using System.Security.Principal;
    using System.Web;
    using System.Web.Http.Routing;
    using System.Web.Routing;

    /// <summary>
    /// Defines the <see cref="HttpContextManager" />
    /// </summary>
    public class HttpContextManager
    {
        /// <summary>
        /// Defines the m_context
        /// </summary>
        private static HttpContextBase m_context;

        /// <summary>
        /// Gets the Current
        /// </summary>
        public static HttpContextBase Current
        {
            get
            {
                if (m_context != null)
                {
                    return m_context;
                }
                if (HttpContext.Current == null)
                {
                    throw new InvalidOperationException("HttpContext not available");
                }
                return new HttpContextWrapper(HttpContext.Current);
            }
        }

        /// <summary>
        /// The SetCurrentContext
        /// </summary>
        /// <param name="context">The context<see cref="HttpContextBase"/></param>
        public static void SetCurrentContext(HttpContextBase context)
        {
            m_context = context;
        }

        /// <summary>
        /// The GetMockedHttpContext
        /// </summary>
        /// <returns>The <see cref="HttpContextBase"/></returns>
        public static HttpContextBase GetMockedHttpContext()
        {
            var context = new Mock<HttpContextBase>();
            var request = new Mock<HttpRequestBase>();
            var response = new Mock<HttpResponseBase>();
            var session = new Mock<HttpSessionStateBase>();
            var server = new Mock<HttpServerUtilityBase>();
            var user = new Mock<IPrincipal>();
            var identity = new Mock<IIdentity>();
            var urlHelper = new Mock<UrlHelper>();
            var routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);
            var requestContext = new Mock<RequestContext>();
            requestContext.Setup(x => x.HttpContext).Returns(context.Object);
            context.Setup(ctx => ctx.Request).Returns(request.Object);
            context.Setup(ctx => ctx.Response).Returns(response.Object);
            context.Setup(ctx => ctx.Session).Returns(session.Object);
            context.Setup(ctx => ctx.Server).Returns(server.Object);
            context.Setup(ctx => ctx.User).Returns(user.Object);
            user.Setup(ctx => ctx.Identity).Returns(identity.Object);
            identity.Setup(id => id.IsAuthenticated).Returns(true);
            request.Setup(req => req.Url).Returns(Expected.Uri);
            request.Setup(req => req.UserHostAddress).Returns(Expected.IpAddress);
            request.Setup(req => req.RequestContext).Returns(requestContext.Object);
            requestContext.Setup(x => x.RouteData).Returns(new RouteData());
            request.SetupGet(req => req.Headers).Returns(Expected.RequestHeader);
            return context.Object;
        }
    }
}
