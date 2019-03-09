namespace Verivox
{
    using System.Web.Http;

    /// <summary>
    /// Defines the <see cref="WebApiFormatter" />
    /// </summary>
    public static class WebApiFormatter
    {
        /// <summary>
        /// The SetFormat
        /// </summary>
        /// <param name="config">The config<see cref="HttpConfiguration"/></param>
        public static void SetFormat(HttpConfiguration config)
        {
            config.Formatters.Clear();
            config.Formatters.Add(Formatters.JsonFormatter.Get());
        }
    }
}
