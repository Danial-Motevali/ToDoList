using AutoMapper.Configuration.Conventions;
using Microsoft.AspNetCore.Mvc;

namespace ToDoList.EndPoint.CustomMiddlware
{
    public class GlobalErrorMiddlware
    {
        public readonly RequestDelegate _next;
        public readonly ILogger<GlobalErrorMiddlware> _logger;
        public GlobalErrorMiddlware(
            RequestDelegate next,
            ILogger<GlobalErrorMiddlware> logger
            )
        {
            _logger = logger;
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
                _logger.LogError(ex, "Exception occurred: {Message}", ex.Message);

                var problemDetails = new ProblemDetails
                {
                    Status = StatusCodes.Status500InternalServerError,
                    Title = "Server Error"
                };

                context.Response.StatusCode = StatusCodes.Status500InternalServerError;

                await context.Response.WriteAsJsonAsync(problemDetails);
            }
        }
    }
}
