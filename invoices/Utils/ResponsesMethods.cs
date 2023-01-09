using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace invoices.Utils
{
    public class ResponsesMethods: ControllerBase
    {
        protected readonly IMapper mapper;
        public ResponsesMethods(IMapper mapper)
        {
            this.mapper = mapper;
        }
        [NonAction]
        public ActionResult ResponseOk<T>(object data = null)
        {
            return Ok(new { success = true, data = mapper.Map<T>(data) });
        }
        [NonAction]
         public ActionResult ResponseMapper<T>(object data = null)
        {
            return Ok(new { success = true, data = mapper.Map<T>(data) });
        }

          [NonAction]
        public ActionResult ResponseCustom(object data = null, int statusCode = 200, bool success = true)
        {
            return StatusCode(statusCode, new { success, data });
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