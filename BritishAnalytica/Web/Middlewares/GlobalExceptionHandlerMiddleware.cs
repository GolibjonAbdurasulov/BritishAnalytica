using System.Net;
using Entity.Exceptions.Common;
using Web.Common;

namespace Web.Middlewares;

public class GlobalExceptionHandlerMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception e)
        {
            if (e is ApiExceptionBase apiException)
            {
                context.Response.StatusCode = apiException.StatusCode;
                await context.Response.WriteAsJsonAsync(
                    ResponseModelBase.ResultFromException(e, (HttpStatusCode)apiException.StatusCode));
            }
            else
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await context.Response.WriteAsJsonAsync(
                    ResponseModelBase.ResultFromException(e, HttpStatusCode.InternalServerError));
            }
            
        }
        finally
        {
        }
    }
}