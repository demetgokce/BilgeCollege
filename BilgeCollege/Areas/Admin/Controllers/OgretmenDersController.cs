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
    public class OgretmenDersController : Controller
    {
        private readonly BilgeDbContext _context;

        public OgretmenDersController(BilgeDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var bilgeDbContext = _context.OgretmenDers.Include(f => f.Ogretmen).Include(f => f.Ders);
            return View(await bilgeDbContext.ToListAsync());
        }
        public IActionResult Create()
        {
            ViewData["OgretmenId"] = new SelectList(_context.Ders, "DersId", "DersId");
            ViewData["DersId"] = new SelectList(_context.Ogretmenler, "OgretmenId", "OgretmenId");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DersId,OgretmenId")] OgretmenDers ogretmenders)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ogretmenders);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OgretmenId"] = new SelectList(_context.Ders, "DersId", "DersId", ogretmenders.OgretmenId);
            ViewData["DersId"] = new SelectList(_context.Ogretmenler, "OgretmenId", "OgretmenId", ogretmenders.DersId);
         
            return View(ogretmenders);
          
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ogretmenders= await _context.OgretmenDers.FindAsync(id);
            if (ogretmenders == null)
            {
                return NotFound();
            }
            ViewData["DersId"] = new SelectList(_context.Ogretmenler, "OgretmenId", "OgretmenId", ogretmenders.DersId);
            ViewData["OgretmenId"] = new SelectList(_context.Ders, "DersId", "DersId", ogretmenders.OgretmenId);
            return View(ogretmenders);
            
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, [Bind("OgretmenId,DersId")] OgretmenDers ogretmenders)
        {
            if (id != ogretmenders.OgretmenId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ogretmenders);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OgretmenDersExists(ogretmenders.DersId))
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
            ViewData["DersId"] = new SelectList(_context.Ogretmenler, "OgretmenId", "OgretmenId", ogretmenders.DersId);
            ViewData["OgretmenId"] = new SelectList(_context.Ders, "DersId", "DersId", ogretmenders.DersId);
            return View(ogretmenders);
           
        }
        private bool OgretmenDersExists(int id)
        {
            return _context.OgretmenDers.Any(e => e.DersId == id);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ogretmenders= await _context.OgretmenDers
                .Include(f => f.Ders)
                .Include(f => f.Ogretmen)
                .FirstOrDefaultAsync(m => m.OgretmenId == id);
            if (ogretmenders == null)
            {
                return NotFound();
            }

            return View(ogretmenders);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ogretmenders = await _context.OgretmenDers.FindAsync(id);
            _context.OgretmenDers.Remove(ogretmenders);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
