using Dapper;
using Estapar.DB.Extentions;
using Estapar.DB.Scripts;
using Estapar.Interfaces.Repositories;
using Estapar.Model.ValueObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Estapar.DB.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected SqlConnection _sqlConn;
        private SqlTransaction _sqlTrans;
        private readonly string _connectionString;
        private readonly RepositoryConfiguration _config;

        protected RepositoryBase(RepositoryConfiguration config)
        {
            _config = config;
            _sqlConn = new SqlConnection(config.ConnectionString);
            _connectionString = config.ConnectionString;
        }

        public virtual async Task BeginTransaction()
        {
            await OpenConnectionAsync();
            _sqlTrans = _sqlConn.BeginTransaction();
        }

        public virtual async Task OpenConnectionAsync()
        {
            if (string.IsNullOrWhiteSpace(_sqlConn.ConnectionString) && !string.IsNullOrWhiteSpace(_connectionString))
                _sqlConn.ConnectionString = _connectionString;

            if (_sqlConn.State == ConnectionState.Closed)
            {
                _sqlConn = new SqlConnection(_config.ConnectionString);
                await _sqlConn.OpenAsync();
            }
        }

        public virtual async Task DisposeConnectionAsync() => await _sqlConn.DisposeAsync();

        public virtual void CommitTransaction()
        {
            if (_sqlTrans != null)
                _sqlTrans.Commit();
        }

        public virtual void RoolbackTransaction()
        {
            if (_sqlTrans != null)
                _sqlTrans.Rollback();
        }

        public virtual void DisposeTransaction()
        {
            _sqlTrans.Dispose();
            _sqlTrans = null;
        }

        public void Dispose()
        {
            _sqlConn?.Dispose();
            _sqlTrans?.Dispose();
        }

        public virtual async Task<T> QuerySingleAsync(string query, DynamicParameters parameters = null)
        {
            _sqlConn = new SqlConnection(_config.ConnectionString);
            await OpenConnectionAsync();
            await using var conn = _sqlConn;

            return await conn.QuerySingleAsync<T>(query, parameters);
        }

        public virtual async Task<TKey> QuerySingleAsync<TKey>(string query, DynamicParameters parameters = null)
        {
            _sqlConn = new SqlConnection(_config.ConnectionString);
            await OpenConnectionAsync();
            await using var conn = _sqlConn;

            return await conn.QuerySingleAsync<TKey>(query, parameters);
        }

        public virtual async Task<IEnumerable<T>> QueryAsync(string query, DynamicParameters parameters = null)
        {
            _sqlConn = new SqlConnection(_config.ConnectionString);
            await OpenConnectionAsync();
            await using var conn = _sqlConn;

            return await conn.QueryAsync<T>(query, parameters);
        }

        public virtual async Task<IEnumerable<TEntity>> QueryAsync<TEntity>(string query, DynamicParameters parameters = null)
        {
            _sqlConn = new SqlConnection(_config.ConnectionString);
            await OpenConnectionAsync();
            await using var conn = _sqlConn;

            return await conn.QueryAsync<TEntity>(query, parameters);
        }

        public virtual async Task CallStoredProcedureAsync(string name, DynamicParameters parameters = null)
        {
            _sqlConn = new SqlConnection(_config.ConnectionString);
            await OpenConnectionAsync();
            await using var conn = _sqlConn;

            await conn.ExecuteAsync(name, parameters, commandType: CommandType.StoredProcedure);
        }

        public virtual async Task<int> Execute(string query, DynamicParameters parameters = null)
        {
            await OpenConnectionAsync();
            await using var conn = _sqlConn;

            return await conn.ExecuteAsync(query, parameters);
        }

        public async Task<int> ExecuteQuery(string query, DynamicParameters parameters = null)
        {
            _sqlConn = new SqlConnection(_config.ConnectionString);
            await OpenConnectionAsync();
            await using var conn = _sqlConn;

            return await conn.QuerySingleAsync<int>(query, parameters);
        }

        protected virtual async Task<int> Transaction(T entity, string arquivo)
        {
            var query = await GetType().GetContentAsync(arquivo);
            var param = new DynamicParameters(entity);
            var result = await Execute(query, param);

            return result;
        }

        protected virtual async Task Transaction(IEnumerable<T> entities, string arquivo)
        {
            var query = await GetType().GetContentAsync(arquivo);
            var param = new DynamicParameters(entities);

            await Execute(query, param);
        }
    }
}
