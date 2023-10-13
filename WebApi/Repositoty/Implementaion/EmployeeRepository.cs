using Microsoft.EntityFrameworkCore;
using WebApi.data;
using WebApi.Model;
using WebApi.Repositoty.Interface;

namespace WebApi.Repositoty.Implementaion
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApiDbContext _appDBContext;
        public EmployeeRepository(ApiDbContext context)
        {
            _appDBContext = context ??
                throw new ArgumentNullException(nameof(context));
        }

      

        public async Task<Employee> GetEmployeeByID(int ID)
        {
            return await _appDBContext.Employee.FindAsync(ID);
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await _appDBContext.Employee.ToListAsync();
        }

        public async Task<Employee> InsertEmployee(Employee objEmployee)
        {
            _appDBContext.Employee.Add(objEmployee);
            await _appDBContext.SaveChangesAsync();
            return objEmployee;
        }

        public async Task<Employee> UpdateEmployee(Employee objEmployee)
        {
            _appDBContext.Entry(objEmployee).State = EntityState.Modified;
            await _appDBContext.SaveChangesAsync();
            return objEmployee;
        }

        public bool DeleteEmployee(int ID)
        {
            bool result = false;
            var department = _appDBContext.Employee.Find(ID);
            if (department != null)
            {
                _appDBContext.Entry(department).State = EntityState.Deleted;
                _appDBContext.SaveChanges();
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }
    }
}
