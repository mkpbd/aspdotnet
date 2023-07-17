using ShareKarnel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aggregates
{
    public class Employee : Entity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DatetHired { get; set; }
        public Guid InternalEmployeeId { get; set; }

        public Employee(int Id,  string Name, DateTime DatetHired, Guid interalEmployeeId) : base(Id)
        {
            this.Id = Id;
            this.Name = Name;
            this.InternalEmployeeId = interalEmployeeId;
        }


    }
}
