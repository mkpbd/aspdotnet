using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursive
{
    public static class Factorial
    {

        public static double FactorialProblem(int numbeer)
        {

            if(numbeer == 0) {
                return 1;
            }

            //double facttorial = 1;

            //for (int i = numbeer; i > 1; i--)
            //{
            //    facttorial *= i;
            //}

            //return facttorial;
          return numbeer * FactorialProblem(numbeer- 1);



        }
    }
}
