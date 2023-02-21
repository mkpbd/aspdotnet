using SolidPrincple.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrincple.Liskov
{
    internal class LiskovPrinciple
    {
    }

    public class Apples : IFruit
    {
        public string GetColor()
        {
            return "Red";
        }
    }
    public class Oranges : IFruit
    {
        public string GetColor()
        {
            return "Orange";
        }
    }

}
