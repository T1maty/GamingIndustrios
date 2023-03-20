using Microsoft.AspNetCore.Mvc.Filters;

namespace GamingIndustrios.ActionFilters
{
    public class ActionFiltersExample : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("OnActionExecuted");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine("OnActionExecuting");
        }
    }
}
