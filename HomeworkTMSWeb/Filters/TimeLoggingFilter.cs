using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace HomeworkTMSWeb.Filters
{
    public class TimeLoggingFilter : Attribute, IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var timer = new Stopwatch();
            timer.Start();
            context.HttpContext.Response.OnStarting(() =>
            {
                timer.Stop();
                context.HttpContext.Response.Headers.Append("X-Response-Time-Milliseconds", timer.ElapsedMilliseconds.ToString());
                return Task.CompletedTask;
            });

            await next();
        }
    }
}
