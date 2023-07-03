using EmployeeManagement.Common.Models;

namespace EmployeeManagement.Context.Employee
{
    public interface IEmployeeService
    {
        public Task<ResultModel<List<EmployeeModel>>> AllEmployee();
        public Task<ResultModel<bool>> ManageEmployee(string pUserId, EmployeeModel pModel);
    }
}
