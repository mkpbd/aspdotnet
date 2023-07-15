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
        public Guid Id { get; private set; }
        public Guid CustomerId { get; private set; }
        public void Add(Product product)
        {
            var LineItem = new LineItem(Guid.NewGuid(),Id, product.Id,product.Price);
            _itemLists.Add(LineItem);
        }

    }
}
