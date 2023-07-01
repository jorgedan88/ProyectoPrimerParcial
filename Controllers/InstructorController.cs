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
    public class InstructorController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InstructorController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Instructor
        public async Task<IActionResult> Index(string nameFilterIns)
        {
            var query = from instructor in _context.Instructor.Include(i => i.Aeronave) select instructor;

            if (!string.IsNullOrEmpty(nameFilterIns))
            {
                query = query.Where(x => x.InstructorNombre.Contains(nameFilterIns) || x.InstructorApellido.Contains(nameFilterIns) || x.InstructorDni.ToString() == nameFilterIns);
            }

            var model = new InstructorIndexViewModel();
            model.instructors =await query.ToListAsync();
            
            return _context.Aeronave != null ?
            View(model):
            Problem("Entity set 'AeronaveContex.Aeronave' is null.");

        }

        // GET: Instructor/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Instructor == null)
            {
                return NotFound();
            }

            var instructor = await _context.Instructor
                .FirstOrDefaultAsync(m => m.InstructorId == id);
            if (instructor == null)
            {
                return NotFound();
            }
            var viewModel  = new InstructorDetailViewModel();
            viewModel.InstructorNombre = instructor.InstructorNombre;
            viewModel.InstructorApellido = instructor.InstructorApellido;
            viewModel.InstructorDni = instructor.InstructorDni;
            viewModel.InstructorTipoLicencia = instructor.InstructorTipoLicencia;
            viewModel.InstructorNumeroLicencia = instructor.InstructorNumeroLicencia;
            viewModel.InstructorExpedicion = instructor.InstructorExpedicion;
            viewModel.InstructorEnActividad = instructor.InstructorEnActividad;
            viewModel.AeronaveId = instructor.AeronaveId;

            return View(viewModel);
        }

        // GET: Instructor/Create
        public IActionResult Create()
        {
            ViewData["AeronaveId"] = new SelectList(_context.Aeronave, "AeronaveId", "AeronaveTipo",  "instructor.AeronaveId");
            return View();
        }

        // POST: Instructor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InstructorId,InstructorNombre,InstructorApellido,InstructorDni,InstructorTipoLicencia,InstructorNumeroLicencia,InstructorExpedicion,InstructorEnActividad,AeronaveId")] InstructorCreateViewModel instructorView)
        {
            if (ModelState.IsValid)
            {
                var instructor = new Instructor{
                    InstructorNombre = instructorView.InstructorNombre,
                    InstructorApellido = instructorView.InstructorApellido,
                    InstructorDni = instructorView.InstructorDni,
                    InstructorTipoLicencia = instructorView.InstructorTipoLicencia,
                    InstructorNumeroLicencia = instructorView.InstructorNumeroLicencia,
                    InstructorExpedicion = instructorView.InstructorExpedicion,
                    InstructorEnActividad = instructorView.InstructorEnActividad,
                    AeronaveId = instructorView.AeronaveId
                    
                };
                _context.Add(instructor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            // ViewData["AeronaveId"] = new SelectList(_context.Aeronave, "AeronaveId", "TipoAeronave",  "instructor.AeronaveId");
            return View(instructorView);
        }

        // GET: Instructor/Edit/5      
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Instructor == null)
            {
                return NotFound();
            }

            var instructor = await _context.Instructor.FindAsync(id);
            if (instructor == null)
            {
                return NotFound();
            }

            var viewModel  = new InstructorEditViewModel();
                    viewModel.InstructorNombre = instructor.InstructorNombre;
                    viewModel.InstructorApellido = instructor.InstructorApellido;
                    viewModel.InstructorDni = instructor.InstructorDni;
                    viewModel.InstructorTipoLicencia = instructor.InstructorTipoLicencia;
                    viewModel.InstructorNumeroLicencia = instructor.InstructorNumeroLicencia;
                    viewModel.InstructorExpedicion = instructor.InstructorExpedicion;
                    viewModel.InstructorEnActividad = instructor.InstructorEnActividad;
                    viewModel.AeronaveId = instructor.AeronaveId;

            ViewData["AeronaveId"] = new SelectList(_context.Aeronave, "AeronaveId", "AeronaveTipo");
            return View(viewModel);
        }

        // POST: Instructor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InstructorId,InstructorNombre,InstructorApellido,InstructorDni,InstructorTipoLicencia,InstructorNumeroLicencia,InstructorExpedicion,InstructorEnActividad,AeronaveId")] Instructor instructorView)
        {
            if (id != instructorView.InstructorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(instructorView);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InstructorExists(instructorView.InstructorId))
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

            // var viewModel  = new InstructorEditViewModel();
            // viewModel.InstructorNombre = instructor.InstructorNombre;
            // viewModel.InstructorApellido = instructor.InstructorApellido;
            // viewModel.InstructorDni = instructor.InstructorDni;
            // viewModel.InstructorTipoLicencia = instructor.InstructorTipoLicencia;
            // viewModel.InstructorNumeroLicencia = instructor.InstructorNumeroLicencia;
            // viewModel.InstructorExpedicion = instructor.InstructorExpedicion;
            // viewModel.InstructorEnActividad = instructor.InstructorEnActividad;
            // viewModel.AeronaveId = instructor.AeronaveId;

            ViewData["AeronaveId"] = new SelectList(_context.Aeronave, "AeronaveId", "AeronaveTipo");
            return View(instructorView);
        }

        // GET: Instructor/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Instructor == null)
            {
                return NotFound();
            }

            var instructor = await _context.Instructor
                .FirstOrDefaultAsync(m => m.InstructorId == id);
            if (instructor == null)
            {
                return NotFound();
            }
            var viewModel  = new InstructorDeleteViewModel();
            viewModel.InstructorNombre = instructor.InstructorNombre;
            viewModel.InstructorApellido = instructor.InstructorApellido;
            viewModel.InstructorDni = instructor.InstructorDni;
            viewModel.InstructorTipoLicencia = instructor.InstructorTipoLicencia;
            viewModel.InstructorNumeroLicencia = instructor.InstructorNumeroLicencia;
            viewModel.InstructorExpedicion = instructor.InstructorExpedicion;
            viewModel.InstructorEnActividad = instructor.InstructorEnActividad;
            viewModel.AeronaveId = instructor.AeronaveId;

            return View(viewModel);
        }

        // POST: Instructor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Instructor == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Instructor'  is null.");
            }
            var instructor = await _context.Instructor.FindAsync(id);
            if (instructor != null)
            {
                _context.Instructor.Remove(instructor);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InstructorExists(int id)
        {
          return (_context.Instructor?.Any(e => e.InstructorId == id)).GetValueOrDefault();
        }
    }
}
