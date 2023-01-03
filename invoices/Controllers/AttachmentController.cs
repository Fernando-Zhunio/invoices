using AutoMapper;
using invoices.DTOs;
using invoices.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace invoices.Controllers
{
    [ApiController]
    [Route("api/attachments")]
    public class AttachmentController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public AttachmentController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> Index(
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 15,
            [FromQuery] string search = null
        )
        {
            var attachments = new List<Attachment>();
            if (search != null)
            {
                attachments = await context.attachments
                    .Where(x => x.Name.Contains(search))
                    .OrderBy(x => x.Id)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();
            }
            attachments = await context.attachments
                .OrderBy(x => x.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return Ok(mapper.Map<List<AttachmentDto>>(attachments));
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
