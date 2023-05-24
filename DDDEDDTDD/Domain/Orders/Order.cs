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
        private readonly HashSet<List<ListItem>> _listItem;
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }

        //public void Add(Product product)
        //{
        //    var listItem = new ListItem(Guid.NewGuid(), product.Id, product.Price);
        //}

    }

    public class ListItem
    {
        public ListItem(Guid id,  Guid productId, decimal price) { 
            Id = id;
           // OrderId = orderId;
            ProductId = productId;
            Price = price;
        }
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public decimal Price { get; set; }

    }
}
