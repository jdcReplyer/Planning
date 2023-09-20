using Common.Extensions.Json;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Net.Http.Headers;
using System.Web;

namespace Common.Extensions.Object
{
    public static class ObjectExtensions
    {
        public static ByteArrayContent AsByteArrayContent(this object body)
        {
            if (body == null) return null;

            var jsonObject = body.Serialize();
            var buffer = System.Text.Encoding.UTF8.GetBytes(jsonObject);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return byteContent;
        }


        /// <summary>
        /// Converte QueryString a JObject, oggetto pronto per la serializzazione
        /// </summary>
        public static Newtonsoft.Json.Linq.JObject AsJObject(this QueryString queryString)
        {
            var dict = HttpUtility.ParseQueryString(queryString.Value);
            string json = JsonConvert.SerializeObject(dict.Cast<string>().ToDictionary(k => k, v => dict[v]));
            return Newtonsoft.Json.Linq.JObject.Parse(json);
        }


        public static IEnumerable<DateTime> Range(this DateTime startDate, DateTime endDate)
        {
            return Enumerable.Range(0, (endDate - startDate).Days + 1).Select(d => startDate.AddDays(d));
        }

        public static DateTime TimeZone(this DateTimeOffset dateTimeOffset, string timeZoneId)
        {
            var info = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);

            DateTimeOffset localServerTime = DateTimeOffset.Now;

            DateTimeOffset usersTime = TimeZoneInfo.ConvertTime(localServerTime, info);

            DateTimeOffset date = localServerTime.ToUniversalTime();

            return date.UtcDateTime;
        }

        public static DateTime TimeZone(this DateTime dateTime, string localZone)
        {
            DateTime serverTime = dateTime; // gives you current Time in server timeZone
            DateTime utcTime = serverTime.ToUniversalTime(); // convert it to Utc using timezone setting of server computer

            TimeZoneInfo tze = TimeZoneInfo.FindSystemTimeZoneById(localZone);
            DateTime localTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, tze); // convert from utc to local
            return localTime;

        }
    }
}
