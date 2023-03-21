using Microsoft.AspNetCore.Mvc.Filters;

namespace GamingIndustrios.ActionFilters
{
    public class AsyncActionFiltersExample : Attribute, IAsyncActionFilter
    {
        private readonly string _name;

        public AsyncActionFiltersExample(string name)
        {
            _name = name;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            Console.WriteLine($"Before async Execution - {_name}");
            await next();
            Console.WriteLine($"After async Execution - {_name}");
        }
    }
}
