using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ModeloDualWebMySql.Models;
using ModeloDualWebMySql.Models.ViewModels;

namespace ModeloDualWebMySql.Controllers
{
    public class AlumnoController : Controller
    {
        private readonly ModelodualContext _context;
        public AlumnoController(ModelodualContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index() => View(await _context.Alumnos.ToListAsync());
        public IActionResult Create() => View();
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AlumnoViewModel model)
        {
            if (ModelState.IsValid)
            {
                var alumno = new Alumno() { 
                    Matricula=model.Matricula,
                    NombreAlumno=model.NombreAlumno,
                    ApellidoAlumno=model.ApellidoAlumno,
                    SemestreActual=model.SemestreActual,
                    CorreoAlumno=model.CorreoAlumno
                };
                _context.Add(alumno);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
        public IActionResult Edit(int id)
        {
            var alumno = _context.Alumnos.Find(id);
            var model = new AlumnoViewModel() {
                IdAlumno       = id,
                Matricula      = alumno.Matricula,
                NombreAlumno   = alumno.NombreAlumno,
                ApellidoAlumno = alumno.ApellidoAlumno,
                SemestreActual = alumno.SemestreActual,
                CorreoAlumno   = alumno.CorreoAlumno
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(AlumnoViewModel model)
        {
            if (ModelState.IsValid)
            {
                var alumno = new Alumno()
                {
                    IdAlumno       = model.IdAlumno,
                    Matricula      = model.Matricula,
                    NombreAlumno   = model.NombreAlumno,
                    ApellidoAlumno = model.ApellidoAlumno,
                    SemestreActual = model.SemestreActual,
                    CorreoAlumno   = model.CorreoAlumno
                };
                _context.Alumnos.Update(alumno);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var alumno = _context.Alumnos.Find(id);
            if (alumno != null)
            {
                _context.Remove(alumno);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

    }
}
