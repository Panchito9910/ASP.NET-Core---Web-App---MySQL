using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ModeloDualWebMySql.Models;
using ModeloDualWebMySql.Models.ViewModels;

namespace ModeloDualWebMySql.Controllers
{
    public class EmpresaController : Controller
    {
        private readonly ModelodualContext _context;
        public EmpresaController(ModelodualContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index() => View(await _context.Empresas.ToListAsync());
        public IActionResult Create() => View();
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EmpresaViewModel model)
        {
            if(ModelState.IsValid)
            {
                var empresa = new Empresa() { 
                    CodigoEmpresa=model.CodigoEmpresa,
                    NombreEmpresa=model.NombreEmpresa,
                    CorreoEmpresa=model.CorreoEmpresa,
                };
                _context.Add(empresa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
        public IActionResult Edit(int id)
        {
            var empresa = _context.Empresas.Find(id);
            var model = new EmpresaViewModel() 
            {   IdEmpresa=id,
                CodigoEmpresa=empresa.CodigoEmpresa,
                NombreEmpresa=empresa.NombreEmpresa,
                CorreoEmpresa=empresa.CorreoEmpresa,
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EmpresaViewModel model)
        {
            if (ModelState.IsValid)
            {
                var empresa = new Empresa() { 
                    IdEmpresa=model.IdEmpresa,
                    CodigoEmpresa=model.CodigoEmpresa,
                    NombreEmpresa=model.NombreEmpresa,
                    CorreoEmpresa=model.CorreoEmpresa,
                };
                _context.Empresas.Update(empresa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var empresa = _context.Empresas.Find(id);
            if (empresa != null)
            {
                _context.Remove(empresa);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index)); 
        }
    }
}
