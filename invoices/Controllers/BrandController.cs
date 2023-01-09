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
    // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class BrandController : ControllerApi
    {
        public BrandController(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        { }

        [HttpGet]
        public async Task<ActionResult> Index(
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 15,
            [FromQuery] string search = null
        )
        {
            var query = context.brands.AsQueryable();
            if (search != null) {
                query = query.Where(x => x.Name.Contains(search));
            }
            return await SearchPaginate<Brand, BrandDto>(query, page, pageSize, search);
        }

        [HttpPost()]
        public async Task<ActionResult> Store(BrandCreateDto brand)
        {
            var info = await SaveStore<Brand, BrandCreateDto>(brand);
            return ResponseOk<BrandDto>(info, 201);
        }

        [HttpGet("{id}/show")]
        public async Task<ActionResult> Edit(int id)
        {
            var brand = await context.brands.FirstOrDefaultAsync(x => x.Id == id);
            if (brand == null)
                return NotFound();
            return ResponseOk<BrandDto>(brand);
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> Update(int id, BrandCreateDto brandDto)
        {
            var info = await SaveUpdate<Brand, BrandCreateDto>(id, brandDto);
            if (info == null)
                return NotFound();
            return ResponseOk<BrandDto>(info);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var info = await SaveDelete<Brand>(id);
            if (info == null)
                return NotFound();
            return ResponseOk<BrandDto>(info);
        }
    }
}
