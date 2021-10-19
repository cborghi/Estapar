using Estapar.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estapar.UI.Controllers
{
    public class MovimentacaoController : Controller
    {
        private readonly IMovimentacaoService _movimentacaoService;
        private readonly IManobristaService _manobristaService;

        public MovimentacaoController(IMovimentacaoService movimentacaoService,
                                    IManobristaService manobristaService)
        {
            _movimentacaoService = movimentacaoService;
            _manobristaService = manobristaService;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var lstManobristas = await _manobristaService.GetManobristas();

            List<SelectListItem> liManobristas = new List<SelectListItem>();
            foreach (var item in lstManobristas)
            {
                var l = new SelectListItem
                {
                    Text = item.MNB_NOME,
                    Value = item.MNB_ID.ToString()
                };
                liManobristas.Add(l);
            }
            ViewBag.Manobristas = liManobristas;

            var lstMovimentacao = await _movimentacaoService.GetMovimentacao();

            return View(lstMovimentacao);
        }

        public async Task<IActionResult> UpdateMovimentacaoAsync(string id, string idManobrista)
        {
            await _movimentacaoService.UpdateMovimentacaoAsync(id, idManobrista);
            return RedirectToAction("Index");
        }
    }
}
