using System.Net;

namespace TRIDENT_Project.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        //TODO:
        //private readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                // 執行下個 middleware
                await _next(context);
            }
            catch (Exception ex)
            {
                // 捕捉異常，並進行通用錯誤處理
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            // 記錄錯誤日誌，包括函數名稱和堆疊追蹤
            var errorMessage = $"Exception in {ex.TargetSite?.DeclaringType?.FullName}.{ex.TargetSite?.Name}: {ex.Message}";

            //_logger.LogError(ex, errorMessage);

            // 自訂錯誤回應
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";

            var response = new
            {
                message = "An error occurred while processing your request.",
                detail = errorMessage
            };

            return context.Response.WriteAsJsonAsync(response);
        }
    }
}
