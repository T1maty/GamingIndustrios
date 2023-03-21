using Microsoft.AspNetCore.Mvc.Filters;

namespace GamingIndustrios.ActionFilters
{
    public class ActionFiltersExample : Attribute, IActionFilter
    {
        private readonly string _name;

        public ActionFiltersExample(string name)
        {
            name = _name;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine($"OnActionExecuted - {_name}");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine($"OnActionExecuting - {_name}");
        }
    }
}
