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
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class AddressController : ControllerApi
    {
        public AddressController(ApplicationDbContext context, IMapper mapper)
            : base(context, mapper) { }

        [HttpGet]
        public async Task<ActionResult> Index(
            [FromRoute] int clientId,
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 15,
            [FromQuery] string search = null
        )
        {
            var query = context.addresses.OrderBy(x => x.Id).Where(x => x.ClientId == clientId);
            if (search != null)
            {
                query = query.Where(x => x.City.Contains(search));
            }
            return await SearchPaginate<Address, AddressDto>(query, page, pageSize, search);
        }

        [HttpPost()]
        public async Task<ActionResult> Store(int clientId, AddressCreateDto addressDto)
        {
            var client = await context.clients.FirstOrDefaultAsync(x => x.Id == clientId);
            if (client == null)
                return NotFound("Client not found");
            addressDto.ClientId = clientId;
            var info = await SaveStore<Address, AddressCreateDto>(addressDto);
            return ResponseOk<AddressCreateDto>(info, 201);
        }

        [HttpGet("{id}/edit")]
        public async Task<ActionResult> Edit(int clientId, int id)
        {
            var address = await context.addresses.FirstOrDefaultAsync(x => x.Id == id);
            if (address == null)
                return NotFound();
            return ResponseOk<AddressDto>(address);
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> Update(int clientId, int id, AddressCreateDto addressDto)
        {
            var client = await context.clients.FirstOrDefaultAsync(x => x.Id == id);
            if (client == null)
                return NotFound("Client not found");
            addressDto.ClientId = clientId;
            var info = await SaveUpdate<Address, AddressCreateDto>(id, addressDto);
            if (info == null)
                return NotFound("Address not found");
            return ResponseOk<AddressDto>(info);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Delete(int clientId, int id)
        {
            var client = await context.clients.FirstOrDefaultAsync(x => x.Id == clientId);
            if (client == null)
                return NotFound("Client not found");
            var info = await SaveDelete<Address>(id);
            if (info == null)
                return NotFound();
            await context.SaveChangesAsync();
            return ResponseOk<AddressDto>(info);
        }
    }
}
