namespace Verivox
{
    using System.Web.Http;
    public static class WebApiFormatter
    {
        public static void SetFormat(HttpConfiguration config)
        {
            config.Formatters.Clear();
            config.Formatters.Add(Formatters.JsonFormatter.Get());
        }
    }
}
