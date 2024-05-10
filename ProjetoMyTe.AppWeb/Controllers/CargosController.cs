using Microsoft.AspNetCore.Mvc;
using ProjetoMyTe.AppWeb.Services;

namespace ProjetoMyTe.AppWeb.Controllers
{
    public class CargosController : Controller
    {
        private readonly CargosService cargosService;
        public CargosController(CargosService cargosService)
        {
            this.cargosService = cargosService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ListarCargos()
        {
            var lista = cargosService.Listar();
            return View(lista);
        }

    }
}
