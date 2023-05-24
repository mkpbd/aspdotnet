using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Products
{
    public class Product
    {
        public Guid Id { get; private set; }

        public string Name { get; private set; } = string.Empty;

        public Money Price { get; private set; } 

        public Sku Sku { get; private set; }


    }

    public record Money(string currency, decimal amount);

    // stock keeping per unit
    public record Sku
    {
        public const int DeafultLength = 15;
        public string Value { get; init; }

        public Sku(string value) => Value = value;

        public static Sku? Create(string value)
        {

            if(string.IsNullOrEmpty(value)){
                return null;
            }

            if(value.Length != DeafultLength ) {

                return null;
            }


            return new Sku(value);
        }
    }
}
