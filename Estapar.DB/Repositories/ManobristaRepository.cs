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
    public class ManobristaRepository : RepositoryBase<ManobristaModel>, IManobristaRepository
    {
        public ManobristaRepository(RepositoryConfiguration config)
            : base(config)
        {
        }

        public async Task<IEnumerable<ManobristaModel>> GetManobristas()
        {
            var query = await GetType().GetContentAsync(SqlFileConstants.GET_MANOBRISTAS);
            IEnumerable<ManobristaModel> retorno = (await QueryAsync(query));
            return retorno;
        }

        public async Task InsertManobristas(ManobristaModel m)
        {
            var query = await GetType().GetContentAsync(SqlFileConstants.INSERT_MANOBRISTAS);
            var param = new DynamicParameters(new { Nome = m.MNB_NOME, Cpf = m.MNB_CPF, Nasc = m.MNB_NASCIMENTO });
            await Execute(query, param);
        }

        public async Task DeleteManobristas(string id)
        {
            var query = await GetType().GetContentAsync(SqlFileConstants.DELETE_MANOBRISTAS);
            var param = new DynamicParameters(new { Id = id });
            await Execute(query, param);
        }

        public async Task<ManobristaModel> GetManobristaById(string id)
        {
            string query = await GetType().GetContentAsync(SqlFileConstants.GET_MANOBRISTA_BY_ID);
            DynamicParameters param = new DynamicParameters(new { Id = id });
            return await QuerySingleAsync(query, param);
        }

        public async Task UpdatetManobristas(ManobristaModel m)
        {
            var query = await GetType().GetContentAsync(SqlFileConstants.UPDATE_MANOBRISTAS);
            var param = new DynamicParameters(new { Nome = m.MNB_NOME, Cpf = m.MNB_CPF, Nasc = m.MNB_NASCIMENTO, Id = m.MNB_ID });
            await Execute(query, param);
        }
    }
}
