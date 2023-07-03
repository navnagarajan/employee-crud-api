using System.Data;

namespace EmployeeManagement.Context.Database
{
    public interface IDatabaseManager
    {
        IDbConnection Connection { get; }
    }
}
