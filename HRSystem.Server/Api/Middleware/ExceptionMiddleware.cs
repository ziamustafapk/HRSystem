using HRSystem.Server.DataTransferObjects.Exceptions;
using System.Net;
using System.Text.Json;
using HRSystem.Server.Entities.Exceptions;

namespace HRSystem.Server.Api.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;


        public ExceptionMiddleware(RequestDelegate next)
        {

            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (AccessViolationException avEx)
            {
                //Log Something
                await HandleExceptionAsync(httpContext, avEx);
            }
            catch (Exception ex)
            {

                //Log Something
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";


            HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError;
            string? message;
            
            switch (exception)
            {
                case EntityNotFoundException:
                    context.Response.StatusCode = StatusCodes.Status404NotFound;
                    message = exception.Message;
                    break;
                case AlreadyExistException:
                    context.Response.StatusCode = StatusCodes.Status404NotFound;
                    message = exception.Message;
                    break;
                case ValidationErrorsException validationException:
                    httpStatusCode = HttpStatusCode.BadRequest;
                    
                    message = JsonSerializer.Serialize(validationException.ValidationErrorsWithName);
                    break;
                default:
                    message = "Internal Server Error from the custom middleware.";
                    break;
            }
            context.Response.StatusCode = (int)httpStatusCode;

            await context.Response.WriteAsync(message);


        }



    }

}
