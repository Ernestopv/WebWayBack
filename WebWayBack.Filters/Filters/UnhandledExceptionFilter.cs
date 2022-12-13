using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using WebWayBack.Models.Filter.Errors;

namespace WebWayBack.Filters.Filters
{
    public class UnhandledExceptionFilter: IAsyncExceptionFilter
    {
        private readonly ILogger<UnhandledExceptionFilter> _logger;
        public UnhandledExceptionFilter(ILogger<UnhandledExceptionFilter> logger)
        {
            _logger = logger;
        }

        public Task OnExceptionAsync(ExceptionContext context)
        {
            if (!context.ExceptionHandled && context.Exception is Exception exception)
            {
                _logger.LogError(exception, "Unhandled exception!");

                var response = new ErrorResponse
                {
                    StatusCode = StatusCodes.Status500InternalServerError
                };

                response.Details.Add(new ErrorResponseDetail
                {
                    Message = "An error occurred, please try again later."
                });

                context.Result = new ObjectResult(response)
                {
                    StatusCode = StatusCodes.Status500InternalServerError
                };

                context.ExceptionHandled = true;
            }

            return Task.CompletedTask;
        }


    }
}
