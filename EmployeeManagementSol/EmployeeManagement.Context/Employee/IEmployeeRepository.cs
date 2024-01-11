using EmployeeManagement.Common.Models;
using System.Data;

namespace EmployeeManagement.Context.Employee
{
    public interface IEmployeeRepository
    {
        Task<IReadOnlyList<EmployeeEntity>> AllEmployee(IDbConnection pConnection);
        Task<long> AddNew(EmployeeEntity pEnity, IDbConnection pConnection, IDbTransaction pTransaction);
        Task<bool> UpdateEmployee(EmployeeEntity pEnity, IDbConnection pConnection, IDbTransaction pTransaction);
        Task<ResultModel<string>> LastEmployeeNumber(IDbConnection pConnection);
        Task<ResultModel<EmployeeEntity>> GetByEmail(string pEmail, IDbConnection pConnection);
        Task<ResultModel<EmployeeEntity>> GetByMobile(string pMobile, IDbConnection pConnection);
    }
}
