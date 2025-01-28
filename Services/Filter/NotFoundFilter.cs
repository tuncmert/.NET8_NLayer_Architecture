using App.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace App.Services.Filter;
public class NotFoundFilter<T, TId>(IGenericRepository<T, TId> genericRepository) : Attribute, IAsyncActionFilter where T : class where TId : struct
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var idValue = context.ActionArguments.TryGetValue("id", out var idAsObject) ? idAsObject : null;
        if (idAsObject is not TId id)
        {
            await next();
            return;
        }

        var anyEntity = await genericRepository.AnyAsync(id);

        if (anyEntity)
        {

            await next();
            return;

        }
        var entityName = typeof(T).Name;
        var actionName = context.ActionDescriptor.RouteValues["action"];
        var result = ServiceResult.Fail($"{entityName} not found to {actionName}."); //Product not found to Update. 
        context.Result = new NotFoundObjectResult(result);

    }
}

