using apis.Models;
using Microsoft.AspNetCore.Mvc;

namespace apis.Utils
{
    public class ResultError: ControllerBase
    {
            public ActionResult GetActionResult(HttpException ex)
            {
                var response = new ResponseError<string>(ex.StatusCode, ex.Error, ex.Detail);
                switch (ex.StatusCode)
                {
                    case 400:
                        return BadRequest(response);
                    case 401:
                        return Unauthorized(response);
                    case 403:
                        return Forbid();
                    case 404:
                        return NotFound(response);
                    case 409:
                        return Conflict(response);
                    case 500:
                        return StatusCode(500, response);
                    default:
                        return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }
        
    }
}
