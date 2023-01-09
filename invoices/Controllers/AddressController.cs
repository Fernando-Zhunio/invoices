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
    [Route("api/clients/{clientId:int}/Addresses")]
    // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    public class AddressController : ControllerApi
    {
        public AddressController(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        [HttpGet]
        public async Task<ActionResult> Index(
            [FromRoute] int clientId,
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 15,
            [FromQuery] string search = null
        )
        {
            var addresses = new Page<AddressCreateDto>();
            var query = query.addresses
            .OrderBy(x => x.Id)
            .Where(x => x.ClientId == clientId)
            .Where(x => x.City.Contains(search));

            addresses = await Paginate<Address, AddressCreateDto>(query, page, pageSize);
            return ResponseCustom(addresses);
        }

        [HttpPost()]
        public async Task<ActionResult> Store(AddressCreateDto address)
        {
            var _address = contest.addresses.Add(mapper.Map<Address>(address));
            await contest.SaveChangesAsync();
            return ResponseMapper<AddressCreateDto>(_address);
        }

        [HttpGet("{id}/edit")]
        public async Task<ActionResult> Edit(int clientId, int id)
        {
            var address = await contest.addresses.FirstOrDefaultAsync(x => x.Id == id);
            if (address == null)
                return NotFound();
            else

                return Ok(mapper.Map<Address>(address));
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> Update(int clientId, int id, AddressCreateDto addressDto)
        {
            var address = await contest.addresses.FirstOrDefaultAsync(x => x.Id == id);
            if (address == null)
                return NotFound();

            address.City = address.City;
            address.Country = address.Country;
            address.State = address.State;
            address.Street = address.Street;
            address.ZipCode = address.ZipCode;

            await contest.SaveChangesAsync();
            return Ok(mapper.Map<Address>(address));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var sku = await contest.addresses.FirstOrDefaultAsync(x => x.Id == id);
            if (sku == null)
                return NotFound();

            contest.addresses.Remove(sku);
            await contest.SaveChangesAsync();
            return Ok(sku);
        }
    }
}
