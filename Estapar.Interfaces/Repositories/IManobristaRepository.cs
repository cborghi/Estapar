using Estapar.Model.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Estapar.Interfaces.Repositories
{
    public interface IManobristaRepository
    {
        Task<IEnumerable<ManobristaModel>> GetManobristas();
        Task InsertManobristas(ManobristaModel m);
        Task DeleteManobristas(string id);
        Task<ManobristaModel> GetManobristaById(string id);
        Task UpdatetManobristas(ManobristaModel m);
    }
}
