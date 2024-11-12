using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAppChElementeMVC.Data;
using WebAppChElementeMVC.Models;

namespace WebAppChElementeMVC.Controllers
{
    public class PeriodenController : Controller
    {
        private readonly WebAppChElementeMVCContext _context;

        public PeriodenController(WebAppChElementeMVCContext context)
        {
            _context = context;
        }

        // GET: Perioden
        public async Task<IActionResult> Index()
        {

            return View(await _context.Periode.ToListAsync());
        }

        // GET: Perioden/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var periode = await _context.Periode
                .Include(e => e.Elemente)
                .ThenInclude(p => p.Gruppe)
                .Include(e => e.Elemente)
                .ThenInclude(z => z.Zustand)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);
            if (periode == null)
            {
                return NotFound();
            }
            //periode.SetName();

            return View(periode);
        }

        // GET: Perioden/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Perioden/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nummer,Name")] Periode periode)
        {
            periode.SetName();

            if (ModelState.IsValid)
            {
                _context.Add(periode);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(periode);
        }

        // GET: Perioden/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var periode = await _context.Periode.FindAsync(id);
            if (periode == null)
            {
                return NotFound();
            }
            return View(periode);
        }

        // POST: Perioden/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nummer,Name")] Periode periode)
        {
            if (id != periode.Id)
            {
                return NotFound();
            }

            periode.SetName();
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(periode);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PeriodeExists(periode.Id))
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
            return View(periode);
        }

        // GET: Perioden/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var periode = await _context.Periode
                .FirstOrDefaultAsync(m => m.Id == id);
            if (periode == null)
            {
                return NotFound();
            }

            return View(periode);
        }

        // POST: Perioden/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var periode = await _context.Periode.FindAsync(id);
            if (periode != null)
            {
                _context.Periode.Remove(periode);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PeriodeExists(int id)
        {
            return _context.Periode.Any(e => e.Id == id);
        }
    }
}
