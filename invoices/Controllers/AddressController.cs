using AutoMapper;
using invoices.DTOs;
using invoices.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace invoices.Controllers
{
    [ApiController]
    [Route("api/clients/{clientId:int}/Addresses")]
    public class AddressController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public AddressController(ApplicationDbContext context, IMapper mapper)
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
            var addresses = new List<Address>();
            if (search != null)
            {
                addresses = await context.addresses
                    .Where(x => x.City.Contains(search))
                    .OrderBy(x => x.Id)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();
            }
            addresses = await context.addresses
                .OrderBy(x => x.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return Ok(mapper.Map<List<AddressDto>>(addresses));
        }

        [HttpPost()]
        public async Task<ActionResult> Store(AddressCreateDto address)
        {
                context.addresses.Add(mapper.Map<Address>(address));
                await context.SaveChangesAsync();
                return Ok();
        }

        [HttpGet("{id}/edit")]
        public async Task<ActionResult> Edit(int clientId, int id)
        {
            var address = await context.addresses.FirstOrDefaultAsync(x => x.Id == id);
            if (address == null)
                return NotFound();
            else

                return Ok(mapper.Map<Address>(address));
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> Update(int clientId, int id, AddressCreateDto addressDto)
        {
            var address = await context.addresses.FirstOrDefaultAsync(x => x.Id == id);
            if (address == null)
                return NotFound();

            address.City = address.City;
            address.Country = address.Country;
            address.State = address.State;
            address.Street = address.Street;
            address.ZipCode = address.ZipCode;

            await context.SaveChangesAsync();
            return Ok(mapper.Map<Address>(address));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var sku = await context.addresses.FirstOrDefaultAsync(x => x.Id == id);
            if (sku == null)
                return NotFound();

            context.addresses.Remove(sku);
            await context.SaveChangesAsync();
            return Ok(sku);
        }
    }
}
