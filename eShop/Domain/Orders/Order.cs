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
        private readonly HashSet<LineItem> _itemLists = new HashSet<LineItem>();
        public OrderId Id { get; private set; }
        public CustomerId CustomerId { get; private set; }
        public List<LineItem> LineItems { get;  set; } = new List<LineItem>();
        private Order() { }
        public static Order Create(Customer customer)
        {
            var order = new Order()
            {
                Id = new OrderId(Guid.NewGuid()),
                CustomerId = customer.Id,
            };
            return order;

        }
        public void Add(ProductId productId , Money money)
        {
            var lineItem = new LineItem(new LineItemId(Guid.NewGuid()), Id ,productId,money);
            _itemLists.Add(lineItem);
        }

    }
}
