using Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Orders
{
    public class ListItem
    {
        public ListItem(ListItemId id, ProductId productId, OrderId orderid, Money price)
        {
            Id = id;
            // OrderId = orderId;
            ProductId = productId;
            OrderId = orderid;
            Price = price;
        }
        public ListItemId Id { get; set; }
        public OrderId OrderId { get; set; }
        public ProductId ProductId { get; set; }
        public Money Price { get; set; }

    }
}
