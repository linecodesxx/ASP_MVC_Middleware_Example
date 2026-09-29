using Microsoft.AspNetCore.Builder;

namespace ASP_MVC_Middleware_Example;

public static class TokenExtensions
{
    public static IApplicationBuilder UseToken(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<TokenMiddleware>();
    }
}