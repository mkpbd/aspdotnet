using DDD.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.AggregateRoot
{

    /***
     * 
     * In Domain-Driven Design (DDD), an aggregate is a cluster of domain objects that are treated as a unit for the purpose of data changes. Aggregates are defined by an aggregate root, which is the object that owns the aggregate and coordinates all changes to the aggregate's state.

For example, in an online store, an aggregate could be a customer order. The aggregate root would be the Order object, and it would contain all of the data related to the order, such as the customer, the items in the order, and the shipping information. When changes are made to the order, such as adding or removing items, the aggregate root would coordinate those changes to ensure that the order's state remains consistent.
     * **/
    internal class Order : IOrderAggregatesRoot
    {
        public List<OrderItem> Items { get; set; }
        public void AddItem(OrderItem item)
        {
            Items.Add(item);
        }

        public void RemoveItem(OrderItem item)
        {
            Items.Remove(item);
        }

        public void Save()
        {
            Items = new List<OrderItem>();
            // save item in database or other files
        }
    }
}

/***
 * 
 * In this example, the Order class is the aggregate root. It contains all of the data related to the order, and it coordinates all changes to the order's state. The AddItem() and RemoveItem() methods allow users to add and remove items from the order, and the Save() method saves the order to the database.

Aggregates are a powerful tool for managing data in DDD applications. They help to ensure that data is always consistent, and they make it easier to reason about the state of the application.
 * 
 * 
 */