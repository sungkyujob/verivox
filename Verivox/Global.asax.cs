namespace Verivox
{
    using SimpleInjector;
    using System.Web.Http;
    using System.Web.Mvc;
    using System.Web.Routing;

    /// <summary>
    /// Defines the <see cref="WebApiApplication" />
    /// </summary>
    public class WebApiApplication : System.Web.HttpApplication
    {
        /// <summary>
        /// The Application_Start
        /// </summary>
        protected void Application_Start()
        {
            SimpleInjectorConfig.RegisterServices(new Container());
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
        }

        /// <summary>
        /// The Application_PreSendRequestHeaders
        /// </summary>
        protected void Application_PreSendRequestHeaders()
        {
            Response.Headers.Remove("Server");
            Response.Headers.Remove("X-AspNet-Version");
        }
    }
}
