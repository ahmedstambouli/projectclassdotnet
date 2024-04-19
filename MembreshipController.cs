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
    public class MembreshipController : Controller
    {
        private readonly AppDbContext _context;

        public MembreshipController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Membreship
        public async Task<IActionResult> Index()
        {
              return _context.memberShipts != null ? 
                          View(await _context.memberShipts.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.memberShipts'  is null.");
        }

        // GET: Membreship/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.memberShipts == null)
            {
                return NotFound();
            }

            var memberShipt = await _context.memberShipts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (memberShipt == null)
            {
                return NotFound();
            }

            return View(memberShipt);
        }

        // GET: Membreship/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Membreship/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SignUpFree,DurationInMonth,DiscountRate")] MemberShipt memberShipt)
        {
            if (ModelState.IsValid)
            {
                _context.Add(memberShipt);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(memberShipt);
        }

        // GET: Membreship/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.memberShipts == null)
            {
                return NotFound();
            }

            var memberShipt = await _context.memberShipts.FindAsync(id);
            if (memberShipt == null)
            {
                return NotFound();
            }
            return View(memberShipt);
        }

        // POST: Membreship/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SignUpFree,DurationInMonth,DiscountRate")] MemberShipt memberShipt)
        {
            if (id != memberShipt.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(memberShipt);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MemberShiptExists(memberShipt.Id))
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
            return View(memberShipt);
        }

        // GET: Membreship/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.memberShipts == null)
            {
                return NotFound();
            }

            var memberShipt = await _context.memberShipts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (memberShipt == null)
            {
                return NotFound();
            }

            return View(memberShipt);
        }

        // POST: Membreship/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.memberShipts == null)
            {
                return Problem("Entity set 'AppDbContext.memberShipts'  is null.");
            }
            var memberShipt = await _context.memberShipts.FindAsync(id);
            if (memberShipt != null)
            {
                _context.memberShipts.Remove(memberShipt);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MemberShiptExists(int id)
        {
          return (_context.memberShipts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
