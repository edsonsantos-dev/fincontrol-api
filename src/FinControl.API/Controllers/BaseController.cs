using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace FinControl.API.Controllers;

[ApiController]
public abstract class BaseController : ControllerBase
{
    protected bool IsValid()
    {
        return true;
    }

    protected IActionResult CustomResponse(object result = null)
    {
        if (IsValid())
            return new ObjectResult(result);

        return BadRequest(new
        {
            //TODO: Retornar os erros
        });
    }

    protected IActionResult CustomResponse(ModelStateDictionary modelState)
    {
        if (!modelState.IsValid) {} //TODO: Notificar erros

        return CustomResponse();
    }
}