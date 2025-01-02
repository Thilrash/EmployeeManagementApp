using System.Text.Json.Serialization;

namespace EmployeeManagementApp.WebAPI.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int DepartmentId { get; set; } // Foreign key
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;

        // Navigation property
        [JsonIgnore]
        public Department? Department { get; set; }
    }
}
