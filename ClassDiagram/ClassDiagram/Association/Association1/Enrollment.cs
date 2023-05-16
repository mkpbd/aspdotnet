using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDiagram.Association.Association1
{
    internal class Enrollment
    {

        public Student Student { get; set; }
        public Course Course { get; set; }
        public int SectionNumber { get; set; }
        public double Grade { get; set; }

        public void AddStudent(Student student)
        {
            Student = student;
        }

        public void RemoveStudent(Student student)
        {
            Student = null;
        }

        public double GetGrade()
        {
            return Grade;
        }


        public string GetFunnyGrade()
        {
            if (this.Grade >= 90)
            {
                return "A+ (You're a genius!)";
            }
            else if (this.Grade >= 80)
            {
                return "A (You're doing great!)";
            }
            else if (this.Grade >= 70)
            {
                return "B (You're doing okay!)";
            }
            else if (this.Grade >= 60)
            {
                return "C (You're passing!)";
            }
            else
            {
                return "F (You failed! Better luck next time!)";
            }
        }
    }
}
