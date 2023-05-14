using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventDriventDesign.EDD
{
    public class Button
    {
        public event EventHandler Clicks;

        public void Click()
        {
            if (Clicks != null)
            {
                Clicks(this, EventArgs.Empty);
            }
        }
    }

    public class Label
    {
        public Label()
        {
            // add a handler to click event 
            var bb = new Button();
            bb.Clicks += Label_Click;
        }

        private void Label_Click(object sender, EventArgs e)
        {
            // Do somthing hear when button is clicked
            Console.WriteLine("This button is Clicked Hear");
        }
    }
}


