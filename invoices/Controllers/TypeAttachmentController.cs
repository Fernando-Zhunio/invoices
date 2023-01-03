using AutoMapper;
using invoices.DTOs;
using invoices.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace invoices.Controllers
{
    [ApiController]
    [Route("api/type-attachments")]
    public class TypeAttachmentController: Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public TypeAttachmentController(ApplicationDbContext context, IMapper mapper)
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
            var typeAttachment = new List<TypeAttachment>();
            if (search != null)
            {
                typeAttachment = await context.typeAttachments
                    .Where(x => x.Name.Contains(search))
                    .OrderBy(x => x.Id)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();
            }
            typeAttachment = await context.typeAttachments
                .OrderBy(x => x.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return Ok(mapper.Map<List<TypeAttachmentDto>>(typeAttachment));
        }

        [HttpPost()]
        public async Task<ActionResult> Store(TypeAttachmentCreateDto typeAttachment)
        {
            context.typeAttachments.Add(mapper.Map<TypeAttachment>(typeAttachment));
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("{id}/show")]
        public async Task<ActionResult> Show(int id)
        {
            var typeAttachment = await context.typeAttachments.FirstOrDefaultAsync(x => x.Id == id);
            if (typeAttachment == null)
                return NotFound();
            else

                return Ok(mapper.Map<TypeAttachmentDto>(typeAttachment));
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> Update(int id, TypeAttachmentCreateDto typeAttachmentDto)
        {
            var typeAttachment = await context.typeAttachments.FirstOrDefaultAsync(x => x.Id == id);
            if (typeAttachment == null)
                return NotFound();

            typeAttachment = mapper.Map(typeAttachmentDto, typeAttachment);
            context.typeAttachments.Update(typeAttachment);
            await context.SaveChangesAsync();
            return Ok(mapper.Map<TypeAttachmentDto>(typeAttachment));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var typeAttachment = await context.typeAttachments.FirstOrDefaultAsync(x => x.Id == id);
            if (typeAttachment == null)
                return NotFound();

            context.typeAttachments.Remove(typeAttachment);
            await context.SaveChangesAsync();
            return Ok(mapper.Map<TypeAttachmentDto>(typeAttachment));
        }
    }
}