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
    public class CarroRepository : RepositoryBase<CarroModel>, ICarroRepository
    {
        public CarroRepository(RepositoryConfiguration config)
            : base(config)
        {
        }

        public async Task<IEnumerable<CarroModel>> GetCarros()
        {
            var query = await GetType().GetContentAsync(SqlFileConstants.GET_CARROS);
            IEnumerable<CarroModel> retorno = (await QueryAsync(query));
            return retorno;
        }

        public async Task InsertCarros(CarroModel m)
        {
            var query = await GetType().GetContentAsync(SqlFileConstants.INSERT_CARROS);
            var param = new DynamicParameters(new { Marca = m.CRR_MARCA, Modelo = m.CRR_MODELO, Placa = m.CRR_PLACA });
            await Execute(query, param);
        }

        public async Task DeleteCarros(string id)
        {
            var query = await GetType().GetContentAsync(SqlFileConstants.DELETE_CARROS);
            var param = new DynamicParameters(new { Id = id });
            await Execute(query, param);
        }

        public async Task<CarroModel> GetCarroById(string id)
        {
            string query = await GetType().GetContentAsync(SqlFileConstants.GET_CARRO_BY_ID);
            DynamicParameters param = new DynamicParameters(new { Id = id });
            return await QuerySingleAsync(query, param);
        }

        public async Task UpdatetCarros(CarroModel m)
        {
            var query = await GetType().GetContentAsync(SqlFileConstants.UPDATE_CARROS);
            var param = new DynamicParameters(new { Marca = m.CRR_MARCA, Modelo = m.CRR_MODELO, Placa = m.CRR_PLACA, Id = m.CRR_ID });
            await Execute(query, param);
        }
    }
}
