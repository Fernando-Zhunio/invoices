using AutoMapper;
using invoices.DTOs;
using invoices.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace invoices.Controllers
{
    [ApiController]
    [Route("api/clients")]
    public class ClientController: Controller
    {
          private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public ClientController(ApplicationDbContext context, IMapper mapper)
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
            var clients = new List<Client>();
            if (search != null)
            {
                clients = await context.clients
                    .Where(x => x.FirstName.Contains(search))
                    .OrderBy(x => x.Id)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();
            }
            clients = await context.clients
                .OrderBy(x => x.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return Ok(mapper.Map<List<ClientDto>>(clients));
        }

        [HttpPost]
        public async Task<ActionResult> Store(ClientCreateDto clientDto)
        {
            context.clients.Add(mapper.Map<Client>(clientDto));
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("{id}/show")]
        public async Task<ActionResult<ClientDto>> Show(int id)
        {
            var client = await context.clients.FirstOrDefaultAsync(x => x.Id == id);
            if (client == null)
                return NotFound();
            else

                return Ok(mapper.Map<ClientDto>(client));
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<ClientDto>> Update(int id, ClientCreateDto clientDto)
        {
            var client = await context.clients.FirstOrDefaultAsync(x => x.Id == id);
            if (client == null)
                return NotFound();

            client = mapper.Map(clientDto, client);
            context.clients.Update(client);
            await context.SaveChangesAsync();
            return Ok(mapper.Map<ClientDto>(client));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var client = await context.clients.FirstOrDefaultAsync(x => x.Id == id);
            if (client == null)
                return NotFound();

            context.clients.Remove(client);
            await context.SaveChangesAsync();
            return Ok(client);
        }
    }
}