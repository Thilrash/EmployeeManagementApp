using EmployeeManagementApp.WebAPI.Data;
using EmployeeManagementApp.WebAPI.Models;
using EmployeeManagementApp.WebAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementApp.WebAPI.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AppDbContext _context;

        public DepartmentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Department> AddDepartmentAsync(Department department)
        {
            _context.Departments.Add(department);
            await _context.SaveChangesAsync();
            return department;
        }

        public async Task<bool> DeleteDepartmentAsync(int id)
        {
            var department = await _context.Departments.FindAsync(id);

            if (department is null) { return false; }

            _context.Departments.Remove(department);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Department>> GetAllDepartmentAsync()
        {
            return await _context.Departments.Include(d => d.Employees).ToListAsync();
        }

        public async Task<Department?> GetDepartmentByIdAsync(int id)
        {
            return await _context.Departments.Include(d => d.Employees).FirstOrDefaultAsync(d => d.DepartmentId == id);
        }

        public async Task<Department?> UpdateDepartmentAsync(int id, Department department)
        {
            var existingDepartment = await _context.Departments.FindAsync(id);

            if (existingDepartment is null) { return null; }

            existingDepartment.Name = department.Name;

            await _context.SaveChangesAsync();
            return existingDepartment;
        }
    }
}
