using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrincple.ISP
{
    // Interface sergigations or single responsibility 
    public class HPLaserJetPrinterInterfaceSegrigation : IFaxTasks, IPrintDuplexTasks, IPrinterTasksSegrigations
    {
        public void Fax(string content)
        {
            throw new NotImplementedException();
        }

        public void Print(string PrintContent)
        {
            throw new NotImplementedException();
        }

        public void PrintDuplex(string content)
        {
            throw new NotImplementedException();
        }

        public void Scan(string ScanContent)
        {
            throw new NotImplementedException();
        }
    }
}
