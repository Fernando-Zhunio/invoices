using AutoMapper;
using invoices.DTOs;
using invoices.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace invoices.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoryController: Controller
    {
         private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public CategoryController(ApplicationDbContext context, IMapper mapper)
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
            var categories = new List<Category>();
            if (search != null)
            {
                categories = await context.categories
                    .Where(x => x.Name.Contains(search))
                    .OrderBy(x => x.Id)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();
            }
            categories = await context.categories
                .OrderBy(x => x.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return Ok(mapper.Map<List<CategoryDto>>(categories));
        }

        [HttpPost()]
        public async Task<ActionResult> Store(CategoryCreateDto categoryDto)
        {
            context.categories.Add(mapper.Map<Category>(categoryDto));
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("{id}/show")]
        public async Task<ActionResult> Show(int id)
        {
            var category = await context.categories.FirstOrDefaultAsync(x => x.Id == id);
            if (category == null)
                return NotFound();
            else

                return Ok(mapper.Map<CategoryDto>(category));
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> Update(int id, CategoryCreateDto categoryDto)
        {
            var category = await context.categories.FirstOrDefaultAsync(x => x.Id == id);
            if (category == null)
                return NotFound();

            category = mapper.Map(categoryDto, category);
            context.categories.Update(category);
            await context.SaveChangesAsync();
            return Ok(mapper.Map<Category>(category));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var category = await context.categories.FirstOrDefaultAsync(x => x.Id == id);
            if (category == null)
                return NotFound();

            context.categories.Remove(category);
            await context.SaveChangesAsync();
            return Ok(category);
        }
    }
}