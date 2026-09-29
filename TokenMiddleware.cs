using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ASP_MVC_Middleware_Example;

public class TokenMiddleware
{
    private readonly RequestDelegate _next;
  
    public TokenMiddleware(RequestDelegate next)
    {
        _next = next;
    }
  
    public async Task InvokeAsync(HttpContext context)
    {
        var token = context.Request.Query["token"];
        if (token!="12345678")
        {
            context.Response.StatusCode = 403;
            await context.Response.WriteAsync("Token is invalid");
        }
        else
        {
            await _next.Invoke(context);
        }
    }
}