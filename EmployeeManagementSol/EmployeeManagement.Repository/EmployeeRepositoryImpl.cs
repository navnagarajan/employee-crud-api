using Dapper;
using EmployeeManagement.Common;
using EmployeeManagement.Context.Employee;
using EmployeeManagement.Repository.QueryConstants;
using Microsoft.Extensions.Logging;
using System.Data;

namespace EmployeeManagement.Repository
{
    public class EmployeeRepositoryImpl : BaseUtility, IEmployeeRepository
    {
        private readonly ILogger<EmployeeRepositoryImpl> _logger;

        public EmployeeRepositoryImpl(ILogger<EmployeeRepositoryImpl> logger)
        {
            _logger = logger;
        }

        public async Task<long> AddNew(EmployeeEntity pEnity, IDbConnection pConnection, IDbTransaction pTransaction)
        {
            try
            {
                var lastInsertedId = await pConnection.ExecuteScalarAsync<long>(EmployeeQuery.AddNewEmployee, pEnity, pTransaction);
                return lastInsertedId;
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, $"Error on AddNew. Entity: {Serialize(pEnity)}");
                return -1;
            }
        }

        public async Task<bool> UpdateEmployee(EmployeeEntity pEnity, IDbConnection pConnection, IDbTransaction pTransaction)
        {
            try
            {
                var modifiedRecordCount = await pConnection.ExecuteAsync(EmployeeQuery.UpdateEmployee, pEnity, pTransaction);
                return modifiedRecordCount == 1;
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, $"Error on UpdateEmployee. Entity: {Serialize(pEnity)}");
                return false;
            }
        }

        public async Task<IReadOnlyList<EmployeeEntity>> AllEmployee(IDbConnection pConnection)
        {
            try
            {
                var records = await pConnection.QueryAsync<EmployeeEntity>(EmployeeQuery.Employees);
                return records?.Any() == true ? records.ToList() : new List<EmployeeEntity>();
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Error on AllEmployee");
                return new List<EmployeeEntity>();
            }
        }
    }
}
