using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proyecto_PrimerParcial.Data;
using Proyecto_PrimerParcial.Models;
using Proyecto_PrimerParcial.ViewModels;

namespace Proyecto_PrimerParcial.Controllers
{
    public class HangarController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HangarController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Hangar
        public async Task<IActionResult> Index(string nameFilterHan ,[Bind("HangarId, HangarNombre,HangarSector,HangarAptoMantenimiento,HangarOficinas,PistaIds")] HangarCreateViewModel hangarView)


        {
            var query = from hangar in _context.Hangar select hangar;

            if (!string.IsNullOrEmpty(nameFilterHan))
            {
                query = query.Where(x => x.HangarNombre.Contains(nameFilterHan));
            }

            var model = new HangarIndexViewModel();
            model.hangars =await query.ToListAsync();
            
            return _context.Hangar != null ?
            View(model):
                        Problem("Entity set 'ApplicationDbContext.Hangar'  is null.");
        }

        // GET: Hangar/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Hangar == null)
            {
                return NotFound();
            }

            var hangar = await _context.Hangar
                .FirstOrDefaultAsync(m => m.HangarId == id);
            if (hangar == null)
            {
                return NotFound();
            }

            var viewModel = new HangarDetailViewModel();
            viewModel.HangarNombre = hangar.HangarNombre;
            viewModel.HangarSector = hangar.HangarSector;
            viewModel.HangarAptoMantenimiento = hangar.HangarAptoMantenimiento;
            viewModel.HangarOficinas = hangar.HangarOficinas;      

            return View(viewModel);
        }

        // GET: Hangar/Create
        public IActionResult Create()
        {
            ViewData["Pistas"] = new SelectList(_context.Pista.ToList(),"PistaId","PistaNombre");
            return View();
        }

        // POST: Hangar/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HangarId, HangarNombre,HangarSector,HangarAptoMantenimiento,HangarOficinas,PistaIds")] HangarCreateViewModel hangarView)
        {
            if (ModelState.IsValid)
            {
                var pistas = _context.Pista.Where(x=> hangarView.PistaIds.Contains(x.PistaId)).ToList();

                var hangar = new Hangar{
                    HangarNombre = hangarView.HangarNombre,
                    HangarSector = hangarView.HangarSector,
                    HangarAptoMantenimiento = hangarView.HangarAptoMantenimiento,
                    HangarOficinas = hangarView.HangarOficinas,
                    Pistas = pistas

                };


                _context.Add(hangar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hangarView);
        }

        // GET: Hangar/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Hangar == null)
            {
                return NotFound();
            }

            var hangar = await _context.Hangar.FindAsync(id);
            if (hangar == null)
            {
                return NotFound();
            }
            var viewModel = new HangarEditViewModel();
            viewModel.HangarNombre = hangar.HangarNombre;
            viewModel.HangarSector = hangar.HangarSector;
            viewModel.HangarAptoMantenimiento = hangar.HangarAptoMantenimiento;
            viewModel.HangarOficinas = hangar.HangarOficinas;
            
            return View(viewModel);
        }

        // POST: Hangar/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HangarId,HangarNombre,HangarSector,HangarAptoMantenimiento,HangarOficinas")] Hangar hangarView)
        {
            if (id != hangarView.HangarId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hangarView);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HangarExists(hangarView.HangarId))
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
            return View(hangarView);
        }

        // GET: Hangar/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Hangar == null)
            {
                return NotFound();
            }

            var hangar = await _context.Hangar
                .FirstOrDefaultAsync(m => m.HangarId == id);
            if (hangar == null)
            {
                return NotFound();
            }
            var viewModel = new HangarDeleteViewModel();
            viewModel.HangarNombre = hangar.HangarNombre;
            viewModel.HangarSector = hangar.HangarSector;
            viewModel.HangarAptoMantenimiento = hangar.HangarAptoMantenimiento;
            viewModel.HangarOficinas = hangar.HangarOficinas;
            
            return View(viewModel);

        }

        // POST: Hangar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Hangar == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Hangar'  is null.");
            }
            var hangar = await _context.Hangar.FindAsync(id);
            if (hangar != null)
            {
                _context.Hangar.Remove(hangar);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HangarExists(int id)
        {
          return (_context.Hangar?.Any(e => e.HangarId == id)).GetValueOrDefault();
        }
    }
}
