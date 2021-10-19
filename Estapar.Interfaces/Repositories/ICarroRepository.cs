using Estapar.Model.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Estapar.Interfaces.Repositories
{
    public interface ICarroRepository
    {
        Task<IEnumerable<CarroModel>> GetCarros();
        Task InsertCarros(CarroModel m);
        Task DeleteCarros(string id);
        Task<CarroModel> GetCarroById(string id);
        Task UpdatetCarros(CarroModel m);
    }
}
