using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Domin.Entities
{
    public class Course : IEntity<Guid>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int Fee { get; set; }

        public bool IsPaid { get; set; }
    }
}
