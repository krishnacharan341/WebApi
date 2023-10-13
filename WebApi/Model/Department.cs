using System.ComponentModel.DataAnnotations;

namespace WebApi.Model
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }

        public string DepartmentName { get; set; }
    }
}
