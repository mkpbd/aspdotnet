using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.valueOfObject
{
    public class SpiceLevel
    {
        private readonly int value;

        public SpiceLevel(int value)
        {
            this.value = value;
        }

        public int Value
        {
            get { return value; }
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj.GetType() != GetType())
            {
                return false;
            }

            SpiceLevel other = (SpiceLevel)obj;

            return value == other.value;
        }

        public override int GetHashCode()
        {
            return value.GetHashCode();
        }
    }
}
