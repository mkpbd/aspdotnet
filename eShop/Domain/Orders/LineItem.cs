using Domain.Products;

namespace Domain.Orders
{
    public class LineItem
    {
        private LineItem() { }
        public LineItem(LineItemId _item, OrderId _orderId, ProductId _productId, Money _price)
        {
            Id = _item;
            OrderId = _orderId;
            ProductId = _productId;
            Price = _price;
        }

        public LineItemId Id { get; private set; }
        public OrderId OrderId { get; private set; }
        public ProductId ProductId { get; private set; }
        public Money Price { get; private set; }

    }
}
