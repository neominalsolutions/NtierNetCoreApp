using DatabaseScaffoldApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace DatabaseScaffoldApplication.Middlewares
{
  
    public class ExceptionMiddleware
    {
        // we manage this middleware go to another middleware operation
        // for manage this we use next command
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        // İf some httpRequest comes in the Application Level
        // this middleware handle automatically for every request and invoke this.
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext httpContext, Exception ex)
        {

            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            var now = DateTime.UtcNow;
            _logger.LogError($"{now.ToString("HH:mm:ss")} : {ex.Message}");

             await Task.CompletedTask;

            //return httpContext.Response.WriteAsync(new ErrorResultModel()
            //{
            //    StatusCode = httpContext.Response.StatusCode,
            //    Message = ex.Message
            //}.ToString());
        }
    }
}
