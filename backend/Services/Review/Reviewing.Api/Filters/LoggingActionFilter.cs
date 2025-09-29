// LoggingActionFilter.cs
using Microsoft.AspNetCore.Mvc.Filters;

public class LoggingActionFilter : IActionFilter
{
    private readonly ILogger<LoggingActionFilter> _logger;
    public LoggingActionFilter(ILogger<LoggingActionFilter> logger) => _logger = logger;

    public void OnActionExecuting(ActionExecutingContext context)
    {
        _logger.LogInformation("Handling {Controller}.{Action}",
            context.Controller.GetType().Name,
            context.ActionDescriptor.DisplayName);
    }
    public void OnActionExecuted(ActionExecutedContext context) { }
}