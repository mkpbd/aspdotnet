using DotnetCoreMVC.Models;
using static System.Collections.Specialized.BitVector32;
using System.Reflection;
using System.Xml.Linq;

namespace DotnetCoreMVC.Services
{
    public class StudentBusinessLayer
    {
        public IEnumerable<Student> GetAll()
        {
            //logic to return all employees
            return new List<Student>()
            {
                new Student()
            {
                StudentID = 1,
                Name = "James",
                Gender = "Male",
                Branch = "CSE",
                Section = "A2",
                },

              new Student   {
                StudentID =2,
                Name = "James",
                Gender = "Male",
                Branch = "CSE",
                Section = "A2",
            }
              ,
                  new Student   {
                StudentID = 3,
                Name = "James",
                Gender = "Male",
                Branch = "CSE",
                Section = "A2",
            },
                      new Student   {
                StudentID = 4,
                Name = "James",
                Gender = "Male",
                Branch = "CSE",
                Section = "A2",
            }
            };
        }
        public Student GetById(int StudentID)
        {
            //logic to return an employee by employeeId
            Student student = new Student()
            {
                StudentID = StudentID,
                Name = "James",
                Gender = "Male",
                Branch = "CSE",
                Section = "A2",
            };
            return student;
        }
        public void Insert(Student student)
        {
            //logic to insert a student
        }
        public void Update(Student student)
        {
            //logic to Update a student
        }
        public void Delete(int StudentID)
        {
            //logic to Delete a student
        }
    }
}
