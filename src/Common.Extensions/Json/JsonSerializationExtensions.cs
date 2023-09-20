using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Common.Extensions.Json
{
    public static class JSONSerializationExtensions
    {
        static JSONSerializationExtensions()
        {
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                Culture = System.Globalization.CultureInfo.DefaultThreadCurrentCulture
            };
        }

        /// <summary>
        /// Serializza un oggetto in una stringa json
        /// </summary>
        /// <param name="obj">oggetto da serializzare</param>
        /// <param name="camelCase">true se camel case, false se pascal case</param>
        /// <returns>stringa serializzata</returns>
        public static string Serialize(this object obj, bool camelCase = false)
        {
            return !camelCase ?
                JsonConvert.SerializeObject(obj) :
                JsonConvert.SerializeObject(obj, CAMEL_CASE_SETTINGS);
        }

        /// <summary>
        /// Deserializza una stringa json in un oggetto tipizzato
        /// </summary> 
        public static T Deserialize<T>(this string @string)
        {
            return JsonConvert.DeserializeObject<T>(@string);
        }

        /// <summary>
        /// Deserializza una stringa json in un oggetto
        /// </summary> 
        public static object Deserialize(this string @string, Type type)
        {
            return JsonConvert.DeserializeObject(@string, type);
        }

        private static JsonSerializerSettings CAMEL_CASE_SETTINGS = new JsonSerializerSettings
        {
            ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            }
        };
    }
}
