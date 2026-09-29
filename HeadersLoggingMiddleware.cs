using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ASP_MVC_Middleware_Example;

public class HeadersLoggingMiddleware
{
    private const string LogFilePath = "request_headers.txt";
    private static readonly object FileLock = new();

    private readonly RequestDelegate _next;

    public HeadersLoggingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        WriteLog(context);
        await _next.Invoke(context);
    }

    private static void WriteLog(HttpContext context)
    {
        var sb = new StringBuilder();
        sb.AppendLine($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {context.Request.Method} {context.Request.Path}");
        foreach (var header in context.Request.Headers)
        {
            sb.AppendLine($"  {header.Key}: {header.Value}");
        }
        sb.AppendLine();

        lock (FileLock)
        {
            File.AppendAllText(LogFilePath, sb.ToString());
        }
    }
}
