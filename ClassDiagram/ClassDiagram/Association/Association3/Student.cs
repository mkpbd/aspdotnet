using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDiagram.Association.Association3
{
    internal class Student
    {
        public string Name { get; set; }
        public ICollection<Course> EnrolledCourses { get; set; }
    }
}
