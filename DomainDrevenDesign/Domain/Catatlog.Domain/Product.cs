using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Catalog.Domain
{
    public class Product
    {

        // Product descripion 
        public int Id { get; set; }
        public string? ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public List<ProductCategory> Categories { get; set; } = new();
        
        
    }
}
