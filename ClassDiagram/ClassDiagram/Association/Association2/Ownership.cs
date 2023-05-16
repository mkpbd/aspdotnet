using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDiagram.Association.Association2
{
    internal class Ownership
    {
        public Person Person { get; set; }
        public Pet Pet { get; set; }
    }
}
