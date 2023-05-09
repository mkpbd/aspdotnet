using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Domin.Entities.CourseEntites
{
    public class Course : IEntity<Guid>
    {
        [Key]
        public Guid Id { get ; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime EndDate { get; set; } = DateTime.Now;
        public int Fee { get; set; }
    }
}
