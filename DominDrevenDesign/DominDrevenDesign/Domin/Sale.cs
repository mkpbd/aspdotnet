using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominDrevenDesign.Domin
{
    internal class Sale
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public DateTime SaleDate { get; set; }
        public int Price { get; set; }
    }
}
