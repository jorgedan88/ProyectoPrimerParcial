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
    public class AeronaveController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AeronaveController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Aeronave
        public async Task<IActionResult> Index(string nameFilter ,[Bind("AeronaveTipo,AeronaveFabricacion")] AeronaveIndexViewModel aeronaveView)


        {
            var query = from aeronave in _context.Aeronave select aeronave;

            if (!string.IsNullOrEmpty(nameFilter))
            {
                query = query.Where(x => x.AeronaveTipo.Contains(nameFilter) || x.AeronaveMatricula.Contains(nameFilter));
            }

            var model = new AeronaveIndexViewModel();
            model.aeronaves =await query.ToListAsync();
            
            return _context.Aeronave != null ?
            View(model):
            Problem("Entity set 'AeronaveContex.Aeronave' is null.");

        }

        // GET: Aeronave/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Aeronave == null)
            {
                return NotFound();
            }

            var aeronave = await _context.Aeronave
                .FirstOrDefaultAsync(m => m.AeronaveId == id);
            if (aeronave == null)
            {
                return NotFound();
            }

            var viewModel = new AeronaveDetailViewModel();
                viewModel.AeronaveFabricacion = aeronave.AeronaveFabricacion;
                viewModel.AeronaveMatricula = aeronave.AeronaveMatricula;
                viewModel.AeronaveTipo = aeronave.AeronaveTipo;            

            return View(viewModel);
        }

        // GET: Aeronave/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Aeronave/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AeronaveTipo,AeronaveFabricacion,AeronaveMatricula")] AeronaveCreateViewModel aeronaveView)
        {
            if (ModelState.IsValid)
            {
                var aeronave = new Aeronave{
                    AeronaveFabricacion = aeronaveView.AeronaveFabricacion,
                    AeronaveTipo = aeronaveView.AeronaveTipo,
                    AeronaveMatricula = aeronaveView.AeronaveMatricula,
                };
                _context.Add(aeronave);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aeronaveView);
        }

        // GET: Aeronave/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Aeronave == null)
            {
                return NotFound();
            }

            var aeronave = await _context.Aeronave.FindAsync(id);
            if (aeronave == null)
            {
                return NotFound();
            }

            var viewModel = new AeronaveEditViewModel();
            viewModel.AeronaveFabricacion = aeronave.AeronaveFabricacion;
            viewModel.AeronaveTipo = aeronave.AeronaveTipo;
            viewModel.AeronaveMatricula = aeronave.AeronaveMatricula;
            

            return View(viewModel);

            // return View(aeronave);
        }

        // POST: Aeronave/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AeronaveId,AeronaveFabricacion,AeronaveTipo,AeronaveMatricula")] Aeronave aeronaveView)
        {
            if (id != aeronaveView.AeronaveId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aeronaveView);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AeronaveExists(aeronaveView.AeronaveId))
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
            return View(aeronaveView);
        }

        // GET: Aeronave/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Aeronave == null)
            {
                return NotFound();
            }

            var aeronave = await _context.Aeronave
                .FirstOrDefaultAsync(m => m.AeronaveId == id);
            if (aeronave == null)
            {
                return NotFound();
            }
                var viewModel = new AeronaveDeleteViewModel();
                    viewModel.AeronaveFabricacion = aeronave.AeronaveFabricacion;
                    viewModel.AeronaveMatricula = aeronave.AeronaveMatricula;
                    viewModel.AeronaveTipo = aeronave.AeronaveTipo;            

            return View(viewModel);
        }

        // POST: Aeronave/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Aeronave == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Aeronave'  is null.");
            }
            var aeronave = await _context.Aeronave.FindAsync(id);
            if (aeronave != null)
            {
                _context.Aeronave.Remove(aeronave);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AeronaveExists(int id)
        {
          return (_context.Aeronave?.Any(e => e.AeronaveId == id)).GetValueOrDefault();
        }
    }
}
