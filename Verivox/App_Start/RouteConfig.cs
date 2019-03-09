namespace Verivox
{
    using System.Web.Routing;

    /// <summary>
    /// Defines the <see cref="RouteConfig" />
    /// </summary>
    public class RouteConfig
    {
        /// <summary>
        /// The RegisterRoutes
        /// </summary>
        /// <param name="routes">The routes<see cref="RouteCollection"/></param>
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.RouteExistingFiles = true;
        }
    }
}
