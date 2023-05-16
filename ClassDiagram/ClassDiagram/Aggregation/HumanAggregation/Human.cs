using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDiagram.Aggregation.HumanAggregation
{
    internal class Human
    {
        public Head Head { get; set; }
        public Torso Torso { get; set; }
        public Arm[] Arms { get; set; }
        public Leg[] Legs { get; set; }
    }
}
