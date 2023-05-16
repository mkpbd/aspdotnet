using System;
using System.Linq;

namespace ClassDiagram.Association
{
    public class Student
    {
        public int StudentId { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }
    }

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
