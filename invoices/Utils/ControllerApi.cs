using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace invoices.Utils
{
    public class ControllerApi : ControllerBase
    {
        [NonAction]
        public ActionResult ResponseOk(object data = null)
        {
            return Ok(new { success = true, data });
        }
        [NonAction]
        public BadRequestObjectResult ResponseBadRequest(object data = null)
        {
            return BadRequest(new { success = false, data });
        }

        [NonAction]
        public NotFoundObjectResult ResponseNotFound(object data = null)
        {
            return NotFound(new { success = false, data });
        }
    }
}
