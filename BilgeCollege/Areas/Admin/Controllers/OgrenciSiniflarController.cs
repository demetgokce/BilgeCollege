using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BilgeCollege.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class OgrenciSiniflarController : Controller
    {
        private readonly BilgeDbContext _context;

        public OgrenciSiniflarController(BilgeDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var bilgeDbContext = _context.OgrenciSiniflar.Include(f => f.Siniflar).Include(f => f.Ogrenci);
            return View(await bilgeDbContext.ToListAsync());
        }


        public IActionResult Create()
        {
            ViewData["OgrenciId"] = new SelectList(_context.Siniflar, "SiniflarId", "SiniflarId");
            ViewData["SiniflarId"] = new SelectList(_context.Ogrenciler, "OgrenciId", "OgrenciId");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SiniflarId,OgrenciId")] OgrenciSiniflar ogrencisiniflar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ogrencisiniflar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OgrenciId"] = new SelectList(_context.Siniflar, "SiniflarId", "SiniflarId", ogrencisiniflar.OgrenciId);
            ViewData["SiniflarId"] = new SelectList(_context.Ogrenciler, "OgrenciId", "OgrenciId", ogrencisiniflar.SiniflarId);
            return View(ogrencisiniflar);
        }
        private bool OgrenciSiniflarExists(int id)
        {
            return _context.OgrenciSiniflar.Any(e => e.SiniflarId == id);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ogrencisiniflar = await _context.OgrenciSiniflar
                .Include(f => f.Ogrenci)
                .Include(f => f.Siniflar)
                .FirstOrDefaultAsync(m => m.OgrenciId == id);
            if (ogrencisiniflar == null)
            {
                return NotFound();
            }

            return View(ogrencisiniflar);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ogrencisiniflar = await _context.OgrenciSiniflar.FindAsync(id);
            _context.OgrenciSiniflar.Remove(ogrencisiniflar);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ogrencisiniflar = await _context.OgrenciSiniflar.FindAsync(id);
            if (ogrencisiniflar == null)
            {
                return NotFound();
            }
            ViewData["SiniflarId"] = new SelectList(_context.Ogrenciler, "OgrenciId", "OgrenciId", ogrencisiniflar.SiniflarId);
            ViewData["OgrenciId"] = new SelectList(_context.Siniflar, "SiniflarId", "SiniflarId", ogrencisiniflar.OgrenciId);
            return View(ogrencisiniflar);

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, [Bind("OgrenciId,SiniflarId")] OgrenciSiniflar ogrencisiniflar)
        {
            if (id != ogrencisiniflar.OgrenciId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ogrencisiniflar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OgrenciSiniflarExists(ogrencisiniflar.SiniflarId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["SiniflarId"] = new SelectList(_context.Ogrenciler, "OgrenciId", "OgrenciId", ogrencisiniflar.SiniflarId);
            ViewData["OgrenciId"] = new SelectList(_context.Siniflar, "SiniflarId", "SiniflarId", ogrencisiniflar.OgrenciId);
            return View(ogrencisiniflar);

        }
    }
}
