using AutoMapper;
using EntityFrameworkPaginateCore;
using invoices.DTOs;
using invoices.Models;
using invoices.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace invoices.Controllers
{
    [ApiController]
    [Route("api/brands")]
    public class BrandController : ControllerApi
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public BrandController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        [Authorize]
        // [Authorize(Roles = "Admin,Manager")]
        public async Task<ActionResult> Index(
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 15,
            [FromQuery] string search = null
        )
        {
            var brands = new Page<Brand>();
            if (search != null)
            {
                brands = await context.brands
                    .Where(x => x.Name.Contains(search))
                    // .OrderBy(x => x.Id)
                    // .Skip((page - 1) * pageSize)
                    // .Take(pageSize)
                    // .ToListAsync();
                    .PaginateAsync(page, pageSize);
            }
            else
            {
                brands = await context.brands
                // .OrderBy(x => x.Id)
                // .Skip((page - 1) * pageSize)
                // .Take(pageSize)
                .PaginateAsync(page, pageSize);
            }

            return ResponseOk(
                brands
            // mapper.Map<List<BrandDto>>(brands)
            );
        }

        [HttpPost()]
        public async Task<ActionResult> Store(BrandCreateDto brand)
        {
            context.brands.Add(mapper.Map<Brand>(brand));
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("{id}/show")]
        public async Task<ActionResult> Edit(int id)
        {
            var brand = await context.brands.FirstOrDefaultAsync(x => x.Id == id);
            if (brand == null)
                return NotFound();
            else

                return Ok(mapper.Map<Address>(brand));
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> Update(int id, BrandCreateDto brandDto)
        {
            var brand = await context.brands.FirstOrDefaultAsync(x => x.Id == id);
            if (brand == null)
                return NotFound();

            brand = mapper.Map(brandDto, brand);
            context.brands.Update(brand);
            await context.SaveChangesAsync();
            return Ok(mapper.Map<Brand>(brand));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var brand = await context.brands.FirstOrDefaultAsync(x => x.Id == id);
            if (brand == null)
                return NotFound();

            context.brands.Remove(brand);
            await context.SaveChangesAsync();
            return Ok(brand);
        }
    }
}