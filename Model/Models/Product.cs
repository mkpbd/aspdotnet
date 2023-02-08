using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    public class Product
    {
        public int IdProduct { get; set; }
        public decimal Price { get; set; }
        public string ProductName { get; set; }
        public Order[] Orders { get; set; }

        public String IdProductId { get; set; }
        public Int32 IdCategory { get; set; }
        public String Description { get; set; }
        public string Year { get; set; }


        public override string ToString()
        {
            return String.Format("IdProduct: {0} – Price: {1}", this.IdProduct,this.Price);
        }
    }
}
