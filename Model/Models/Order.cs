namespace Model.Models
{
    public class Order
    {
        public int Quantity { get; set; }
        public int IdOrder { get; set; }
        public decimal EuroAmount { get; set; }
        public string Description { get; set; }
        public Product Product { get; set; }
        public Customer Customer { get; set; }
        public bool Shipped { get; set; }
        public string Month { get; set; }
        public int IdProduct { get; set; }


        public override string ToString()
        {
            return String.Format("IdOrder: {0} – IdProduct: {1} – " +
            "Quantity: {2} – Shipped: {3} – " +
            "Month: {4}", this.IdOrder, this.IdProduct,
            this.Quantity, this.Shipped, this.Month);
        }
    }
}
