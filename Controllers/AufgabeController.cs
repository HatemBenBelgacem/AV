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
    public class AufgabeController : Controller
    {
        private readonly AVContext _context;

        public AufgabeController(AVContext context)
        {
            _context = context;
        }

        // GET: Aufgabe
        public async Task<IActionResult> Index()
        {
            return View(await _context.Aufgabe.ToListAsync());
        }

        // GET: Aufgabe/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aufgabe = await _context.Aufgabe
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aufgabe == null)
            {
                return NotFound();
            }

            return View(aufgabe);
        }

        // GET: Aufgabe/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Aufgabe/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Bezeichnung")] Aufgabe aufgabe)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aufgabe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aufgabe);
        }

        // GET: Aufgabe/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aufgabe = await _context.Aufgabe.FindAsync(id);
            if (aufgabe == null)
            {
                return NotFound();
            }
            return View(aufgabe);
        }

        // POST: Aufgabe/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Bezeichnung")] Aufgabe aufgabe)
        {
            if (id != aufgabe.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aufgabe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AufgabeExists(aufgabe.Id))
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
            return View(aufgabe);
        }

        // GET: Aufgabe/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aufgabe = await _context.Aufgabe
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aufgabe == null)
            {
                return NotFound();
            }

            return View(aufgabe);
        }

        // POST: Aufgabe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aufgabe = await _context.Aufgabe.FindAsync(id);
            if (aufgabe != null)
            {
                _context.Aufgabe.Remove(aufgabe);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AufgabeExists(int id)
        {
            return _context.Aufgabe.Any(e => e.Id == id);
        }
    }
}
