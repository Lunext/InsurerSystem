namespace Backend.Shared;

public class HeaderMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        const string key = "1234";
        string generatedKey = context.Request.Headers["token"].ToString();

        if (generatedKey!=key)
        {
            context.Response.StatusCode=StatusCodes.Status401Unauthorized;
            await context.Response.WriteAsync("Unauthorized");
            return; 
        }
        await next(context);
    }
    
}

public static class HeaderMiddlewareExtension
{
    public static IApplicationBuilder UseMiddlewareExtension(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<HeaderMiddleware>();
    }
    
}

