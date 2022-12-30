using AutoMapper;
using invoices.DTOs;
using invoices.Helper;
using invoices.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace invoices.Controllers
{
    [ApiController]
    [Route("api/sku")]
    public class SkuController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public SkuController(ApplicationDbContext context, IMapper mapper)
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
            var skus = new List<Sku>();
            if (search != null)
            {
                skus = await context.sku
                    .Where(x => x.Name.Contains(search))
                    .OrderBy(x => x.Id)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();
            }
            skus = await context.sku
                .OrderBy(x => x.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return Ok(mapper.Map<List<SkuDto>>(skus));
        }

        // GET: SkuController/Details/5
        [HttpGet("{id}/show")]
        public async Task<ActionResult> Details(int id)
        {
            var sku = await context.sku.FirstOrDefaultAsync(x => x.Id == id);
            if (sku == null)
                return NotFound();
            else
                return Ok(mapper.Map<SkuDto>(sku));
        }

        //    // GET: SkuController/Create
        //    [HttpGet]
        //    public ActionResult Create()
        //    {
        //        return View();
        //    }

        // POST: SkuController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Sku sku)
        {
            try
            {
                context.sku.Add(sku);
                await context.SaveChangesAsync();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        // GET: SkuController/Edit/5
        [HttpGet("{id}/edit")]
        public async Task<ActionResult> Edit(int id)
        {
            var sku = await context.sku.FirstOrDefaultAsync(x => x.Id == id);
            if (sku == null)
                return NotFound();
            else
                return Ok(sku);
        }

        //    // POST: SkuController/Edit/5
        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public ActionResult Edit(int id, IFormCollection collection)
        //    {
        //        try
        //        {
        //            return RedirectToAction(nameof(Index));
        //        }
        //        catch
        //        {
        //            return View();
        //        }
        //    }

        // GET: SkuController/Delete/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var sku = await context.sku.FirstOrDefaultAsync(x => x.Id == id);
            if (sku == null)
                return NotFound();
            else
                return Ok(sku);
        }

        //    // POST: SkuController/Delete/5
        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public ActionResult Delete(int id, IFormCollection collection)
        //    {
        //        try
        //        {
        //            return RedirectToAction(nameof(Index));
        //        }
        //        catch
        //        {
        //            return View();
        //        }
        //    }
    }
}
