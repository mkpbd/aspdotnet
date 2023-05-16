using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDiagram.Association.Association4
{
    public class Student
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
    }


    /**
     * 
     * 
     * In the above example, the StudentRepository class uses the Student class to save or retrieve student data. 
     * Notice that the StudentRepository class uses the Student class as a parameter of methods. 
     * The StudentRepository class provides service to any class who is interested in saving or retrieving student data.
     * However, both the classes have independent lifetime meaning that disposing one does not dispose of another.
     * So, we can say that the relationship between the StudentRepository and the Student class is association (or collaboration/delegation).
     * You can also say that the Student class delegates the responsibility of the implementation of saving and retrieving student-related data to the StudentRepository class.
     * The association relationship between the classes is marked with the arrow in UML diagram, as shown below.
     * 
     * 
     * A class only uses behaviors/functionalities (methods) of another class but does not change them by overriding them.
     * A class does not inherit another class.
     * A class does not include (own) another class as a public member.
     * Both classes have independent lifetime where disposing of one does not automatically dispose of another.
     * 
     * 
     */

    public class StudentRepository
    {
        public Student GetStudent(int StudentId)
        {
            // get student by id from db here

            return new Student();
        }
        public bool Save(Student student)
        {
            // save student to db here
            Console.WriteLine("Student saved successfully");

            return true;
        }
        public bool Validate(Student student)
        {
            // get student from db to check whether the data is already exist
            Console.WriteLine("Student does not exist.");

            return true;
        }
    }
}
