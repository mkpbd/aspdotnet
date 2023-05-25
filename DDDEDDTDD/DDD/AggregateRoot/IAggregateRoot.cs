using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.AggregateRoot
{
    public interface IAggregateRoot<T>
    {
        public int Id { get; set; }
        public List<T> Item { get; set; }

        void Add(T  item);
        void Remove (T item);
        void Clear();
    }
}
