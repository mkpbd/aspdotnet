### **Eshop Site Desgin with  DDD (Domain Driven Design)**

![1689412213140](image/readme/1689412213140.png)

Design Domain

```csharp
 public record OrderId(Guid Value);
public class Order
    {
        private readonly HashSet<LineItem> _itemLists = new HashSet<LineItem>();
        public OrderId Id { get; private set; }
        public CustomerId CustomerId { get; private set; }
        //public List<LineItem> LineItems { get;  set; } = new List<LineItem>();

        public IReadOnlyList<LineItem> LineItems => _itemLists.ToList();
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
```

```csharp
public record LineItemId(Guid Value);

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
```

**Strongly type Ids**

A strongly typed ID is a unique identifier that is used to represent an object in a database or other data store. The ID is strongly typed, which means that it is of a specific type, such as an integer or a string. This ensures that the ID is always of the correct type and that it can be safely used in operations such as comparisons and sorting.

```csharp
public class Person
{
    public int Id { get; set; }
}
```

```csharp
 public record CustomerId(Guid Value);
 public record OrderId(Guid Value);
 public record ProductId(Guid Value);

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

```

The `Id` property in this class is strongly typed as an `int`. This means that the `Id` property can only store integers. If you try to assign a value of a different type to the `Id` property, the compiler will not allow it.

Strongly typed IDs can help to improve the readability and maintainability of your code. By knowing the type of the ID, you can be sure that it is being used correctly. This can help to prevent errors and to make your code easier to understand.

Here are some additional benefits of using strongly typed IDs:

* They can help to improve the performance of your code.
* They can help to make your code more secure.
* They can help to make your code more portable.

If you are working with a database or other data store, I encourage you to use strongly typed IDs. They can help to improve the quality and maintainability of your code.

Here are some other examples of strongly typed IDs in C#:

* `Guid`
* `DateTime`
* `TimeSpan`
* `Uri`
* `IPAddress`

### **an anemic domain model is an anti-pattern**

 It is a design pattern that results in domain objects that are too thin, containing only data and no business logic. This makes the domain objects less cohesive and difficult to test.

Here is an example of an anemic domain model in C#:

```csharp
public class Customer
{
  public int Id { get; set; }
  public string Name { get; set; }
  public string Email { get; set; }
}
```

This class only contains data, and no business logic. For example, there is no code to check if the customer's name is valid, or to send the customer an email. This logic would be implemented in a separate class, which would make the Customer class more difficult to test.

A better approach is to create a rich domain model, where the domain objects contain both data and business logic. This makes the domain objects more cohesive and easier to test.

Here is an example of a rich domain model in C#

```csharp
public class Customer
{
  public int Id { get; set; }
  public string Name { get; set; }
  public string Email { get; set; }

  public bool IsValidName()
  {
    return Name.Length > 0 && Name.Contains(" ");
  }

  public void SendEmail()
  {
    // Send an email to the customer
  }
}
```

This class contains both data and business logic. The `IsValidName()` method checks if the customer's name is valid, and the `SendEmail()` method sends an email to the customer. This makes the Customer class more cohesive and easier to test.

In general, it is best to avoid anemic domain models in C# code. Rich domain models are more cohesive and easier to test, which makes them a better choice for most applications.

Here are some of the problems with anemic domain models:

* They are difficult to test.
* They are not very cohesive.
* They are not very easy to understand.
* They can lead to tight coupling between the domain and the infrastructure.
