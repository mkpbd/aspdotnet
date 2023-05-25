using DDD.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.AggregateRoot
{
    public class Cat : IAggregateRoot<Box>
    {
        public int Id { get ; set ; }
        public List<Box> Item { get ; set ; }

        public void Add(Box item)
        {
            Item.Add(item);
        }

        public void Clear()
        {
            foreach(Box item in Item)
            {
                item.Name = "abc";
            }
        }

        public void Remove(Box item)
        {
            Item.Remove(item);
        }
    }
}


/**********
 * 
 * 
 * In this example, the Cat class is the aggregate root. It contains all of the data related to the cat, including its name and a list of litter boxes. The AddLitterBox() and RemoveLitterBox() methods allow users to add and remove litter boxes from the cat's environment, and the CleanLitterBoxes() method cleans all of the litter boxes.

This example is funny because it shows how domain aggregates can be used to model even the most mundane of things. In this case, we are modeling a cat's litter box habits. However, the same principles can be used to model any type of domain object, from customer orders to product catalogs.

Domain aggregates are a powerful tool for managing data in DDD applications. They help to ensure that data is always consistent, and they make it easier to reason about the state of the application. Even when the domain is something as silly as a cat's litter box habits.
 * 
 * 
 * ***/