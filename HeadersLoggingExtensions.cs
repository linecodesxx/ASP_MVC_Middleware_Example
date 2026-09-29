using Microsoft.AspNetCore.Builder;

namespace ASP_MVC_Middleware_Example;

public static class HeadersLoggingExtensions
{
    public static IApplicationBuilder UseHeadersLogging(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<HeadersLoggingMiddleware>();
    }
}
