﻿using SolidPrincple.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrincple.DIP
{
    internal class DataAccessFactoryDIP
    {
        public static IEmployeeDataAccessLogic GetEmployeeDataAccessObj()
        {
            return new EmployeeDataAccessLogicDIP();
        }
    }
}