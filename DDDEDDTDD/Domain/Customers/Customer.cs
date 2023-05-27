using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Customers
{
    public class Customer
    {
        public CustomerId Id { get; private set; }
        public string Emain { get; private set; } = string.Empty;
        public string Name { get; private  set; } = string.Empty;
    }


    // create strongyl type Id 

    public class CustomerIds : IEquatable<CustomerIds>
    {
        public  bool Equals(CustomerIds? other)
        {
            return base.Equals(other);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }


   // but can create strongly type Id using Oneline code in Record 

   
}
