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
        private readonly ApplicationDbContext _context;
        public SkuController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SkuController
        [HttpGet]
        public async Task<ActionResult> Index([FromQuery] int page = 1, [FromQuery] int pageSize = 15)
        {
            var skus = await _context.sku.OrderBy(x => x.Id).Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
            return Ok(skus);
        }

        // GET: SkuController/Details/5
        [HttpGet("{id}/show")]
        public async Task<ActionResult> Details(int id)
        {
            var sku = await _context.sku.FirstOrDefaultAsync(x => x.Id == id);
            if (sku == null)
                return NotFound();
            else
                return Ok(sku);
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
                _context.sku.Add(sku);
                await _context.SaveChangesAsync();
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
            var sku = await _context.sku.FirstOrDefaultAsync(x => x.Id == id);
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
            var sku = await _context.sku.FirstOrDefaultAsync(x => x.Id == id);
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
