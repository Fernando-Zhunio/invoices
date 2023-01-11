using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace invoices.Filters
{
    public class FilterValidationResponseApiAttribute : ActionFilterAttribute
    {
        private readonly ILogger<FilterValidationResponseApiAttribute> logger;

        public FilterValidationResponseApiAttribute(ILogger<FilterValidationResponseApiAttribute> logger)
        {
            this.logger = logger;
        }

         public override void OnActionExecuting(ActionExecutingContext actionContext)
        {
            if (actionContext.ModelState.IsValid == false)
            {
                actionContext.Result = new BadRequestObjectResult(actionContext.ModelState);
            }

            logger.LogInformation("OnActionExecuting");
        }

        
      
    }
}
