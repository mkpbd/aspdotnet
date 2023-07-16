using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Inventory.Domain
{
    public class Product
    {
        public int Id { get; set; }
        // Quantity
        public int QuantityOnHand { get; set; }
        public int RestockThreshold { get; set; }
        public string? ProductCode { get; set; }
    }
}
