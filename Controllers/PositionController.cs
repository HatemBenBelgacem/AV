using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AV.Data;
using AV.Models;

namespace AV.Controllers
{
    public class PositionController : Controller
    {
        private readonly AVContext _context;

        public PositionController(AVContext context)
        {
            _context = context;
        }

        // GET: Position
        public async Task<IActionResult> Index()
        {
            var aVContext = _context.Positionen.Include(p => p.Auftrag).Include(p => p.Produkt);
            return View(await aVContext.ToListAsync());
        }

        // GET: Position/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var position = await _context.Positionen
                .Include(p => p.Auftrag)
                .Include(p => p.Produkt)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (position == null)
            {
                return NotFound();
            }

            return View(position);
        }

        // GET: Position/Create
        public async Task<IActionResult> CreateOrder(int? id)
        {
           
           var auftrag = await _context.Auftraege
           .FirstOrDefaultAsync(m => m.Id == id);

            ViewData["AuftragId"] = new SelectList(_context.Auftraege, "Id", "Bezeichnung");
            ViewData["ProduktId"] = new SelectList(_context.Produkte, "Id", "Bezeichnung");
            return View(auftrag);
        }

        // POST: Position/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AuftragId,ProduktId")] Position position)
        {
            if (ModelState.IsValid)
            {
                _context.Add(position);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AuftragId"] = new SelectList(_context.Auftraege, "Id", "Id", position.AuftragId);
            ViewData["ProduktId"] = new SelectList(_context.Produkte, "Id", "Id", position.ProduktId);
            return View();
        }

        // GET: Position/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var position = await _context.Positionen.FindAsync(id);
            if (position == null)
            {
                return NotFound();
            }
            ViewData["AuftragId"] = new SelectList(_context.Auftraege, "Id", "Id", position.AuftragId);
            ViewData["ProduktId"] = new SelectList(_context.Produkte, "Id", "Id", position.ProduktId);
            return View(position);
        }

        // POST: Position/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AuftragId,ProduktId")] Position position)
        {
            if (id != position.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(position);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PositionExists(position.Id))
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
            ViewData["AuftragId"] = new SelectList(_context.Auftraege, "Id", "Id", position.AuftragId);
            ViewData["ProduktId"] = new SelectList(_context.Produkte, "Id", "Id", position.ProduktId);
            return View(position);
        }

        // GET: Position/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var position = await _context.Positionen
                .Include(p => p.Auftrag)
                .Include(p => p.Produkt)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (position == null)
            {
                return NotFound();
            }

            return View(position);
        }

        // POST: Position/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var position = await _context.Positionen.FindAsync(id);
            if (position != null)
            {
                _context.Positionen.Remove(position);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PositionExists(int id)
        {
            return _context.Positionen.Any(e => e.Id == id);
        }
    }
}
