namespace Verivox
{
    using CustomFilters;
    using System.Web.Http;

    /// <summary>
    /// Defines the <see cref="WebApiConfig" />
    /// </summary>
    public static class WebApiConfig
    {
        /// <summary>
        /// The Register
        /// </summary>
        /// <param name="config">The config<see cref="HttpConfiguration"/></param>
        public static void Register(HttpConfiguration config)
        {
            WebApiFormatter.SetFormat(config);
            config.Filters.Add(new CustomExceptionFilter());
            config.MessageHandlers.Add(new Handlers.MessageHandler());
            config.MapHttpAttributeRoutes();
            SetDefaultRoute(config);
        }

        /// <summary>
        /// The SetDefaultRoute
        /// </summary>
        /// <param name="config">The config<see cref="HttpConfiguration"/></param>
        private static void SetDefaultRoute(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(name: "Default", routeTemplate: "",
                defaults: new { controller = "base", action = "welcome" }
            );
            config.Routes.MapHttpRoute(name: "HealthCheck", routeTemplate: "hc",
                defaults: new { controller = "base", action = "healthcheck" }
            );
            config.Routes.MapHttpRoute(name: "NotFound", routeTemplate: "{*url}",
                defaults: new { controller = "base", action = "forbidden" }
            );
        }
    }
}
