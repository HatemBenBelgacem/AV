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
    public class AuftragController : Controller
    {
        private readonly AVContext _context;

        public AuftragController(AVContext context)
        {
            _context = context;
        }

        // GET: Auftrag
        public async Task<IActionResult> Index()
        {
            return View(await _context.Auftraege.ToListAsync());
        }

        // GET: Auftrag/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var auftrag = await _context.Auftraege
                .FirstOrDefaultAsync(m => m.Id == id);
            if (auftrag == null)
            {
                return NotFound();
            }

            return View(auftrag);
        }

        // GET: Auftrag/Create
        public IActionResult Create()
        {
           var adressen = _context.Adressen.ToList();
           ViewBag.Adressen = new SelectList(adressen, "Id", "Name");
            return View();
        }
        // POST: Auftrag/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Beschreibung,AdresseId")] Auftrag auftrag)
        {
           
            if (ModelState.IsValid)
            {
                 _context.Add(auftrag);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(auftrag);
        }

        // GET: Auftrag/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var auftrag = await _context.Auftraege.FindAsync(id);
            if (auftrag == null)
            {
                return NotFound();
            }
            return View(auftrag);
        }

        // POST: Auftrag/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Beschreibung,AdresseId")] Auftrag auftrag)
        {
            if (id != auftrag.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(auftrag);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AuftragExists(auftrag.Id))
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
            return View(auftrag);
        }

        // GET: Auftrag/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var auftrag = await _context.Auftraege
                .FirstOrDefaultAsync(m => m.Id == id);
            if (auftrag == null)
            {
                return NotFound();
            }

            return View(auftrag);
        }

        // POST: Auftrag/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var auftrag = await _context.Auftraege.FindAsync(id);
            if (auftrag != null)
            {
                _context.Auftraege.Remove(auftrag);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AuftragExists(int id)
        {
            return _context.Auftraege.Any(e => e.Id == id);
        }
    }
}
