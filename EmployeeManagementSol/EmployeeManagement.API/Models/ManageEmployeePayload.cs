namespace EmployeeManagement.API.Models
{
    public class ManageEmployeePayload
    {
        public long EmployeeId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string? LastName { get; set; } = null;
        public string Email { get; set; } = string.Empty;
        public string Mobile { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; } = DateTime.MinValue;
        public bool IsActive { get; set; }
    }
}
