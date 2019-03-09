namespace Verivox
{
    using Logger;
    using SimpleInjector;
    using SimpleInjector.Integration.WebApi;
    using System;
    using System.Web.Http;

    /// <summary>
    /// Defines the <see cref="SimpleInjectorConfig" />
    /// </summary>
    public static class SimpleInjectorConfig
    {
        /// <summary>
        /// Gets the logConfigPath
        /// </summary>
        private static string logConfigPath => AppDomain.CurrentDomain.BaseDirectory + "NLog.config";

        /// <summary>
        /// The RegisterServices
        /// </summary>
        /// <param name="container">The container<see cref="Container"/></param>
        public static void RegisterServices(Container container)
        {
            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
            container.Register<ILogger>(() => new Logger.Logger(logConfigPath), Lifestyle.Singleton);
            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
            container.Verify();
        }
    }
}
