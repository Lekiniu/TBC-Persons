using Newtonsoft.Json;
using Serilog;
using System.Text;

namespace Person.API.Middleware
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate next;
        private string requestBody;

        public LoggingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await ReadRequestBody(httpContext);

                await next(httpContext);
            }
            catch (Exception ex)
            {
                LogException(httpContext, ex);
            }
        }

        private async Task ReadRequestBody(HttpContext httpContext)
        {
            // read request body
            httpContext.Request.EnableBuffering();

            using (var reader = new StreamReader(
                httpContext.Request.Body,
                encoding: Encoding.UTF8,
                detectEncodingFromByteOrderMarks: false,
                bufferSize: 1024,
                leaveOpen: true
                ))
            {
                requestBody = await reader.ReadToEndAsync();

                // reset the request body stream position so that next middleware can read it
                httpContext.Request.Body.Position = 0;
            }
        }

        private void LogException(HttpContext httpContext, Exception ex)
        {
            ExceptionModel exceptionModel = new ExceptionModel();
            exceptionModel.HttpMethod = httpContext.Request.Method;
            exceptionModel.QueryStringValue = httpContext.Request.QueryString.Value;
            exceptionModel.RequestBody = requestBody;
            exceptionModel.ExceptionMessage = ex.Message;
            exceptionModel.ExceptionStackSTrace = ex.StackTrace;
            exceptionModel.InnerExceptionMessage = ex.InnerException?.Message;
            exceptionModel.InnerExceptionStackTrace = ex.InnerException?.StackTrace;

            Log.Error("Exception in Application. " + JsonConvert.SerializeObject(exceptionModel));
        }
    }

    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseLoggingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LoggingMiddleware>();
        }
    }

    public class ExceptionModel
    {
        public string HttpMethod { get; set; }
        public string QueryStringValue { get; set; }
        public string RequestBody { get; set; }
        public string ExceptionMessage { get; set; }
        public string ExceptionStackSTrace { get; set; }
        public string InnerExceptionMessage { get; set; }
        public string InnerExceptionStackTrace { get; set; }
    }
}