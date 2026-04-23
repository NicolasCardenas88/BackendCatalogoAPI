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
            object response;

            switch (exception)
            {
                case FluentValidation.ValidationException fvEx:
                    status = HttpStatusCode.BadRequest;
                    response = new
                    {
                        statusCode = (int)status,
                        message = "Errores de validación",
                        errors = fvEx.Errors.Select(e => new {
                            field = e.PropertyName,
                            error = e.ErrorMessage
                        })
                    };
                    break;
                case BadHttpRequestException:
                    status = HttpStatusCode.BadRequest;
                    response = new { statusCode = (int)status, message = exception.Message };
                    break;

                case NotFoundException:
                    status = HttpStatusCode.NotFound;
                    response = new { statusCode = (int)status, message = exception.Message };
                    break;

                case AlreadyExistsException:
                    status = HttpStatusCode.Conflict;
                    response = new { statusCode = (int)status, message = exception.Message };
                    break;

                case DatabaseException:
                    status = HttpStatusCode.InternalServerError;
                    response = new { statusCode = (int)status, message = exception.Message };
                    break;

                default:
                    status = HttpStatusCode.InternalServerError;
                    response = new
                    {
                        statusCode = (int)status,
                        message = "Ha ocurrido un error interno"
                    };
                    break;
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)status;

            return context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
    
}