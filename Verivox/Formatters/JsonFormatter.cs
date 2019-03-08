namespace Verivox.Formatters
{
    using Newtonsoft.Json.Serialization;
    using System.Net.Http.Formatting;
    using System.Text.RegularExpressions;
    public static class JsonFormatter
    {
        public static JsonMediaTypeFormatter Get()
        {
            var jFormatter = new JsonMediaTypeFormatter();
            jFormatter.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
            jFormatter.SerializerSettings.ContractResolver = new UnderscorePropertyNamesContractResolver();
            jFormatter.UseDataContractJsonSerializer = false;
            return jFormatter;
        }
        public class UnderscorePropertyNamesContractResolver : DefaultContractResolver
        {
            public UnderscorePropertyNamesContractResolver() : base() { }

            protected override string ResolvePropertyName(string propertyName)
            {
                return Regex.Replace(propertyName, @"(\w)([A-Z])", "$1_$2").ToLower();
            }
        }
    }
}
