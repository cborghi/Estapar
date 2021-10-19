using Abp.Domain.Uow;
using Dapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Estapar.Interfaces.Repositories
{
    public interface IRepositoryBase<T> : IDisposable
    {
        public Task<int> Execute(string query, DynamicParameters parameters = null);
        public Task<T> QuerySingleAsync(string query, DynamicParameters parameters = null);
        public Task<IEnumerable<T>> QueryAsync(string query, DynamicParameters parameters = null);
        public Task CallStoredProcedureAsync(string name, DynamicParameters parameters = null);

    }
}
