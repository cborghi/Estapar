using Estapar.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estapar.UI.Controllers
{
    public class CarroController : Controller
    {
        private readonly ICarroService _carroService;

        public CarroController(ICarroService carroService)
        {
            _carroService = carroService;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var lstCarros = await _carroService.GetCarros();
            return View(lstCarros);
        }

        public IActionResult InsertCarro()
        {
            return View("Adicionar");
        }

        public async Task<IActionResult> InsertAsync(string marca, string modelo, string placa)
        {
            await _carroService.InsertCarros(marca, modelo, placa);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteCarroAsync(string id)
        {
            await _carroService.DeleteCarros(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateCarroAsync(string id)
        {
            var Carros = await _carroService.GetCarroById(id);
            return View("Editar", Carros);
        }

        public async Task<IActionResult> UpdateAsync(string marca, string modelo, string placa, string id)
        {
            await _carroService.UpdatetCarros(marca, modelo, placa, id);
            return RedirectToAction("Index");
        }
    }
}
