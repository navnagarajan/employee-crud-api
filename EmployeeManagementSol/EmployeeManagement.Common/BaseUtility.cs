using EmployeeManagement.Common.Models;
using Newtonsoft.Json;

namespace EmployeeManagement.Common
{
    /// <summary>
    /// Basic Utility class
    /// </summary>
    public class BaseUtility
    {
        public static T Copy<S, T>(S pSource) => ExpressMapper.Mapper.Map<S, T>(pSource);

        public string Serialize(object? pData) => pData == null ? "NULL" : JsonConvert.SerializeObject(pData);

        public bool IsValid(params string?[] pArgs)
        {
            return !(pArgs?.Any(A => string.IsNullOrWhiteSpace(A?.Trim())) != false);
        }

        public bool IsValidMobile(string? pMobile)
        {
            return !((pMobile?.Length ?? -1) < 10 || pMobile!.Any(A => char.IsDigit(A) != false));
        }

        public bool IsValidDate(DateTime? pDateTime)
        {
            return !(pDateTime == null || pDateTime == DateTime.MinValue || pDateTime == DateTime.MaxValue);
        }

        public DateTime Now { get => DateTime.UtcNow; }

        public ResultModel<bool> OkayResult(string pMessage = "OKAY") => new(true, true, ResultCode.Status200OK, pMessage);
        public ResultModel<T> OkayResult<T>(T pData, string pMessage = "OKAY") => new(true, pData, ResultCode.Status200OK, pMessage);

        public ResultModel<bool> NotModifiedResult(string pMessage = "NOT_MODIFIED") => new(false, false, ResultCode.Status304NotModified, pMessage);
        public ResultModel<T> NotModifiedResult<T>(string pMessage = "NOT_MODIFIED") => new(false, default, ResultCode.Status304NotModified, pMessage);

        public ResultModel<bool> NoContentResult(string pMessage = "NO_CONTENT") => new(false, false, ResultCode.Status204NoContent, pMessage);
        public ResultModel<T> NoContentResult<T>(string pMessage = "NO_CONTENT") => new(false, default, ResultCode.Status204NoContent, pMessage);

        public ResultModel<bool> ConflictResult(string pMessage = "CONFLICT") => new(false, false, ResultCode.Status409Conflict, pMessage);
        public ResultModel<T> ConflictResult<T>(string pMessage = "CONFLICT") => new(false, default, ResultCode.Status409Conflict, pMessage);

        public ResultModel<bool> InternalServerErrorResult(string pMessage = "INTERNAL_SERVER_ERROR") => new(false, false, ResultCode.Status500InternalServerError, pMessage);
        public ResultModel<T> InternalServerErrorResult<T>(string pMessage = "INTERNAL_SERVER_ERROR") => new(false, default, ResultCode.Status500InternalServerError, pMessage);

        public ResultModel<bool> BadRequestErrorResult(string pMessage = "BAD_REQUEST_ERROR") => new(false, false, ResultCode.Status400BadRequest, pMessage);
        public ResultModel<T> BadRequestErrorResult<T>(string pMessage = "BAD_REQUEST_ERROR") => new(false, default, ResultCode.Status400BadRequest, pMessage);
    }
}
