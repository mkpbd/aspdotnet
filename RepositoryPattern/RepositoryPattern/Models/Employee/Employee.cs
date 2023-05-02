using System.ComponentModel.DataAnnotations;

namespace RepositoryPattern.Models.Employee
{
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int? Salary { get; set; }
        public string Dept { get; set; }
    }
}
