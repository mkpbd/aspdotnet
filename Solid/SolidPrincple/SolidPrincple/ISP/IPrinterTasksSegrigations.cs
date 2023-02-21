using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrincple.ISP
{
    public interface IPrinterTasksSegrigations
    {
        void Print(string PrintContent);
        void Scan(string ScanContent);
    }
}
