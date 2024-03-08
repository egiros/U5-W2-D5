using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using U5_W2_D5.Data;
using U5_W2_D5.Models;

namespace U5_W2_D5.Controllers
{
    [Authorize]
    public class PrenotazionesController : Controller
    {
        private readonly U5_W2_D5Context _context;

        public PrenotazionesController(U5_W2_D5Context context)
        {
            _context = context;
        }

        // GET: Prenotaziones
        public async Task<IActionResult> Index()
        {
            var u5_W2_D5Context = _context.Prenotazione.Include(p => p.Camera).Include(p => p.Cliente).Include(p => p.Pensione);
            return View(await u5_W2_D5Context.ToListAsync());
        }

        // GET: Prenotaziones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prenotazione = await _context.Prenotazione
                .Include(p => p.Camera)
                .Include(p => p.Cliente)
                .Include(p => p.Pensione)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (prenotazione == null)
            {
                return NotFound();
            }

            return View(prenotazione);
        }

        // GET: Prenotaziones/Create
        public IActionResult Create()
        {
            ViewData["IDCamera"] = new SelectList(_context.Camera, "ID", "ID");
            ViewData["IDCliente"] = new SelectList(_context.Clienti, "ID", "Cognome");
            ViewData["IDPensione"] = new SelectList(_context.Pensione, "ID", "Tipologia");
            return View();
        }

        // POST: Prenotaziones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,DataPrenotazione,DataInizioSoggiorno,DataFineSoggiorno,Anno,Acconto,Prezzo,IDCliente,IDCamera,IDPensione")] Prenotazione prenotazione)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prenotazione);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IDCamera"] = new SelectList(_context.Camera, "ID", "ID", prenotazione.IDCamera);
            ViewData["IDCliente"] = new SelectList(_context.Clienti, "ID", "Cognome", prenotazione.IDCliente);
            ViewData["IDPensione"] = new SelectList(_context.Pensione, "ID", "Tipologia", prenotazione.IDPensione);
            return View(prenotazione);
        }

        // GET: Prenotaziones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prenotazione = await _context.Prenotazione.FindAsync(id);
            if (prenotazione == null)
            {
                return NotFound();
            }
            ViewData["IDCamera"] = new SelectList(_context.Camera, "ID", "ID", prenotazione.IDCamera);
            ViewData["IDCliente"] = new SelectList(_context.Clienti, "ID", "Cognome", prenotazione.IDCliente);
            ViewData["IDPensione"] = new SelectList(_context.Pensione, "ID", "Tipologia", prenotazione.IDPensione);
            return View(prenotazione);
        }

        // POST: Prenotaziones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,DataPrenotazione,DataInizioSoggiorno,DataFineSoggiorno,Anno,Acconto,Prezzo,IDCliente,IDCamera,IDPensione")] Prenotazione prenotazione)
        {
            if (id != prenotazione.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prenotazione);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrenotazioneExists(prenotazione.ID))
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
            ViewData["IDCamera"] = new SelectList(_context.Camera, "ID", "ID", prenotazione.IDCamera);
            ViewData["IDCliente"] = new SelectList(_context.Clienti, "ID", "Cognome", prenotazione.IDCliente);
            ViewData["IDPensione"] = new SelectList(_context.Pensione, "ID", "Tipologia", prenotazione.IDPensione);
            return View(prenotazione);
        }

        // GET: Prenotaziones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prenotazione = await _context.Prenotazione
                .Include(p => p.Camera)
                .Include(p => p.Cliente)
                .Include(p => p.Pensione)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (prenotazione == null)
            {
                return NotFound();
            }

            return View(prenotazione);
        }

        // POST: Prenotaziones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var prenotazione = await _context.Prenotazione.FindAsync(id);
            if (prenotazione != null)
            {
                _context.Prenotazione.Remove(prenotazione);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrenotazioneExists(int id)
        {
            return _context.Prenotazione.Any(e => e.ID == id);
        }


        [HttpGet]
        public async Task<IActionResult> SearchByCodiceFiscale(string codiceFiscale)
        {
            if (string.IsNullOrEmpty(codiceFiscale))
            {
                return BadRequest("Il codice fiscale è obbligatorio");
            }

            var cliente = await _context.Clienti.FirstOrDefaultAsync(c => c.CodiceFiscale == codiceFiscale);

            if (cliente == null)
            {
                TempData["Error"] = ("Cliente non trovato");
                return RedirectToAction("Index");
            }

            var prenotazioni = await _context.Prenotazione
                .Include(p => p.Camera)
                .Include(p => p.Cliente)
                .Include(p => p.Pensione)
                .Where(p => p.IDCliente == cliente.ID)
                .ToListAsync();

            return View(prenotazioni);
        }

        [HttpGet]
        public async Task<IActionResult> PensioneCompleta()
        {
            var pensioneCompleta = await _context.Pensione.FirstOrDefaultAsync(p => p.Tipologia == "Pensione Completa");

            if (pensioneCompleta == null)
            {
                TempData["Message3"] = "Nessuna pensione completa trovata";
                return RedirectToAction("Index");
            }

            var totalPrenotazioni = await _context.Prenotazione
                .Where(p => p.IDPensione == pensioneCompleta.ID)
                .CountAsync();

            return View(totalPrenotazioni);
        }

        public async Task<IActionResult> Checkout(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prenotazione = await _context.Prenotazione
                .Include(p => p.Camera)
                .Include(p => p.Cliente)
                .Include(p => p.Pensione)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (prenotazione == null)
            {
                return NotFound();
            }

            var servizi = await _context.Servizi
                .Where(s => s.IDPrenotazione == id)
                .ToListAsync();


            var model = new CheckoutViewModel
            {
                Prenotazione = prenotazione,
                Servizi = servizi
            };

            return View(model);
        }
    }
}
