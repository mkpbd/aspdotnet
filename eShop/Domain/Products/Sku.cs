namespace Domain.Products
{
    // Sock keeping uint

    public  record Sku
    {
        private const int DefaultLength = 15;
        private Sku(string _value) => Value = _value;
        public string  Value { get; init; }
        public static Sku? Create(string _value)
        {
            if(string.IsNullOrEmpty(_value)) return null;

            if(_value.Length != DefaultLength) return null;

            return new Sku(_value);
        }

    }
}
