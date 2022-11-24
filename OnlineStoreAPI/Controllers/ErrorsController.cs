using Microsoft.AspNetCore.Mvc;
using OnlineStoreAPI.Errors;

namespace OnlineStoreAPI.Controllers
{
    [Route("errors/{code}")]
    public class ErrorsController : BaseController
    {
        [NonAction]
        public IActionResult Error(int code)
        {
            return new ObjectResult(new ApiResponse(code));
        }

    }
}

