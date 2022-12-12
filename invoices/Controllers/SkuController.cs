using invoices.Helper;
using invoices.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace invoices.Controllers
{
    [ApiController]
    [Route("sku")]
    public class SkuController : Controller
    {
        private readonly ApplicationDbContext _context;
        public SkuController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SkuController
        public async Task<ActionResult> Index()
        {
            var skus =  _context.sku.GetAsyncEnumerator();
            return Ok(skus);
        }

        // GET: SkuController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SkuController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SkuController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Sku sku)
        {
            try
            {
               await _context.sku.AddAsync(sku);
                return Ok();
            }
            catch
            {
                return View();
            }
        }

        // GET: SkuController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SkuController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SkuController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SkuController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
