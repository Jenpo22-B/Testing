using Microsoft.AspNetCore.Mvc;
using Proyecto.Conexion;
using Proyecto.Models;
using System.Diagnostics;

namespace Proyecto.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConexion conexion;

        public HomeController(IConexion conexion)
        {
            this.conexion = conexion;
        }
        [HttpPost]
        public async Task<IActionResult> Index(Formulario form)
        {
            var ValidarRut = await VerificarRut(form.Rut);
            if (!ValidarRut)
            {
                ModelState.AddModelError(nameof(form.Rut), $"El Rut {form.Rut} ya existe.");
                return View();
            }
            await conexion.InsertPaciente(form);
            return View();
        }
        public IActionResult Index() 
        {
            return View();
        }

        public async Task<bool> VerificarRut(string rut)
        {
            var rutExiste=await conexion.ObtenerPacientePorRut(rut);
            if (rutExiste.Any()) 
            {
                return false;
            }
            return true;
        }

    }
}
