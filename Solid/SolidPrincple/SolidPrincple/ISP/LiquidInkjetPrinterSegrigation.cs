using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrincple.ISP
{
    // onle responsible for segrigations 
    public class LiquidInkjetPrinterSegrigation : IPrinterTasksSegrigations
    {
        public void Print(string PrintContent)
        {

            Console.WriteLine("Print Done");
        }

        public void Scan(string ScanContent)
        {
            Console.WriteLine("Scan content");
        }
    }
}
