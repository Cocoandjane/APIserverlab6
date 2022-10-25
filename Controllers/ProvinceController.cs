using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CodeFirst.Models;
using codeFirst.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;

namespace codeFirst.Controllers
{
    [Route("api/[controller]")]
    //   [Route("/")]
    [ApiController]
    [EnableCors("APIPolicy")]
    public class ProvinceController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProvinceController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet("GetProvinces")]
        public async Task<ActionResult<IEnumerable<Province>>> GetProvinces()
        {
            if (_context.Provinces == null)
            {
                return NotFound();
            }
            return await _context.Provinces
            .ToListAsync();
        }
        
        // GET: Province
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return _context.Provinces != null ?
                        View(await _context.Provinces.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.Provinces'  is null.");
        }

        // GET: Province/Details/5
        [HttpGet("Details/{id}")]
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Provinces == null)
            {
                return NotFound();
            }

            var province = await _context.Provinces
                .FirstOrDefaultAsync(m => m.ProvinceCode == id);
            if (province == null)
            {
                return NotFound();
            }

            return View(province);
        }

        // GET: Province/Create
        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Province/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProvinceCode,ProvinceName")] Province province)
        {
            if (_context.Provinces == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Provinces'  is null.");
            }


            Console.Write("ProvinceCode: " + province.ProvinceCode);
            _context.Add(province);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

            return View(province);
        }

        // GET: Province/Edit/5
        [HttpGet("Edit/{id}")]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Provinces == null)
            {
                return NotFound();
            }

            var province = await _context.Provinces.FindAsync(id);
            if (province == null)
            {
                return NotFound();
            }
            return View(province);
        }

        // POST: Province/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ProvinceCode,ProvinceName")] Province province)
        {
            if (id != province.ProvinceCode)
            {
                return NotFound();
            }


            try
            {
                _context.Update(province);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProvinceExists(province.ProvinceCode))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }


            return View(province);
        }

        // GET: Province/Delete/5
        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Provinces == null)
            {
                return NotFound();
            }

            var province = await _context.Provinces
                .FirstOrDefaultAsync(m => m.ProvinceCode == id);
            if (province == null)
            {
                return NotFound();
            }

            return View(province);
        }

        // POST: Province/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Provinces == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Provinces'  is null.");
            }
            var province = await _context.Provinces.FindAsync(id);
            if (province != null)
            {
                _context.Provinces.Remove(province);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProvinceExists(string id)
        {
            return (_context.Provinces?.Any(e => e.ProvinceCode == id)).GetValueOrDefault();
        }
    }
}
