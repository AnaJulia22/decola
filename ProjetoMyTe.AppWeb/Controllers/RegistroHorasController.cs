using Microsoft.AspNetCore.Mvc;
using ProjetoMyTe.AppWeb.Models.Entities;
using ProjetoMyTe.AppWeb.Services;
using System;

namespace ProjetoMyTe.AppWeb.Controllers
{

    public class RegistroHorasController : Controller
    {
        private readonly RegistroHorasService registroHorasService;
        public RegistroHorasController(RegistroHorasService registroHorasService)
        {
            this.registroHorasService = registroHorasService;  
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ListarRegistros()
        {
            var lista = registroHorasService.Listar();
            return View(lista);
        }

        public IActionResult IncluirRegistro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult IncluirRegistro(RegistroHora registroHora)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }

                registroHora.DataRegistro = DateTime.Now;
                registroHorasService.Incluir(registroHora);
                return RedirectToAction("ListarRegistros");
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IActionResult AlterarRegistro(int id)
        {
            try
            {
                if (id <= 0)
                {
                    throw new
                        ArgumentException($"O valor informado na URL ({id}) é inválido");
                }

                RegistroHora? registroHora = registroHorasService.Buscar(id);
                if (registroHora == null)
                {
                    throw new ArgumentException($"Nenhum objeto com este id: {id}");
                }
                return View(registroHora);
            }
            catch (Exception e)
            {
                return View("_Erro", e);
            }
        }

        [HttpPost]
        public IActionResult AlterarRegistro(RegistroHora registroHora)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }

                registroHorasService.Alterar(registroHora);
                return RedirectToAction("ListarRegistros"); // Requisição get
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IActionResult RemoverRegistro(int id)
        {
            try
            {
                if (id <= 0)
                {
                    throw new
                        ArgumentException($"O valor informado na URL ({id}) é inválido");
                }

                RegistroHora? registroHora = registroHorasService.Buscar(id);
                if (registroHora == null)
                {
                    throw new ArgumentException($"Nenhum objeto com este id: {id}");
                }
                return View(registroHora);
            }
            catch (Exception e)
            {
                return View("_Erro", e);
            }
        }

        [HttpPost]
        public IActionResult RemoverRegistro(RegistroHora registroHora)
        {
            try
            {
                registroHorasService.Remover(registroHora);
                return RedirectToAction("ListarRegistros");
            }
            catch (Exception e)
            {
                return View("_Erro", e);
            }
        }
    }
}
