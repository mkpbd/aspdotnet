### **Eshop Site Desgin with  DDD (Domain Driven Design)**


![1689412213140](image/readme/1689412213140.png)


Strongly type Ids 

A strongly typed ID is a unique identifier that is used to represent an object in a database or other data store. The ID is strongly typed, which means that it is of a specific type, such as an integer or a string. This ensures that the ID is always of the correct type and that it can be safely used in operations such as comparisons and sorting.

```csharp
public class Person
{
    public int Id { get; set; }
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
