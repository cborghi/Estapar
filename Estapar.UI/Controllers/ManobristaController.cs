using Estapar.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estapar.UI.Controllers
{
    public class ManobristaController : Controller
    {
        private readonly IManobristaService _manobristaService;

        public ManobristaController(IManobristaService manobristaService)
        {
            _manobristaService = manobristaService;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var lstManobristas = await _manobristaService.GetManobristas();
            return View(lstManobristas);
        }

        public IActionResult InsertManobrista()
        {
            return View("Adicionar");
        }

        public async Task<IActionResult> InsertAsync(string nome, string cpf, string nasc)
        {            
            await _manobristaService.InsertManobristas(nome, cpf, nasc);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteManobristaAsync(string id)
        {
            await _manobristaService.DeleteManobristas(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateManobristaAsync(string id)
        {
            var manobristas = await _manobristaService.GetManobristaById(id);
            return View("Editar", manobristas);
        }

        public async Task<IActionResult> UpdateAsync(string nome, string cpf, string nasc, string id)
        {
            await _manobristaService.UpdatetManobristas(nome, cpf, nasc, id);
            return RedirectToAction("Index");
        }
    }
}
