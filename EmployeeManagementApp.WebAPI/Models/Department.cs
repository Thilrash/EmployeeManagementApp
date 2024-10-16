using System.Text.Json.Serialization;

namespace EmployeeManagementApp.WebAPI.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; } = string.Empty;

        // Navigation prop
        [JsonIgnore]
        public ICollection<Employee>? Employees { get; set; }
    }
}