namespace Verivox.Formatters
{
    using Newtonsoft.Json.Serialization;
    using System.Net.Http.Formatting;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Defines the <see cref="JsonFormatter" />
    /// </summary>
    public static class JsonFormatter
    {
        /// <summary>
        /// The Get
        /// </summary>
        /// <returns>The <see cref="JsonMediaTypeFormatter"/></returns>
        public static JsonMediaTypeFormatter Get()
        {
            var jFormatter = new JsonMediaTypeFormatter();
            jFormatter.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
            jFormatter.SerializerSettings.ContractResolver = new UnderscorePropertyNamesContractResolver();
            jFormatter.UseDataContractJsonSerializer = false;
            return jFormatter;
        }

        /// <summary>
        /// Defines the <see cref="UnderscorePropertyNamesContractResolver" />
        /// </summary>
        public class UnderscorePropertyNamesContractResolver : DefaultContractResolver
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="UnderscorePropertyNamesContractResolver"/> class.
            /// </summary>
            public UnderscorePropertyNamesContractResolver() : base()
            {
            }

            /// <summary>
            /// The ResolvePropertyName
            /// </summary>
            /// <param name="propertyName">The propertyName<see cref="string"/></param>
            /// <returns>The <see cref="string"/></returns>
            protected override string ResolvePropertyName(string propertyName)
            {
                return Regex.Replace(propertyName, @"(\w)([A-Z])", "$1_$2").ToLower();
            }
        }
    }
}
