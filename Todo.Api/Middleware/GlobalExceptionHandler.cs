using System.Net;
using System.Text.Json;

namespace Todo.Api.Middleware
{
    public class GlobalExceptionHandler
    {

        private readonly RequestDelegate _requestDelegate;

        public GlobalExceptionHandler(RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _requestDelegate(context);
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";

                var result = JsonSerializer.Serialize(new
                {
                    code = 500,
                    success = false,
                    message = "Api Connection Failed",
                    error = ex.Message
                });

                await context.Response.WriteAsync(result);
            }
        }
    }
}