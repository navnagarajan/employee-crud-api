using System.Data;

namespace EmployeeManagement.Context.Employee
{
    public interface IEmployeeRepository
    {
        Task<IReadOnlyList<EmployeeEntity>> AllEmployee(IDbConnection pConnection);
        Task<long> AddNew(EmployeeEntity pEnity, IDbConnection pConnection, IDbTransaction pTransaction);
        Task<bool> UpdateEmployee(EmployeeEntity pEnity, IDbConnection pConnection, IDbTransaction pTransaction);
    }
}
