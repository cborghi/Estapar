using Estapar.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Estapar.Interfaces.Services
{
    public interface IMovimentacaoService
    {
        Task<IEnumerable<MovimentacaoViewModel>> GetMovimentacao();
        Task UpdateMovimentacaoAsync(string id, string idManobrista);
    }
}
