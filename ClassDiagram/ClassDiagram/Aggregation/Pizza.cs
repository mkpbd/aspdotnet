using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDiagram.Aggregation
{
    public class Pizza
    {

        public Cheese[] Cheeses { get; set; }
        public Sauce Sauce { get; set; }
        public Topping[] Toppings { get; set; }
    }
}
