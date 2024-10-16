using EmployeeManagementApp.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementApp.WebAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Config one to many relationship
            modelBuilder.Entity<Department>()
                .HasMany(d => d.Employees)
                .WithOne(e => e.Department)
                .HasForeignKey(e => e.DepartmentId);

            // Seed data

            // Dept
            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentId = 1, Name = "Human Resources" },
                new Department { DepartmentId = 2, Name = "IT" },
                new Department { DepartmentId = 3, Name = "Finance" }
            );

            // Emp
            modelBuilder.Entity<Employee>().HasData(
                new Employee { EmployeeId = 1, FirstName = "John", LastName = "Doe", Email = "john.doe@email.com", DepartmentId = 1 },
                new Employee { EmployeeId = 2, FirstName = "Alice", LastName = "Smith", Email = "alice.smith@email.com", DepartmentId = 2 }
            );
        }
    }
}
