using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ModeloDualWebMySql.Models;
using ModeloDualWebMySql.Models.ViewModels;

namespace ModeloDualWebMySql.Controllers
{
    public class ProyectoController : Controller
    {
        private readonly ModelodualContext _context;
        public ProyectoController(ModelodualContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index() => View(await _context.Proyectos.ToListAsync());
        public IActionResult Create() 
        {
            ViewData["Alumnos"] = new SelectList(_context.Alumnos, "Matricula", "Matricula");
            ViewData["Empresas"] = new SelectList(_context.Empresas, "CodigoEmpresa", "CodigoEmpresa");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProyectoViewModel model)
        {
            if (ModelState.IsValid)
            {
                var proyecto = new Proyecto()
                {
                    CodigoProyecto = model.CodigoProyecto,
                    NombreProyecto = model.NombreProyecto,
                    CodigoEmpresa  = model.CodigoEmpresa,
                    Matricula      = model.Matricula
                };
                _context.Add(proyecto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);           
        }
        public IActionResult Edit(int id)
        {

            ViewData["Alumnos"] = new SelectList(_context.Alumnos, "Matricula", "Matricula");
            ViewData["Empresas"] = new SelectList(_context.Empresas, "CodigoEmpresa", "CodigoEmpresa");
            var proyecto = _context.Proyectos.Find(id);
            var model = new ProyectoViewModel() { 
                IdProyecto     = proyecto.IdProyecto,
                CodigoProyecto = proyecto.CodigoProyecto,
                NombreProyecto = proyecto.NombreProyecto,
                CodigoEmpresa  = proyecto.CodigoEmpresa,
                Matricula      = proyecto.Matricula
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProyectoViewModel model)
        {
            if (ModelState.IsValid)
            {
                var proyecto = new Proyecto() { 
                    IdProyecto     = model.IdProyecto,
                    CodigoProyecto = model.CodigoProyecto,
                    NombreProyecto = model.NombreProyecto,
                    CodigoEmpresa  = model.CodigoEmpresa,
                    Matricula      = model.Matricula
                };
                _context.Proyectos.Update(proyecto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var proyecto = _context.Proyectos.Find(id);
            if (proyecto != null)
            {
                _context.Remove(proyecto);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Asignados()
        {
            var asignados = _context.Proyectos.Include(p => p.MatriculaNavigation);
            return View(await asignados.ToListAsync());
        }
    }
}
