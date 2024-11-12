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
    public class ZustaendeController : Controller
    {
        private readonly WebAppChElementeMVCContext _context;

        public ZustaendeController(WebAppChElementeMVCContext context)
        {
            _context = context;
        }

        // GET: Zustaende
        public async Task<IActionResult> Index()
        {
            return View(await _context.Zustand.ToListAsync());
        }

        // GET: Zustaende/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zustand = await _context.Zustand
                .FirstOrDefaultAsync(m => m.Id == id);
            if (zustand == null)
            {
                return NotFound();
            }

            return View(zustand);
        }

        // GET: Zustaende/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Zustaende/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Bezeichnung")] Zustand zustand)
        {
            if (ModelState.IsValid)
            {
                _context.Add(zustand);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(zustand);
        }

        // GET: Zustaende/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zustand = await _context.Zustand.FindAsync(id);
            if (zustand == null)
            {
                return NotFound();
            }
            return View(zustand);
        }

        // POST: Zustaende/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Bezeichnung")] Zustand zustand)
        {
            if (id != zustand.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zustand);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZustandExists(zustand.Id))
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
            return View(zustand);
        }

        // GET: Zustaende/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zustand = await _context.Zustand
                .FirstOrDefaultAsync(m => m.Id == id);
            if (zustand == null)
            {
                return NotFound();
            }

            return View(zustand);
        }

        // POST: Zustaende/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var zustand = await _context.Zustand.FindAsync(id);
            if (zustand != null)
            {
                _context.Zustand.Remove(zustand);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZustandExists(int id)
        {
            return _context.Zustand.Any(e => e.Id == id);
        }
    }
}
