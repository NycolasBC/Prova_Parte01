using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using WebApplicationList01.Configuration;

namespace WebApplicationList01.Controllers
{
    public class PrincipalController : ControllerBase
    {
        protected IActionResult ApiResponse<T>(T data, string message = null)
        {
            var response = new ApiResponse<T>
            {
                Success = true,
                Message = message,
                Data = data
            };

            return Ok(response);
        }

        protected IActionResult ApiBadRequestResponse(ModelStateDictionary modelState, string message = "Dados inválidos!")
        {
            var erros = modelState.Values.SelectMany(x => x.Errors);
            var response = new ApiResponse<object>
            {
                Success = true,
                Message = message,
                Data = erros.Select(n => n.ErrorMessage).ToArray()
            };

            return BadRequest(response);
        }
    }
}
