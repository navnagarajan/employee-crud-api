using EmployeeManagement.API.Models;
using EmployeeManagement.Context.Employee;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : BaseController
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly IEmployeeService _employeeService;

        public EmployeeController(ILogger<EmployeeController> logger, IEmployeeService employeeService)
        {
            _logger = logger;
            _employeeService = employeeService;
        }

        [HttpGet, Route("list")]
        public async Task<IActionResult> AllEmployees()
        {
            _logger.LogInformation($"Requested received: AllEmployees");
            var result = await _employeeService.AllEmployee();
            return Result(result);
        }

        [HttpPost, Route("manage")]
        public async Task<IActionResult> Manage(ManageEmployeePayload pPayload)
        {
            _logger.LogInformation($"Requested received: Manage");
            if (pPayload == null)
            {
                return BadRequest();
            }

            var model = ExpressMapper.Mapper.Map<ManageEmployeePayload, EmployeeModel>(pPayload);
            var result = await _employeeService.ManageEmployee(UserId, model);
            return Result(result);
        }
    }
}
