using Bazar.Service.Exeptions;

namespace OnlineBazarWebAPI.Middlewares
{
    public class OnlineBazarExceptionMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<OnlineBazarExceptionMiddleware> logger;
        public OnlineBazarExceptionMiddleware(RequestDelegate next, ILogger<OnlineBazarExceptionMiddleware> logger)
        {
            this.next = next;
            this.logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {

            try
            {
                await next.Invoke(context);
            }
            catch (OnlineBazarExeption ex)
            {
                await HandleException(context, ex.Code, ex.Message);
            }
            catch (Exception ex)
            {
                //Log
                logger.LogError(ex.ToString());

                await HandleException(context, 500, ex.Message);
            }
        }

        public async Task HandleException(HttpContext context, int code, string message)
        {
            context.Response.StatusCode = code;
            await context.Response.WriteAsJsonAsync(new
            {
                Code = code,
                Message = message
            });
        }
    }
}
