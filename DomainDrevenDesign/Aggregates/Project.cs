using ShareKarnel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aggregates
{
    internal class Project : Entity<int>
    {
        public Project(int id,string projectName, DateTime startDate, DateTime endDate, Customer customer, DateTime complteDate, bool isComplete) : base(id)
        {
            ProjectName = projectName;
            StartDate = startDate;
            EndDate = endDate;
            Customer = customer;
            ComplteDate = complteDate;
            IsComplete = isComplete;
        }


        public string ProjectName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Customer Customer { get; set; }
        public DateTime ComplteDate { get; set; }
        public bool IsComplete { get; set; }

        public int HeadCountCap { get; set; }

        public List<Employee> Members { get; set; } = new List<Employee>();

    }
}
