using Common.Middlewares.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net;

namespace Common.Middlewares.WrappersController
{
    public class DataWrapperControllerMiddleware
    {

        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        public DataWrapperControllerMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<DataWrapperControllerMiddleware>();
            _next = next;
        }

        private static object Transform(object obj)
        {
            var jsonType = obj.GetType();
            if (jsonType.Name == "JArray")
            {
                return new DataWrapperController() { values = obj };
            }
            return obj;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            // If list wrapper header is present, the middleware will work, otherwise not
            if (!httpContext.Request.Headers.TryGetValue(Constants.LIST_WRAPPER_HEADER_KEY, out Microsoft.Extensions.Primitives.StringValues value))
                await _next(httpContext);
            else
            {
                Stream originalBody = httpContext.Response.Body;
                try
                {
                    using (var memStream = new MemoryStream())
                    {
                        httpContext.Response.Body = memStream;

                        await _next(httpContext);

                        httpContext.Response.Body = originalBody;

                        memStream.Seek(0, SeekOrigin.Begin);
                        object? responseBody = null;

                        try
                        {
                            responseBody = JsonConvert.DeserializeObject<object>(new StreamReader(memStream).ReadToEnd());
                        }
                        catch (JsonReaderException)
                        {
                            // If not a Json this middleware will be skipped
                            memStream.Position = 0;
                            await memStream.CopyToAsync(originalBody);
                        }

                        if (responseBody != null)
                        {
                            var strResponseBody = JsonConvert.SerializeObject(Transform(responseBody));
                            memStream.SetLength(0);
                            memStream.Position = 0;
                            var sw = new StreamWriter(memStream);
                            sw.Write(strResponseBody);
                            sw.Flush();

                            memStream.Position = 0; // If they are some problems, put "memStream.Seek(0, SeekOrigin.Begin)" before this line.
                            httpContext.Response.ContentLength = memStream.Length;
                            await memStream.CopyToAsync(originalBody);
                        }
                    }

                }
                catch (Exception ex)
                {
                    _logger.LogError($"Something went wrong: {ex}");
                    await HandleExceptionAsync(httpContext, ex);
                }
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            await context.Response.WriteAsync(new ErrorDetail()
            {
                StatusCode = context.Response.StatusCode,
                Message = exception.Message
            }.ToString());
        }
    }
}
