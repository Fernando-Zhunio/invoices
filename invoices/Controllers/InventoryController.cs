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
    [Route("api/inventories")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class InventoryController : ControllerApi
    {
       

        public InventoryController(ApplicationDbContext context, IMapper mapper): base(context, mapper)
        {
        }

        [HttpGet]
        public async Task<ActionResult> Index(
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 15,
            [FromQuery] string search = null
        )
        {
            var inventories = new Page<Inventory>();
            if (search != null)
            {
                inventories = await context.inventory
                    .Where(x => x.Sku.Name.Contains(search))
                    .PaginateAsync(page, pageSize);
            }
            else
            {
                inventories = await context.inventory.PaginateAsync(page, pageSize);
            }

            return ResponseOk<InventoryDto>(
                inventories
            );
        }

        [HttpPost]
        public async Task<ActionResult> Store(InventoryCreateDto inventory)
        {
            var _inventory = context.inventory.Add(mapper.Map<Inventory>(inventory));
            await context.SaveChangesAsync();
            return ResponseOk<InventoryDto>(_inventory);
        }

        [HttpGet("{id}/show")]
        public async Task<ActionResult> Edit(int id)
        {
            var inventory = await context.inventory.FirstOrDefaultAsync(x => x.Id == id);
            if (inventory == null)
                return NotFound();
            else
                return ResponseOk<InventoryDto>(inventory);
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> Update(int id, InventoryCreateDto inventoryDto)
        {
            var inventory = await context.inventory.FirstOrDefaultAsync(x => x.Id == id);
            if (inventory == null)
                return NotFound();

            inventory = mapper.Map(inventoryDto, inventory);
            context.inventory.Update(inventory);
            await context.SaveChangesAsync();
            return ResponseOk<InventoryDto>(inventory);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var inventory = await context.inventory.FirstOrDefaultAsync(x => x.Id == id);
            if (inventory == null)
                return NotFound();

            context.inventory.Remove(inventory);
            await context.SaveChangesAsync();
            return ResponseOk<InventoryDto>(inventory);
        }
    }
}
