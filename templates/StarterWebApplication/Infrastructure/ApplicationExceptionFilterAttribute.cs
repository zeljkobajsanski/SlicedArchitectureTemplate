using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace StarterWebApplication.Infrastructure
{
    public class ApplicationExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            switch (context.Exception)
            {
                default:
                    context.Result = new BadRequestObjectResult(context.Exception.Message);
                    break;
            }
        }
    }
}