using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDiagram.Composition.Compositon1
{
    internal class Car
    {
        private Engine engine;

        public Car()
        {
            engine = new Engine();
        }

        public void Drive()
        {
            engine.Start();
        }
    }
}
