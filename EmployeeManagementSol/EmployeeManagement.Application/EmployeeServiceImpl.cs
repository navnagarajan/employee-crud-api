using EmployeeManagement.Common;
using EmployeeManagement.Common.Models;
using EmployeeManagement.Context.Database;
using EmployeeManagement.Context.Employee;
using Microsoft.Extensions.Logging;

namespace EmployeeManagement.Application
{
    public class EmployeeServiceImpl : BaseUtility, IEmployeeService
    {
        private readonly ILogger<EmployeeServiceImpl> _logger;
        private readonly IDatabaseManager _databaseManager;
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeServiceImpl(ILogger<EmployeeServiceImpl> logger, IDatabaseManager databaseManager, IEmployeeRepository employeeRepository)
        {
            _logger = logger;
            _databaseManager = databaseManager;
            _employeeRepository = employeeRepository;
        }

        public async Task<ResultModel<List<EmployeeModel>>> AllEmployee()
        {
            using var connection = _databaseManager.Connection;
            var result = await _employeeRepository.AllEmployee(connection);

            var models = new List<EmployeeModel>();

            if (result?.Any() == true)
            {
                models = Copy<List<EmployeeEntity>, List<EmployeeModel>>(result.ToList());
            }

            return models?.Any() == true ? OkayResult(models) : NoContentResult<List<EmployeeModel>>();
        }

        public async Task<ResultModel<bool>> ManageEmployee(string pUserId, EmployeeModel pModel)
        {
            ResultModel<bool> result = BadRequestErrorResult("Default");

            try
            {
                _logger.LogInformation($"Working on ManageEmployee. pUserId: {pUserId}, pModel: {Serialize(pModel)}");

                if (IsValid(pUserId) != true)
                {
                    _logger.LogWarning("Call received with invalid user id.");
                    return result = BadRequestErrorResult();
                }

                if (pModel == null)
                {
                    _logger.LogWarning("Call received with invalid payload");
                    return result = BadRequestErrorResult();
                }

                if (IsValid(pModel?.FirstName) != true)
                {
                    _logger.LogDebug("Invalid first name!");
                    return result = ConflictResult("Firstname required!");
                }

                if (IsValid(pModel?.Email) != true)
                {
                    _logger.LogDebug("Invalid email!");
                    return result = ConflictResult("Email required!");
                }

                if (IsValidMobile(pModel?.Mobile))
                {
                    _logger.LogDebug("Invalid email!");
                    return result = ConflictResult("Mobile required!");
                }

                if (IsValidDate(pModel?.DateOfBirth) != true)
                {
                    _logger.LogDebug("Invalid email!");
                    return result = ConflictResult("Date of birth required!");
                }

                var entity = Copy<EmployeeModel, EmployeeEntity>(pModel!);

                entity.LastUpdatedBy = pUserId;
                entity.LastUpdatedOn = Now;

                using var connection = _databaseManager.Connection;
                using var transaction = connection.BeginTransaction();

                var employeeId = await _employeeRepository.AddNew(entity, connection, transaction);

                if (employeeId < 1)
                {
                    _logger.LogWarning($"Failed to create new employee with following data : {Serialize(entity)}");
                    return result = NotModifiedResult();
                }

                transaction.Commit();
                _logger.LogInformation($"Employee '{pModel!.FullName}' added with id {employeeId}");
                return result = OkayResult($"Employee '{pModel!.FullName}' added successfully");
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, $"Error on ManageEmployee. pUserId: {pUserId}, pModel: {Serialize(pModel)}");
                return InternalServerErrorResult();
            }
            finally
            {
                _logger.LogInformation($"Request completed with following response: {Serialize(result)}");
            }
        }
    }
}
