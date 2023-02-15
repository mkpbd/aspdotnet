using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionApiPractices.Reflection
{
    public class Customer
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> ListOfPrperty { get; set; }

        public Customer(int id , string name) {
            Id = id;
            Name = name;   
        }

        public void PrintId()
        {

            Console.WriteLine("Id No {0}", Id);
        }


        public void PrintName()
        {

            Console.WriteLine("Name : {0}", Name);
        }


    }
}
