using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventDriventDesign.EDD
{
    public class Product
    {
        public event EventHandler Purchased;

        public void Click_Purchase()
        {
            if (Purchased != null)
            {
                Purchased(this, EventArgs.Empty);
            }
        }
    }

    public class Customer
    {
        public Customer()
        {
            // Add a handler to the purchased event 
            Product product = new Product();
            product.Purchased += click_Customer_Purchased;
        }

        public void click_Customer_Purchased(object sender, EventArgs e)
        {
            // do somthing when  customer purchase button clicked 
            Console.WriteLine("some cliked now purchase Button Active");
        }
    }
}
