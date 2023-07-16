using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.WithoutDdd
{
    public class Product
    {

        // Product descripion 
        public int Id { get; set; }
        public string? ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public List<ProductCategory> Categories { get; set; } = new();
        
        // Pricing 
        public decimal PriceWithoutVAT { get; set; }
        public int VATPrecentage { get; set; }
        public decimal VATValue { get; set; }
        public decimal PriceIncludingVAT { get; set; }

        // Quantity
        public int QuantityOnHand { get; set; }
        public int RestockThreshold { get; set; }
        public string? ProductCode { get; set; }

        // Reviews 
        public List<Review> Reviews { get; set; } = new();
        public decimal ReviewAverage { get; set; }
    }
}
