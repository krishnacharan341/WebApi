using System.ComponentModel.DataAnnotations;
using WebApi.Model;

namespace WebApi.Repositoty.Interface
{
    public interface IDepartmentRepository 
    {
        Task<IEnumerable<Department>> GetDepartment();
        Task<Department> GetDepartmentByID(int ID);
        Task<Department> InsertDepartment(Department objDepartment);
        Task<Department> UpdateDepartment(Department objDepartment);
        bool DeleteDepartment(int ID);
    }
}
