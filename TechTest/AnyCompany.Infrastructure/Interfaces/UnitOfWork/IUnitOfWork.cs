using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyCompany.Infrastructure.Interfaces.UnitOfWork
{
    public interface IUnitOfWork
    {
        void Commit();

        IDbConnection GetConnection();

        IDbTransaction GetTransaction();

    }
}
