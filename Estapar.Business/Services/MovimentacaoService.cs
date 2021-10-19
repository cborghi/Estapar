using Estapar.Interfaces.Repositories;
using Estapar.Interfaces.Services;
using Estapar.Model.ViewModel;
using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estapar.Business.Services
{
    public class MovimentacaoService : IMovimentacaoService
    {
        private readonly IMovimentacaoRepository _movimentacaoRepository;

        public MovimentacaoService(IMovimentacaoRepository movimentacaoRepository)
        {
            _movimentacaoRepository = movimentacaoRepository;
        }

        public async Task<IEnumerable<MovimentacaoViewModel>> GetMovimentacao()
        {
            var m = await _movimentacaoRepository.GetMovimentacao();
            var mappedList = new List<MovimentacaoViewModel>();
            m.ToList().ForEach(e => mappedList.Add(new MovimentacaoViewModel().PopulateWith(e)));
            return mappedList;
        }

        public async Task UpdateMovimentacaoAsync(string id, string idManobrista) => await _movimentacaoRepository.UpdateMovimentacaoAsync(id, idManobrista);
    }
}
