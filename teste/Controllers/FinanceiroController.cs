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
    public class FinanceiroController : Controller
    {
        private readonly Contexto _context;

        public FinanceiroController(Contexto context)
        {
            _context = context;
        }

        // GET: Financeiro
        public async Task<IActionResult> Index()
        {
            return View(await _context.Financeiro.ToListAsync());
        }

        // GET: Financeiro/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var financeiro = await _context.Financeiro
                .FirstOrDefaultAsync(m => m.Id == id);
            if (financeiro == null)
            {
                return NotFound();
            }

            return View(financeiro);
        }

        // GET: Financeiro/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Financeiro/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id")] Financeiro financeiro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(financeiro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(financeiro);
        }

        // GET: Financeiro/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var financeiro = await _context.Financeiro.FindAsync(id);
            if (financeiro == null)
            {
                return NotFound();
            }
            return View(financeiro);
        }

        // POST: Financeiro/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id")] Financeiro financeiro)
        {
            if (id != financeiro.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(financeiro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FinanceiroExists(financeiro.Id))
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
            return View(financeiro);
        }

        // GET: Financeiro/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var financeiro = await _context.Financeiro
                .FirstOrDefaultAsync(m => m.Id == id);
            if (financeiro == null)
            {
                return NotFound();
            }

            return View(financeiro);
        }

        // POST: Financeiro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var financeiro = await _context.Financeiro.FindAsync(id);
            _context.Financeiro.Remove(financeiro);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FinanceiroExists(int id)
        {
            return _context.Financeiro.Any(e => e.Id == id);
        }
    }
}
