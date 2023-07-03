namespace EmployeeManagement.Context.Employee
{
    public class EmployeeModel
    {
        public long EmployeeId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string? LastName { get; set; } = null;
        public string Email { get; set; } = string.Empty;
        public string Mobile { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; } = DateTime.MinValue;
        public bool IsActive { get; set; }
        public bool? IsDeleted { get; set; }

        public string FullName
        {
            get
            {
                return ((string.IsNullOrWhiteSpace(FirstName) ? string.Empty : FirstName) + " " + (string.IsNullOrWhiteSpace(LastName) ? string.Empty : LastName)).Trim();
            }
        }
    }
}
