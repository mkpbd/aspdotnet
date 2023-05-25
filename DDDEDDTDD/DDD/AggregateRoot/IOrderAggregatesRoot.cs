using DDD.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.AggregateRoot
{
    internal interface IOrderAggregatesRoot
    {
        void AddItem(OrderItem item);

        void RemoveItem(OrderItem item);

        void Save();
    }
}
