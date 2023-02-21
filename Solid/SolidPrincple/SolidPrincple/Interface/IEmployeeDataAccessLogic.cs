using SolidPrincple.DIP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrincple.Interface
{
    public interface IEmployeeDataAccessLogic
    {
       
            Employee GetEmployeeDetails(int id);
            //Any Other Employee Related Method Declarations
        
    }
}
