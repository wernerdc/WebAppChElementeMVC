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
    public class GruppenController : Controller
    {
        private readonly WebAppChElementeMVCContext _context;

        public GruppenController(WebAppChElementeMVCContext context)
        {
            _context = context;
        }

        // GET: Gruppen
        public async Task<IActionResult> Index()
        {
            return View(await _context.Gruppe.ToListAsync());
        }

        // GET: Gruppen/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gruppe = await _context.Gruppe
                .Include(e => e.Elemente)
                .ThenInclude(p => p.Periode)
                .Include(e => e.Elemente)
                .ThenInclude(z => z.Zustand)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);
                if (gruppe == null)
            {
                return NotFound();
            }

            return View(gruppe);
        }

        // GET: Gruppen/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Gruppen/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nummer")] Gruppe gruppe)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gruppe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gruppe);
        }

        // GET: Gruppen/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gruppe = await _context.Gruppe.FindAsync(id);
            if (gruppe == null)
            {
                return NotFound();
            }
            return View(gruppe);
        }

        // POST: Gruppen/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nummer")] Gruppe gruppe)
        {
            if (id != gruppe.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gruppe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GruppeExists(gruppe.Id))
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
            return View(gruppe);
        }

        // GET: Gruppen/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gruppe = await _context.Gruppe
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gruppe == null)
            {
                return NotFound();
            }

            return View(gruppe);
        }

        // POST: Gruppen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gruppe = await _context.Gruppe.FindAsync(id);
            if (gruppe != null)
            {
                _context.Gruppe.Remove(gruppe);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GruppeExists(int id)
        {
            return _context.Gruppe.Any(e => e.Id == id);
        }
    }
}
