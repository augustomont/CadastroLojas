using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CadastroLojas.Models;

namespace CadastroLojas.Controllers
{
    public class LojasController : Controller
    {
        private readonly Contexto _context;

        public LojasController(Contexto context)
        {
            _context = context;
        }

        // GET: Lojas
        public async Task<IActionResult> Index()
        {
              return _context.Lojas != null ? 
                          View(await _context.Lojas.ToListAsync()) :
                          Problem("Entity set 'Contexto.Lojas'  is null.");
        }

        // GET: Lojas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Lojas == null)
            {
                return NotFound();
            }

            var lojasModel = await _context.Lojas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lojasModel == null)
            {
                return NotFound();
            }

            return View(lojasModel);
        }

        // GET: Lojas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Lojas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Estado,Cidade,Unidade")] LojasModel lojasModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lojasModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lojasModel);
        }

        // GET: Lojas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Lojas == null)
            {
                return NotFound();
            }

            var lojasModel = await _context.Lojas.FindAsync(id);
            if (lojasModel == null)
            {
                return NotFound();
            }
            return View(lojasModel);
        }

        // POST: Lojas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Estado,Cidade,Unidade")] LojasModel lojasModel)
        {
            if (id != lojasModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lojasModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LojasModelExists(lojasModel.Id))
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
            return View(lojasModel);
        }

        // GET: Lojas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Lojas == null)
            {
                return NotFound();
            }

            var lojasModel = await _context.Lojas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lojasModel == null)
            {
                return NotFound();
            }

            return View(lojasModel);
        }

        // POST: Lojas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Lojas == null)
            {
                return Problem("Entity set 'Contexto.Lojas'  is null.");
            }
            var lojasModel = await _context.Lojas.FindAsync(id);
            if (lojasModel != null)
            {
                _context.Lojas.Remove(lojasModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LojasModelExists(int id)
        {
          return (_context.Lojas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
