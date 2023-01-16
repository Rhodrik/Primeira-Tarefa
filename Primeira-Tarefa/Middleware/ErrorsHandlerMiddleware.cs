using FluentValidation;
using Newtonsoft.Json;
using Primeira_Tarefa.Errors;

namespace Primeira_Tarefa.Middleware
{
    public class ErrorsHandlerMiddleware 
    {
        private readonly RequestDelegate _next;

        public ErrorsHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }

            catch (ValidationException validationexception)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = 400;

                var content = new
                {
                    message = Errors.ErrorCodes.EM400,
                    errorCode = nameof(ErrorCodes.EM400),
                    detail = validationexception.Errors
                };

                string result = JsonConvert.SerializeObject(content);

                await context.Response.WriteAsync(result);
            }

            catch (Exception ex)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = 500;
                var content = new
                {
                    message = ErrorCodes.EM500,
                    errorCode = nameof(ErrorCodes.EM500),
                    ExceptionDetail = ex
                };
                string result = JsonConvert.SerializeObject(content);
                await context.Response.WriteAsync(result);
            }
        }
    }
}
