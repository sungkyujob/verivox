namespace Verivox
{
    using SimpleInjector;
    using System.Web.Http;
    using System.Web.Mvc;
    using System.Web.Routing;
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            SimpleInjectorConfig.RegisterServices(new Container());
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
        }

        protected void Application_PreSendRequestHeaders()
        {
            Response.Headers.Remove("Server");
            Response.Headers.Remove("X-AspNet-Version");
        }
    }
}
