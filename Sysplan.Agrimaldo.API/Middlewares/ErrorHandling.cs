
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Sysplan.Agrimaldo.API.Middlewares
{
    public class ErrorHandling
    {
        private readonly RequestDelegate next;

        public ErrorHandling(RequestDelegate _next)
        {
            next = _next;
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";

            var _context = context.Features.Get<IExceptionHandlerFeature>();

            return context.Response.WriteAsync((new { Message = "Ocorreu uma falha na API.", Code = "Error" }).ToString());
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }
    }
}
