using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    public class Customer
    {
        public string Name { get; set; }
        public string City { get; set; }
        public Order[] Orders { get; set; }
        public Countries Country { get; set; }
        public int customerId { get; set; }

        public override string ToString()
        {
            return String.Format("Name: {0} – City: {1} – Country: {2}",
            this.Name, this.City, this.Country);
        }
    }




}
