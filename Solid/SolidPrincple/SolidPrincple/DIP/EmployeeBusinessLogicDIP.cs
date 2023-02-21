using SolidPrincple.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrincple.DIP
{
    internal class EmployeeBusinessLogicDIP
    {
        IEmployeeDataAccessLogic _IEmployeeDataAccessLogic;
        public EmployeeBusinessLogicDIP()
        {
            _IEmployeeDataAccessLogic = DataAccessFactoryDIP.GetEmployeeDataAccessObj();
        }
        public Employee GetEmployeeDetails(int id)
        {
            return _IEmployeeDataAccessLogic.GetEmployeeDetails(id);
        }
    }
}
