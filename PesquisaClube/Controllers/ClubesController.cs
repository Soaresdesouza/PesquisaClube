using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PesquisaClube.Models;

namespace PesquisaClube.Controllers
{
    public class ClubesController : Controller
    {
        private readonly ClubeContexto _context;

        public ClubesController(ClubeContexto context)
        {
            _context = context;
        }

        // GET: Clubes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Clube.ToListAsync());
        }

        public async Task<IActionResult> EscolhaClubes(List<Clube> clubes)
        {
            foreach(var item in clubes)
            {
                if (item.CheckboxMarcado == true)
                {
                    Clube clube = await _context.Clube.FirstOrDefaultAsync(x => x.ClubeId == item.ClubeId);
                    clube.Qtde = clube.Qtde + 1;
                    _context.Update(clube);
                    await _context.SaveChangesAsync();

                }
            }
            return RedirectToAction(nameof(Index));
        }

        public JsonResult DadosGrafico()
        {
            return Json(_context.Clube.Select(x => new { x.ClubeNome, x.Qtde }));
        }

        // GET: Clubes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clubes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClubeId,ClubeNome,Qtde")] Clube clube)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clube);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clube);
        }

        // GET: Clubes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clube = await _context.Clube.FindAsync(id);
            if (clube == null)
            {
                return NotFound();
            }
            return View(clube);
        }

        // POST: Clubes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClubeId,ClubeNome,Qtde")] Clube clube)
        {
            if (id != clube.ClubeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clube);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClubeExists(clube.ClubeId))
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
            return View(clube);
        }

        // GET: Clubes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clube = await _context.Clube
                .FirstOrDefaultAsync(m => m.ClubeId == id);
            if (clube == null)
            {
                return NotFound();
            }

            return View(clube);
        }

        // POST: Clubes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clube = await _context.Clube.FindAsync(id);
            _context.Clube.Remove(clube);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClubeExists(int id)
        {
            return _context.Clube.Any(e => e.ClubeId == id);
        }
    }
}
