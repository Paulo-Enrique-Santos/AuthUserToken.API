using HomeBrokerSimulator.Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (NotFoundException ex)
        {
            await HandleCustomException(context, ex.StatusCode, ex.Message);
        }
        catch (BadRequestException ex)
        {
            await HandleCustomException(context, ex.StatusCode, ex.Message);
        }
        catch (ConflictException ex)
        {
            await HandleCustomException(context, ex.StatusCode, ex.Message);
        }
        catch (InternalServerErrorException ex)
        {
            await HandleCustomException(context, ex.StatusCode, ex.Message);
        }
    }


    private async Task HandleCustomException(HttpContext context, int statusCode, string message)
    {
        context.Response.StatusCode = statusCode;
        context.Response.ContentType = "application/json";

        // Retornar uma resposta JSON com informações sobre o erro
        var errorResponse = new { message = message };
        var json = JsonConvert.SerializeObject(errorResponse);
        await context.Response.WriteAsync(json);
    }
}
