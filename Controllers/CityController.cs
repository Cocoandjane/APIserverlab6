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
    public class CityController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CityController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("GetCities")]
        public async Task<ActionResult<IEnumerable<City>>> GetCities()
        {
            if (_context.cities == null)
            {
                return NotFound();
            }
            return await _context.cities
            .ToListAsync();
        }

        // GET: City
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.cities.Include(c => c.Province);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: City/Details/5
        [HttpGet("Details/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.cities == null)
            {
                return NotFound();
            }

            var city = await _context.cities
                .Include(c => c.Province)
                .FirstOrDefaultAsync(m => m.CityId == id);
            if (city == null)
            {
                return NotFound();
            }

            return View(city);
        }

        // GET: City/Create
        [HttpGet("Create")]
        public IActionResult Create()
        {
            ViewData["ProvinceCode"] = new SelectList(_context.Provinces, "ProvinceCode", "ProvinceCode");
            return View();
        }

        // POST: City/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CityId,CityName,Population,ProvinceCode")] City city)
        {
            
            _context.Add(city);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

            // ViewData["ProvinceCode"] = new SelectList(_context.Provinces, "ProvinceCode", "ProvinceCode", city.ProvinceCode);
            // return View(city);
        }

        // GET: City/Edit/5
        [HttpGet("Edit/{id}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.cities == null)
            {
                return NotFound();
            }

            var city = await _context.cities.FindAsync(id);
            if (city == null)
            {
                return NotFound();
            }
            ViewData["ProvinceCode"] = new SelectList(_context.Provinces, "ProvinceCode", "ProvinceCode", city.ProvinceCode);
            return View(city);
        }

        // POST: City/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CityId,CityName,Population,ProvinceCode")] City city)
        {
            if (id != city.CityId)
            {
                return NotFound();
            }


            try
            {
                _context.Update(city);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CityExists(city.CityId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }

            }
            ViewData["ProvinceCode"] = new SelectList(_context.Provinces, "ProvinceCode", "ProvinceCode", city.ProvinceCode);
            return View(city);
        }

        // GET: City/Delete/5
        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.cities == null)
            {
                return NotFound();
            }

            var city = await _context.cities
                .Include(c => c.Province)
                .FirstOrDefaultAsync(m => m.CityId == id);
            if (city == null)
            {
                return NotFound();
            }

            return View(city);
        }

        // POST: City/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.cities == null)
            {
                return Problem("Entity set 'ApplicationDbContext.cities'  is null.");
            }
            var city = await _context.cities.FindAsync(id);
            if (city != null)
            {
                _context.cities.Remove(city);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CityExists(int id)
        {
            return (_context.cities?.Any(e => e.CityId == id)).GetValueOrDefault();
        }
    }
}
