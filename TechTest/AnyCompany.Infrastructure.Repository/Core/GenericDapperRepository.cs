using AnyCompany.Infrastructure.Repository;
using AnyCompany.Infrastructure.Repository.Core;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AnyCompany.Core
{
    public class GenericDapperRepository<T> : IGenericDapperRepository<T>
        where T : class
    {
        private readonly IDapperDbContext _dbContext;

        private readonly ConnectionType _connectionType;

        public GenericDapperRepository(IDapperDbContext dbContext,ConnectionType connectionType)
        {
            _dbContext = dbContext;

            _connectionType = connectionType;
        }

        public async Task<int> ExecuteAsync(string sql, object param = null, IDbTransaction transaction = null, CancellationToken cancellationToken = default)
        {
            return await _dbContext.CreateConnection(_connectionType).ExecuteAsync(sql, param, transaction);
        }

        public IEnumerable<T> Query(string sql, object param = null, IDbTransaction transaction = null, CommandType commandType = CommandType.Text, CancellationToken cancellationToken = default)
        {
            return _dbContext.CreateConnection(_connectionType).Query<T>(sql, param, transaction, commandType: commandType).AsEnumerable();
        }

        public async Task<T> QueryFirstOrDefaultAsync(string sql, object param = null, IDbTransaction transaction = null, CancellationToken cancellationToken = default)
        {
            return await _dbContext.CreateConnection(_connectionType).QueryFirstOrDefaultAsync<T>(sql, param, transaction);
        }
    }
}
