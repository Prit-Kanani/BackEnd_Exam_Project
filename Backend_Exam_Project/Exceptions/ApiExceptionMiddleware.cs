using FluentValidation;

namespace Backend_Exam_Project.Exceptions;

public class ApiExceptionMiddleware(RequestDelegate next)
{
    private readonly RequestDelegate _next = next;

    public async Task Invoke(HttpContext http)
    {
        try
        {
            await _next(http);
        }
        catch (ValidationException ex) // FluentValidation
        {
            http.Response.StatusCode = StatusCodes.Status400BadRequest;
            await http.Response.WriteAsJsonAsync(new { errors = ex.Errors.Select(e => e.ErrorMessage) });
        }
        catch (NotFoundException ex) // custom
        {
            http.Response.StatusCode = StatusCodes.Status404NotFound;
            await http.Response.WriteAsJsonAsync(new { error = ex.Message });
        }
        catch (UnauthorizedAccessException)
        {
            http.Response.StatusCode = StatusCodes.Status403Forbidden;
        }
        catch (Exception)
        {
            http.Response.StatusCode = StatusCodes.Status500InternalServerError;
        }
    }
}
