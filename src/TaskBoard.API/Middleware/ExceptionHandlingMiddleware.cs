namespace TaskBoard.API.Middleware;

// Catches exceptions and returns appropriate HTTP status codes and error messages.
public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (FluentValidation.ValidationException ex)
        {
            context.Response.StatusCode = 400;
            context.Response.ContentType = "application/json";

            var errors = ex.Errors.Select(e => new
            {
                e.PropertyName,
                e.ErrorMessage
            });

            await context.Response.WriteAsJsonAsync(new { errors });
        }
        catch (KeyNotFoundException ex)
        {
            context.Response.StatusCode = 404;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsJsonAsync(new { error = ex.Message });
        }
        catch (UnauthorizedAccessException ex)
        {
            context.Response.StatusCode = 401;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsJsonAsync(new { error = ex.Message });
        }
        catch (Exception)
        {
            context.Response.StatusCode = 500;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsJsonAsync(new { error = "An unexpected error occurred." });
        }
    }
}