namespace Verivox
{
    using System.Web.Http;
    using CustomFilters;
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            WebApiFormatter.SetFormat(config);
            config.Filters.Add(new CustomExceptionFilter());
            config.MessageHandlers.Add(new Handlers.MessageHandler());
            config.MapHttpAttributeRoutes();
            SetDefaultRoute(config);
        }

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
