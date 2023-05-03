using System.ComponentModel.DataAnnotations;

namespace MVCProjectBootsrping.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
            
        public int EmployeeId { get; set; }
        public int EmployeeName { get; set; }
        public int EmployeeAge { get; set; }

    }
}
