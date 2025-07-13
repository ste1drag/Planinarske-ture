using System.Net;
using System.Text.Json;
using Tours.Application.Common.Exceptions;

namespace Tours.API.Middleware
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                await HandleExceptionAsync(context, exception);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            (HttpStatusCode statusCode, object result) response = exception switch
            {
                ValidationException validationException => 
                    (HttpStatusCode.BadRequest, new { Message = validationException.Message, Errors = validationException.Errors }),
                
                NotFoundException notFoundException => 
                    (HttpStatusCode.NotFound, new { Message = notFoundException.Message }),
                
                _ => (HttpStatusCode.InternalServerError, new { Message = "An error occurred while processing your request." })
            };

            context.Response.StatusCode = (int)response.statusCode;
            await context.Response.WriteAsync(JsonSerializer.Serialize(response.result));
        }
    }

    public static class ExceptionHandlerMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlerMiddleware>();
        }
    }
}