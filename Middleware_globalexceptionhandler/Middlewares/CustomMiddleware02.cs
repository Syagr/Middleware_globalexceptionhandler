using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Middleware_globalexceptionhandler.Middlewares
{
    public class CustomMiddleware02 : IMiddleware
    {
        private readonly ILogger<CustomMiddleware02> _logger;

        public CustomMiddleware02(ILogger<CustomMiddleware02> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            _logger.LogInformation("CustomMiddleware02: Handling request");
            if (context.Request.Headers.ContainsKey("X-Special-Header"))
            {
                _logger.LogInformation("CustomMiddleware02: Special header found in request");
            }
            await next(context);
            _logger.LogInformation("CustomMiddleware02: Finished handling request");
        }
    }
}