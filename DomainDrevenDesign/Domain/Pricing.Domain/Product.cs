using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Pricing.Domain
{
    public class Product
    {
 
        public int Id { get; set; }  
        // Pricing 
        public decimal PriceWithoutVAT { get; set; }
        public int VATPrecentage { get; set; }
        public decimal VATValue { get; set; }
        public decimal PriceIncludingVAT { get; set; }

     
    }
}
