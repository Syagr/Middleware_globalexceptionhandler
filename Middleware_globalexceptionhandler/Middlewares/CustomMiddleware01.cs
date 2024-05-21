using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Middleware_globalexceptionhandler.Middlewares
{
    public class CustomMiddleware01 : IMiddleware
    {
        private readonly ILogger<CustomMiddleware01> _logger;

        public CustomMiddleware01(ILogger<CustomMiddleware01> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            _logger.LogInformation("CustomMiddleware01: Handling request");
            context.Response.Headers.Add("X-Custom-Header", "Added by CustomMiddleware01");
            await next(context);
            _logger.LogInformation("CustomMiddleware01: Finished handling request");
        }
    }
}