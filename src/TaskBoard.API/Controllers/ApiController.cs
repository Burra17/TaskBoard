using Microsoft.AspNetCore.Mvc;
using TaskBoard.Domain.Common;

namespace TaskBoard.API.Controllers;

public class ApiController : ControllerBase
{
    // Translates Result<T> into the appropriate HTTP response
    protected IActionResult HandleResult<T>(Result<T> result)
    {
        if (result.IsSuccess)
        {
            if (result.StatusCode == 204)
                return NoContent();

            return StatusCode(result.StatusCode, result.Value);
        }

        return StatusCode(result.StatusCode, new { error = result.Error });
    }
}
