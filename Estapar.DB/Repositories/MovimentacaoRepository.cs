using Dapper;
using Estapar.DB.Extentions;
using Estapar.DB.Scripts;
using Estapar.Interfaces.Repositories;
using Estapar.Model.Entity;
using Estapar.Model.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Estapar.DB.Repositories
{
    public class MovimentacaoRepository : RepositoryBase<MovimentacaoModel>, IMovimentacaoRepository
    {
        public MovimentacaoRepository(RepositoryConfiguration config)
            : base(config)
        {
        }

        public async Task<IEnumerable<MovimentacaoModel>> GetMovimentacao()
        {
            var query = await GetType().GetContentAsync(SqlFileConstants.GET_MOVIMENTACOES);
            IEnumerable<MovimentacaoModel> retorno = (await QueryAsync(query));
            return retorno;
        }

        public async Task UpdateMovimentacaoAsync(string id, string idManobrista)
        {
            var query = await GetType().GetContentAsync(SqlFileConstants.UPDATE_MOVIMENTACOES);
            var param = new DynamicParameters(new { Id = Convert.ToInt64(id), IdMan = Convert.ToInt32(idManobrista) });
            await Execute(query, param);
        }
    }
}
