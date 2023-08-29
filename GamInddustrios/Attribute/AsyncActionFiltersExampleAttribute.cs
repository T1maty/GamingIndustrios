using Microsoft.AspNetCore.Mvc.Filters;

namespace GamingIndustrios.Attribute
{
    internal class AsyncActionFiltersExampleAttribute : System.Attribute
    {
        private readonly string _name;

        public AsyncActionFiltersExampleAttribute(string name)
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