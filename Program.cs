using ASP_MVC_Middleware_Example;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//app.UseMiddleware<TokenMiddleware>();
app.UseToken();

app.MapGet("/", () => "Hello World!");

app.Run();