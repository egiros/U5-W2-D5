using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using U5_W2_D5.Data;
using U5_W2_D5.Models;

namespace U5_W2_D5.Controllers
{
    public class ClientisController : Controller
    {
        private readonly U5_W2_D5Context _context;

        public ClientisController(U5_W2_D5Context context)
        {
            _context = context;
        }

        // GET: Clientis
        public async Task<IActionResult> Index()
        {
            return View(await _context.Clienti.ToListAsync());
        }

        // GET: Clientis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clienti = await _context.Clienti
                .FirstOrDefaultAsync(m => m.ID == id);
            if (clienti == null)
            {
                return NotFound();
            }

            return View(clienti);
        }

        // GET: Clientis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clientis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Nome,Cognome,CodiceFiscale,Citta,Provincia,Email,Telefono,Cellulare")] Clienti clienti)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clienti);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clienti);
        }

        // GET: Clientis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clienti = await _context.Clienti.FindAsync(id);
            if (clienti == null)
            {
                return NotFound();
            }
            return View(clienti);
        }

        // POST: Clientis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Nome,Cognome,CodiceFiscale,Citta,Provincia,Email,Telefono,Cellulare")] Clienti clienti)
        {
            if (id != clienti.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clienti);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientiExists(clienti.ID))
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
            return View(clienti);
        }

        // GET: Clientis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clienti = await _context.Clienti
                .FirstOrDefaultAsync(m => m.ID == id);
            if (clienti == null)
            {
                return NotFound();
            }

            return View(clienti);
        }

        // POST: Clientis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clienti = await _context.Clienti.FindAsync(id);
            if (clienti != null)
            {
                _context.Clienti.Remove(clienti);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClientiExists(int id)
        {
            return _context.Clienti.Any(e => e.ID == id);
        }
    }
}
