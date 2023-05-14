using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominDrevenDesign.Domin
{
    /// <summary>
        /****
          * 
          * This class represents a product in the retail domain. It has three properties: Id, Name, and Price. The Id property is the unique identifier for the product. The Name property is the name of the product. The Price property is the current price of the product.

Once we have created the domain model, we can use it to develop the software application. The software application should be designed to implement the domain model.
          */
    /// </summary>
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
    }
}
