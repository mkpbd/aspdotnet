using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDiagram.Aggregation
{

    /**
     * 
     * 
     * Aggregation is another category of "has a" relationship where a class can contain other classes as properties but those classes can exist independently.
     * For example, the Student class contains the Course class instance as a property to form the composition relationship.
     * However, both the classes can exist independently and so it is called an aggregation relationship.
     * 
     * 
     * In the above aggregation relationship, even if the Student object is deleted, the Course object will still exist. The Student class can also contain CourseId property instead of Course instance.
     * Composition and Aggregation both are "has a" relationship but in the composition relationship, related classes don't exist independently whereas, in the aggregation, related classes exist independently.
     * 
     * 
     * 
     * Aggregation is another type of composition ("has a" relation).
     * A class (parent) contains a reference to another class (child) where both classes can exist independently.
     * A class can also include a reference of the id property of another class.
     * 
     */
    public class Student
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        public Course EnrolledCourse { get; set; }
    }

    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public IList Topics { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
