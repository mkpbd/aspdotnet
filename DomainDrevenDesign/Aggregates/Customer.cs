using ShareKarnel;

namespace Aggregates
{
    public class Customer : ValueObject
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        protected override IEnumerable<object> GetAtomicValues()
        {
           yield return CustomerName;
        }
    }
}