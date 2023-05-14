using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominDrevenDesign.Domin
{
    internal class Inventory

    {
        public int Id { get; set; }
        public List<Product> Products { get; set; }
        public int Quantity { get; set; }
        public string Location { get; set; }
        public string Staus { get; set; }

    }
}
