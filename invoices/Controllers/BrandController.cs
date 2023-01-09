using AutoMapper;
using EntityFrameworkPaginateCore;
using invoices.DTOs;
using invoices.Models;
using invoices.Utils;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace invoices.Controllers
{
    [ApiController]
    [Route("api/brands")]
    public class BrandController : ControllerApi
    {
       

        public BrandController(ApplicationDbContext context, IMapper mapper): base(context, mapper)
        {
           
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> Index(
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 15,
            [FromQuery] string search = null
        )
        {
            var brands = new Page<Brand>();
            if (search != null)
            {
                brands = await contest.brands
                    .Where(x => x.Name.Contains(search))
                    // .OrderBy(x => x.Id)
                    // .Skip((page - 1) * pageSize)
                    // .Take(pageSize)
                    // .ToListAsync();
                    .PaginateAsync(page, pageSize);
            }
            else
            {
                brands = await contest.brands
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
            contest.brands.Add(mapper.Map<Brand>(brand));
            await contest.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("{id}/show")]
        public async Task<ActionResult> Edit(int id)
        {
            var brand = await contest.brands.FirstOrDefaultAsync(x => x.Id == id);
            if (brand == null)
                return NotFound();
            else

                return Ok(mapper.Map<BrandDto>(brand));
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> Update(int id, BrandCreateDto brandDto)
        {
            var brand = await contest.brands.FirstOrDefaultAsync(x => x.Id == id);
            if (brand == null)
                return NotFound();

            brand = mapper.Map(brandDto, brand);
            contest.brands.Update(brand);
            await contest.SaveChangesAsync();
            return Ok(mapper.Map<BrandDto>(brand));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var brand = await contest.brands.FirstOrDefaultAsync(x => x.Id == id);
            if (brand == null)
                return NotFound();

            contest.brands.Remove(brand);
            await contest.SaveChangesAsync();
            return Ok(brand);
        }
    }
}
