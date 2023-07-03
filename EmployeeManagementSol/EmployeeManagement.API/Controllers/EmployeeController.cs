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
            var result = await _employeeService.AllEmployee();
            return Result(result);
        }

        [HttpPost, Route("manage")]
        public async Task<IActionResult> Manage(EmployeeModel pModel)
        {
            if (pModel == null)
            {
                return BadRequest();
            }

            var result = await _employeeService.ManageEmployee(UserId, pModel);
            return Result(result);
        }
    }
}
