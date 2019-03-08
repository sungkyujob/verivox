namespace Verivox
{
    using SimpleInjector;
    using SimpleInjector.Integration.WebApi;
    using System.Web.Http;
    using Logger;
    using System;

    public static class SimpleInjectorConfig
    {
        private static string logConfigPath => AppDomain.CurrentDomain.BaseDirectory + "NLog.config";
        public static void RegisterServices(Container container)
        {
            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
            container.Register<ILogger>(() => new Logger.Logger(logConfigPath), Lifestyle.Singleton);
            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
            container.Verify();
        }
    }
}