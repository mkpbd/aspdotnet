using Domain.Customers;
using Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Orders
{
    public class Order
    {
        private readonly HashSet<ListItem> _listItem;
        public OrderId Id { get; set; }
        public CustomerId CustomerId { get; set; }

        //public void Add(Product product)
        //{
        //    var listItem = new ListItem(Guid.NewGuid(), product.Id, product.Price);
        //}

        public Order() { }

        public static Order Create(Customer customer)
        {
            var order = new Order()
            {
                Id = new OrderId(Guid.NewGuid()),
                CustomerId = customer.Id,
            };

            return order;
        }

        public void Add(ProductId productId, Money price)
        {
            var list = new ListItem(new ListItemId(Guid.NewGuid()), productId, Id, price);

            _listItem.Add(list);
        }

    }

    
}
