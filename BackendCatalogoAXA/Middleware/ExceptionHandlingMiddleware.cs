using System.Net;
using System.Text.Json;
using BackendCatalogoAXA.Logic.Exceptions;

namespace BackendCatalogoAXA.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            HttpStatusCode status;
            string message = exception.Message;

            switch (exception)
            {
                case ValidationException:
                    status = HttpStatusCode.BadRequest;
                    break;
                case NotFoundException:
                    status = HttpStatusCode.NotFound;
                    break;
                case AlreadyExistsException:
                    status = HttpStatusCode.Conflict;

                    break;
                case DatabaseException:
                    status = HttpStatusCode.InternalServerError;
                    break;
                default:
                    status = HttpStatusCode.InternalServerError;
                    message = "Ha ocurrido un error interno";
                    break;
            }

            var response = new
            {
                statusCode = (int)status,
                message = message
            };

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)status;

            return context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}