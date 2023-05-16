using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDiagram.Association.Association3
{
    internal class Course
    {
        public string Name { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}
