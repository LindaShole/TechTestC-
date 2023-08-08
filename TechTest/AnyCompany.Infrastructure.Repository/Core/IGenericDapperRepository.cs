using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AnyCompany.Core
{
    public interface IGenericDapperRepository<T>
        where T : class
    {
        Task<T> QueryFirstOrDefaultAsync(string sql, object param = null, IDbTransaction transaction = null, CancellationToken cancellationToken = default);

        Task<int> ExecuteAsync(string sql, object param = null, IDbTransaction transaction = null, CancellationToken cancellationToken = default);

        IEnumerable<T> Query(string sql, object param = null, IDbTransaction transaction = null, CommandType commandType = CommandType.Text, CancellationToken cancellationToken = default);
    }
}
