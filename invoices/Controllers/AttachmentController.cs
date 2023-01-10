using AutoMapper;
using EntityFrameworkPaginateCore;
using invoices.DTOs;
using invoices.Models;
using invoices.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace invoices.Controllers
{
    [ApiController]
    [Route("api/attachments")]
    public class AttachmentController : ControllerApi
    {
        public AttachmentController(ApplicationDbContext context, IMapper mapper)
            : base(context, mapper) { }

        [HttpGet]
        public async Task<ActionResult> Index(
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 15,
            [FromQuery] string search = null
        )
        {
            var query = context.attachments.OrderBy(x => x.Id).AsQueryable();
            if (search != null)
            {
                query = query.Where(x => x.Name.Contains(search));
            }
            return await SearchPaginate<Attachment, AttachmentDto>(query, page, pageSize, search);
        }

        [HttpPost]
        public async Task<ActionResult> Store(AttachmentCreateDto attachment)
        {
            context.attachments.Add(mapper.Map<Attachment>(attachment));
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("{id}/show")]
        public async Task<ActionResult> Show(int id)
        {
            var attachments = await context.attachments.FirstOrDefaultAsync(x => x.Id == id);
            if (attachments == null)
                return NotFound();
            else

                return Ok(mapper.Map<Attachment>(attachments));
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> Update(int id, AttachmentCreateDto attachmentDto)
        {
            var attachment = await context.attachments.FirstOrDefaultAsync(x => x.Id == id);
            if (attachment == null)
                return NotFound();

            attachment = mapper.Map(attachmentDto, attachment);
            context.attachments.Update(attachment);
            await context.SaveChangesAsync();
            return Ok(mapper.Map<Attachment>(attachment));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var attachments = await context.attachments.FirstOrDefaultAsync(x => x.Id == id);
            if (attachments == null)
                return NotFound();

            context.attachments.Remove(attachments);
            await context.SaveChangesAsync();
            return Ok(attachments);
        }
    }
}
