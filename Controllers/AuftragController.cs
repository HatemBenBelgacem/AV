using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AV.Data;
using AV.Models;
using System.Net.Http.Headers;

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
        public IActionResult Index()
        {
            //return View(await _context.Auftraege.ToListAsync());
            var auftrag = _context.Auftraege
                        .Include(a => a.Adresse);
                        
            if(auftrag == null)
            {
                return NotFound();
            }
            
            return View(auftrag);
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
        public async Task<IActionResult> CreateOrder(int? id)
        {
            var auftrag = await _context.Auftraege
                .Include(p => p.Position)
                .ThenInclude(i => i.Produkt)
                .FirstOrDefaultAsync(m => m.Id == id);

            var produkte = _context.Produkte
                .ToList();
            ViewBag.Produkte = new SelectList(produkte, "Id", "Bezeichnung");
           
           return View(auftrag);
        }

        public async Task<IActionResult> SaveOrder(int orderId, int productId)
        {
             var auftrag = await _context.Auftraege
            .Include(p => p.Position)
            .FirstOrDefaultAsync(m => m.Id == orderId);

        if (auftrag == null)
        {
            return NotFound();
        }

        var produkt = await _context.Produkte.FindAsync(productId);
        if (produkt == null)
        {
            return NotFound();
        }

            // Erstellen Sie eine neue Position mit dem ausgewählten Produkt
            var neuePosition = new Position { Produkt = produkt };

            // Fügen Sie die neue Position dem Auftrag hinzu
            auftrag.Position.Add(neuePosition);

            // Speichern Sie die Änderungen in der Datenbank
            await _context.SaveChangesAsync();

            // Umleitung zur Detailsansicht des Auftrags oder einer anderen geeigneten Seite
            return RedirectToAction("Details", "Auftrag", new { id = orderId });
            
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

            var adressen = _context.Adressen.ToList();
            ViewBag.Adressen = new SelectList(adressen, "Id", "Name");

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
