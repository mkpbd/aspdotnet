using System.ComponentModel.DataAnnotations.Schema;

namespace EfCore.Models.Employee
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public int? ManagerId { get; set; }
        [ForeignKey(nameof(ManagerId))]
        public Employee Manager { get; set; }
    }
}
