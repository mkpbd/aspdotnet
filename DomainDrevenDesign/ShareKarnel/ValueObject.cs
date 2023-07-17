using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareKarnel
{
    public abstract class ValueObject : IEquatable<ValueObject>
    {
        protected abstract IEnumerable<object> GetAtomicValues();
        public bool Equals(ValueObject? other)
        {
           if(other == null || other.GetType() != GetType()) return false;
           var thisVaues = GetAtomicValues().GetEnumerator();
            var otherVaues = other.GetAtomicValues().GetEnumerator();

            while( thisVaues.MoveNext() && otherVaues.MoveNext())
            {
                if (thisVaues.Current != null && !thisVaues.Current.Equals(otherVaues.Current)) return false;
            }
            return !thisVaues.MoveNext() && !otherVaues.MoveNext();
        }

        public override bool Equals(object? obj)
        {
            return base.Equals(obj as ValueObject);
        }


        public override int GetHashCode()
        {
            return GetAtomicValues()
                .Select(x => x != null ? x.GetHashCode() : 0).Aggregate((x, y) => x ^ y);
        }

        public static bool operator ==(ValueObject? leftSite, ValueObject? rightSite)
        {

            return leftSite != null && leftSite.Equals(rightSite);

        }

        public static bool operator !=(ValueObject? leftSite, ValueObject? rightSite)
        {
            return !(leftSite == rightSite);
        }

    }
}
