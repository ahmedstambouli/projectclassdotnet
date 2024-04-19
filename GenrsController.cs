using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using seance2.Models;

namespace seance2
{
    public class GenrsController : Controller
    {
        private readonly AppDbContext _context;

        public GenrsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Genrs
        public async Task<IActionResult> Index()
        {
              return _context.Geners != null ? 
                          View(await _context.Geners.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.Geners'  is null.");
        }

        // GET: Genrs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Geners == null)
            {
                return NotFound();
            }

            var geners = await _context.Geners
                .FirstOrDefaultAsync(m => m.Id == id);
            if (geners == null)
            {
                return NotFound();
            }

            return View(geners);
        }

        // GET: Genrs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Genrs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,GenerName")] Geners geners)
        {
            if (ModelState.IsValid)
            {
                _context.Add(geners);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(geners);
        }

        // GET: Genrs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Geners == null)
            {
                return NotFound();
            }

            var geners = await _context.Geners.FindAsync(id);
            if (geners == null)
            {
                return NotFound();
            }
            return View(geners);
        }

        // POST: Genrs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,GenerName")] Geners geners)
        {
            if (id != geners.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(geners);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GenersExists(geners.Id))
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
            return View(geners);
        }

        // GET: Genrs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Geners == null)
            {
                return NotFound();
            }

            var geners = await _context.Geners
                .FirstOrDefaultAsync(m => m.Id == id);
            if (geners == null)
            {
                return NotFound();
            }

            return View(geners);
        }

        // POST: Genrs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Geners == null)
            {
                return Problem("Entity set 'AppDbContext.Geners'  is null.");
            }
            var geners = await _context.Geners.FindAsync(id);
            if (geners != null)
            {
                _context.Geners.Remove(geners);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GenersExists(int id)
        {
          return (_context.Geners?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
