using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using teste.Models;

namespace teste.Controllers
{
    public class BalancoController : Controller
    {
        private readonly Contexto _context;

        public BalancoController(Contexto context)
        {
            _context = context;
        }

        // GET: Balanco
        public async Task<IActionResult> Index()
        {
            return View(await _context.Balanco.ToListAsync());
        }

        // GET: Balanco/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var balanco = await _context.Balanco
                .FirstOrDefaultAsync(m => m.Id == id);
            if (balanco == null)
            {
                return NotFound();
            }

            return View(balanco);
        }

        // GET: Balanco/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Balanco/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,data,valordebito,valorcredito,saldo")] Balanco balanco)
        {
            if (ModelState.IsValid)
            {   
                balanco.saldo = balanco.valorcredito - balanco.valordebito;
                balanco.data = DateTime.Now;
                _context.Add(balanco);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(balanco);
        }

        // GET: Balanco/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var balanco = await _context.Balanco.FindAsync(id);
            if (balanco == null)
            {
                return NotFound();
            }
            return View(balanco);
        }

        // POST: Balanco/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,data,valordebito,valorcredito,saldo")] Balanco balanco)
        {
            if (id != balanco.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(balanco);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BalancoExists(balanco.Id))
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
            return View(balanco);
        }

        // GET: Balanco/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var balanco = await _context.Balanco
                .FirstOrDefaultAsync(m => m.Id == id);
            if (balanco == null)
            {
                return NotFound();
            }

            return View(balanco);
        }

        // POST: Balanco/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var balanco = await _context.Balanco.FindAsync(id);
            _context.Balanco.Remove(balanco);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BalancoExists(int id)
        {
            return _context.Balanco.Any(e => e.Id == id);
        }
    }
}
