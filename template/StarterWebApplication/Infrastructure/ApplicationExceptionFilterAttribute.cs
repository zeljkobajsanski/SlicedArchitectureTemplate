using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using StarterWebApplication.Exceptions;

namespace StarterWebApplication.Infrastructure
{
    public class ApplicationExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            switch (context.Exception)
            {
                case StarterWebApplicationException e:
                    context.Result = new BadRequestObjectResult(e.Message);
                    break;
                default:
                    context.Result = new BadRequestObjectResult(context.Exception.Message);
                    break;
            }
        }
    }
}