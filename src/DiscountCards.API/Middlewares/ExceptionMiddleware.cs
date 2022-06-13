using System;
using System.IO;
using System.Threading.Tasks;
using DiscountCards.Core;
using Microsoft.AspNetCore.Http;

namespace DiscountCards.API.Middlewares
{
    public class ExceptionMiddleware
    {
        public readonly RequestDelegate next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await next(httpContext);
            }
            catch (ValidationException exception)
            {
                httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                await httpContext.Response.WriteAsJsonAsync(new { Message = exception.Message, Value = exception.Value });
            }
            catch (Exception exception)
            {
                using (StreamWriter sw = new StreamWriter("log.txt", true))
                {
                    await sw.WriteLineAsync($"Message - {exception.Message}");
                    sw.Close();
                }
                
                httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await httpContext.Response.WriteAsJsonAsync(new { Message = "Внутренняя ошибка сервера" });
            }
        }
    }
}