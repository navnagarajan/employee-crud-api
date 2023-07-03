using EmployeeManagement.Common;
using EmployeeManagement.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.API.Controllers
{
    public class BaseController : ControllerBase
    {

        public string UserId { get => "system_admin"; }

        [NonAction]
        public IActionResult Result<T>(ResultModel<T> pResult)
        {
            return WriteResponse(pResult.Code, pResult.Data, pResult.Message);
        }

        [NonAction]
        public IActionResult Result(ResultModel<bool> pResult)
        {
            if (pResult?.Status != true || pResult?.Data != true)
            {
                return BadRequest(string.IsNullOrWhiteSpace(pResult?.Message) ? "Bad request!" : pResult.Message);
            }

            return WriteResponse(pResult.Code, pResult.Data, pResult.Message);
        }

        private IActionResult WriteResponse<T>(ResultCode pResultCode, T? pData = default, string? pMessage = null)
        {

            switch (pResultCode)
            {
                case Common.ResultCode.Status200OK:
                    return StatusCode(StatusCodes.Status200OK, pData);

                case Common.ResultCode.Status500InternalServerError:
                    return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");

                case Common.ResultCode.Status409Conflict:
                    return StatusCode(StatusCodes.Status409Conflict, pMessage ?? "Conflict");

                case Common.ResultCode.Status304NotModified:
                    return StatusCode(StatusCodes.Status304NotModified);

                case Common.ResultCode.Status400BadRequest:
                    return StatusCode(StatusCodes.Status400BadRequest, pMessage ?? "Bad Request!");

                case Common.ResultCode.Status204NoContent:
                    return StatusCode(StatusCodes.Status204NoContent, pMessage ?? "No contents");

                case Common.ResultCode.Status404NotFound:
                    return StatusCode(StatusCodes.Status404NotFound, pMessage ?? "Not found");

                default:
                    return StatusCode(StatusCodes.Status409Conflict, "Some conflicts occurred");
    }
}
    }
}
