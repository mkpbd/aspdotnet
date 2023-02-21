using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrincple.ISP
{

    // interface Segrigation  or samller interface  single responsibility
    interface IPrintDuplexTasks
    {
        void PrintDuplex(string content);
    }
}
