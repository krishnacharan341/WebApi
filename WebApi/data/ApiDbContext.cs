using Microsoft.EntityFrameworkCore;
using WebApi.Model;

namespace WebApi.data
{
    public class ApiDbContext:DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) { }
        public DbSet<Department> Department
        {
            get;
            set;
        }
        public DbSet<Employee> Employee
        {
            get;
            set;
        }
    }
}
