using Estapar.Model.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Estapar.Interfaces.Repositories
{
    public interface IMovimentacaoRepository
    {
        Task<IEnumerable<MovimentacaoModel>> GetMovimentacao();
        Task UpdateMovimentacaoAsync(string id, string idManobrista);
    }
}
