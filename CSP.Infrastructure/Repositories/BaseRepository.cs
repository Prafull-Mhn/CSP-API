using CSP.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSP.Infrastructure.Repositories
{
    public abstract class BaseRepository
    {

        protected readonly IDatabaseConnection _databaseConnection;

        protected BaseRepository(IDatabaseConnection databaseConnection)
        {
            _databaseConnection = databaseConnection;
        }

        protected IDbConnection CreateConnection()
        {
            return _databaseConnection.CreateConnection();
        }
    }
}
