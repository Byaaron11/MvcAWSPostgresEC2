using Microsoft.AspNetCore.Mvc;
using MvcAWSPostgresEC2.Models;
using MvcAWSPostgresEC2.Repositories;

namespace MvcAWSPostgresEC2.Controllers
{
    public class DepartamentosController : Controller
    {
        private RepositoryDepartamentos repo;

        public DepartamentosController(RepositoryDepartamentos repo)
        {
            this.repo = repo;
        }
        public async Task<IActionResult> Index()
        {
            List<Departamento> departamentos = await this.repo.GetDepartamentosAsync();
            return View(departamentos);
        }

        public async Task<IActionResult> Details(int id)
        {
            Departamento dept = await this.repo.FindDepartamentoAsync(id);
            return View(dept);  
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(int id, string nombre, string localidad)
        {
            await this.repo.InsertDepartamento(id, nombre, localidad);
            return RedirectToAction("Index");
        }
    }
}
