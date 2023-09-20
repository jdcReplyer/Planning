using Common.Extensions.Json;
using Common.Extensions.Object;


namespace Gateway.Common.Extensions
{
    public static class HttpClientExtensions
    {
        private static HttpRequestException AsException(this GenericHttpError error)
        {
            return new HttpRequestException(error.Message, new Exception(error.Message));
        }

        private static async Task<GenericHttpError> GetHttpErrorAsync(this HttpResponseMessage message, string stringContent = null)
        {
            if (stringContent == null)
                stringContent = await message.Content.ReadAsStringAsync();

            return stringContent.Deserialize<GenericHttpError>() ??
                new GenericHttpError { Message = message.StatusCode.ToString(), StatusCode = (int)message.StatusCode }; ;
        }

        private static bool IsError(this HttpResponseMessage message)
        {
            return message.Headers.Contains("Exception") || message.Content.Headers.Contains("Exception");
        }

        public static async Task<TResponse> As<TResponse>(this HttpResponseMessage message)
        {
            var stringContent = await message.Content.ReadAsStringAsync();

            if (!message.IsSuccessStatusCode || message.IsError())
            {
                var error = await message.GetHttpErrorAsync(stringContent);
                throw error.AsException();
            }
            return stringContent.Deserialize<TResponse>();
        }

        public static async Task<TResponse> As<TResponse>(this Task<HttpResponseMessage> messageAsync)
        {
            var message = await messageAsync;
            return await message.As<TResponse>();
        }

        public static async Task<TResponse> GetAsync<TResponse>(this HttpClient client, string url)
        {
            return await client.GetAsync(url).As<TResponse>();
        }

        public static async Task<TResponse> DeleteAsync<TResponse>(this HttpClient client, string url)
        {
            return await client.DeleteAsync(url).As<TResponse>();
        }

        public static async Task<TResponse> PostAsync<TResponse>(this HttpClient httpClient, string url, object body)
        {
            return await httpClient.PostAsync(url, body.AsByteArrayContent()).As<TResponse>();
        }

        public static async Task PutAsync(this HttpClient httpClient, string url, object body = null)
        {
            var response = await httpClient.PutAsync(url, body.AsByteArrayContent());

            if (!response.IsSuccessStatusCode || response.IsError())
            {
                var stringContent = await response.Content.ReadAsStringAsync();
                var error = await response.GetHttpErrorAsync(stringContent);
                throw error.AsException();
            }
        }
        public static async Task PostAsync(this HttpClient httpClient, string url, object body = null)
        {
            var response = await httpClient.PostAsync(url, body.AsByteArrayContent());

            if (!response.IsSuccessStatusCode || response.IsError())
            {
                var stringContent = await response.Content.ReadAsStringAsync();
                var error = await response.GetHttpErrorAsync(stringContent);
                throw error.AsException();
            }
        }

        public static async Task<TResponse> PutAsync<TResponse>(this HttpClient httpClient, string url, object body = null)
        {
            return await httpClient.PutAsync(url, body.AsByteArrayContent()).As<TResponse>();
        }

        public static async Task<TResponse> PatchAsync<TResponse>(this HttpClient httpClient, string url, object body = null)
        {
            return await httpClient.PatchAsync(url, body.AsByteArrayContent()).As<TResponse>();
        }
    }

    public class GenericHttpError
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string ErrorType { get; set; }
        public string Details { get; set; }
        public string __Meta { get; set; } = nameof(GenericHttpError);
    }
}
