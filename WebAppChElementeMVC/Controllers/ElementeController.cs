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
    public class ElementeController : Controller
    {
        private readonly WebAppChElementeMVCContext _context;

        public ElementeController(WebAppChElementeMVCContext context)
        {
            _context = context;
        }

        // GET: Elemente
        public async Task<IActionResult> Index()
        {
            var webAppChElementeMVCContext = _context.Element.Include(e => e.Gruppe).Include(e => e.Periode).Include(e => e.Zustand);
            return View(await webAppChElementeMVCContext.ToListAsync());
        }

        // GET: Elemente/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var element = await _context.Element
                .Include(e => e.Gruppe)
                .Include(e => e.Periode)
                .Include(e => e.Zustand)

                .FirstOrDefaultAsync(m => m.Id == id);
            if (element == null)
            {
                return NotFound();
            }

            return View(element);
        }

        // GET: Elemente/Create
        public IActionResult Create()
        {
            ViewData["GruppeId"] = new SelectList(_context.Set<Gruppe>(), "Id", "Nummer");
            ViewData["PeriodeId"] = new SelectList(_context.Set<Periode>(), "Id", "Nummer");
            ViewData["ZustandId"] = new SelectList(_context.Set<Zustand>(), "Id", "Bezeichnung");
            return View();
        }

        // POST: Elemente/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GruppeId,PeriodeId,ZustandId,Ordnungszahl,Symbol,Name")] Element element)
        {
            if (ModelState.IsValid)
            {
                _context.Add(element);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GruppeId"] = new SelectList(_context.Set<Gruppe>(), "Id", "Nummer", element.GruppeId);
            ViewData["PeriodeId"] = new SelectList(_context.Set<Periode>(), "Id", "Nummer", element.PeriodeId);
            ViewData["ZustandId"] = new SelectList(_context.Set<Zustand>(), "Id", "Bezeichnung", element.ZustandId);
            return View(element);
        }

        // GET: Elemente/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var element = await _context.Element
                .Include(e => e.Gruppe)
                .Include(e => e.Periode)
                .Include(e => e.Zustand)

                .FirstOrDefaultAsync(m => m.Id == id);
            //var element = await _context.Element.FindAsync(id);
            if (element == null)
            {
                return NotFound();
            }
            ViewData["GruppeId"] = new SelectList(_context.Set<Gruppe>(), "Id", "Id", element.GruppeId);
            ViewData["PeriodeId"] = new SelectList(_context.Set<Periode>(), "Id", "Id", element.PeriodeId);
            ViewData["ZustandId"] = new SelectList(_context.Set<Zustand>(), "Id", "Id", element.ZustandId);
            return View(element);
        }

        // POST: Elemente/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GruppeId,PeriodeId,ZustandId,Ordnungszahl,Symbol,Name")] Element element)
        {
            if (id != element.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(element);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ElementExists(element.Id))
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
            ViewData["GruppeId"] = new SelectList(_context.Set<Gruppe>(), "Id", "Nummer", element.GruppeId);
            ViewData["PeriodeId"] = new SelectList(_context.Set<Periode>(), "Id", "Nummer", element.PeriodeId);
            ViewData["ZustandId"] = new SelectList(_context.Set<Zustand>(), "Id", "Bezeichnung", element.ZustandId);
            return View(element);
        }

        // GET: Elemente/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var element = await _context.Element
                .Include(e => e.Gruppe)
                .Include(e => e.Periode)
                .Include(e => e.Zustand)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (element == null)
            {
                return NotFound();
            }

            return View(element);
        }

        // POST: Elemente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var element = await _context.Element.FindAsync(id);
            if (element != null)
            {
                _context.Element.Remove(element);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ElementExists(int id)
        {
            return _context.Element.Any(e => e.Id == id);
        }
    }
}
