namespace AdoNetBasic.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }

        public List<ProductInventorie> ProductInventories { get; set; }
    }
}
