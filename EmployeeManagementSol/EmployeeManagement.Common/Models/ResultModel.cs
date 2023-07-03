namespace EmployeeManagement.Common.Models
{
    /// <summary>
    /// Result model
    /// </summary>
    /// <typeparam name="T">Result data type</typeparam>
    public class ResultModel<T>
    {
        // Read only properies
        private readonly bool _status;
        private readonly T? _data;
        private readonly ResultCode _code;
        private readonly string _message;

        /// <summary>
        /// Result Status
        /// </summary>
        public bool Status => _status;

        /// <summary>
        /// Result Data
        /// </summary>
        public T? Data => _data;

        /// <summary>
        /// Result Code. Refer <see cref="Code"/> for various result code types
        /// </summary>
        public ResultCode Code => _code;

        /// <summary>
        /// Result Message
        /// </summary>
        public string Message => _message;

        public ResultModel(bool status, T? data, ResultCode code, string message)
        {
            _status = status;
            _data = data;
            _code = code;
            _message = message;
        }
    }
}
