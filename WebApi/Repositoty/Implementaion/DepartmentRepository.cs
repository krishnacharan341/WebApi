using Microsoft.EntityFrameworkCore;
using WebApi.data;
using WebApi.Model;
using WebApi.Repositoty.Interface;

namespace WebApi.Repositoty.Implementaion
{
    public class DepartmentRepository : IDepartmentRepository
    {

        private readonly ApiDbContext _appDBContext;
        public DepartmentRepository(ApiDbContext context)
        {
            _appDBContext = context ??
                throw new ArgumentNullException(nameof(context));
        }

        

        public async Task<IEnumerable<Department>> GetDepartment()
        {
            return await _appDBContext.Department.ToListAsync();
        }

        public async Task<Department> GetDepartmentByID(int ID)
        {
            return await _appDBContext.Department.FindAsync(ID);
        }

        public async Task<Department> InsertDepartment(Department objDepartment)
        {
            _appDBContext.Department.Add(objDepartment);
            await _appDBContext.SaveChangesAsync();
            return objDepartment;
        }

        public async Task<Department> UpdateDepartment(Department objDepartment)
        {
            _appDBContext.Entry(objDepartment).State = EntityState.Modified;
            await _appDBContext.SaveChangesAsync();
            return objDepartment;
        }
        public bool DeleteDepartment(int ID)
        {
            bool result = false;
            var department = _appDBContext.Department.Find(ID);
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
