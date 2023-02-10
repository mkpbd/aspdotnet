using Model.Models;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Collections;
using System.Reflection;

namespace LinqExample.BasicQuery
{
    public class LinqJoinning
    {
        Customer[] customers = Utitlity.GetCustomer();
        Product[] products = Utitlity.GetProduct();
        Order[] orders = Utitlity.GetOrders();
        Category[] Categories = Utitlity.Categoriy();


        // Products and their ordered amounts
        public void productOrderedAmounts()
        {
            var producytOrderAmount =
                    from p in products
                    join o in (
                            from c in customers
                            from o in c.Orders
                            join p in products
                            on o.IdProduct equals p.IdProduct
                            select new { p.IdProduct, OrderAmount = o.Quantity * p.Price }
                    ) on p.IdProduct equals o.IdProduct
                    into orders
                    select new
                    {
                        p.IdProduct,
                        TotalOrderedAmount =
                    orders
                    .Aggregate(0m, (a, o) => a += o.OrderAmount)
                    };



            // Customers and their most expensive orders paired with the month of execution 


            var expr =
                    from c in customers
                    join o in (
                            from c in customers
                            from o in c.Orders
                            join p in products
                            on o.IdProduct equals p.IdProduct
                            select new
                            {
                                c.Name,
                                o.IdProduct,
                                o.Month,
                                OrderAmount = o.Quantity * p.Price
                            }
                    ) on c.Name equals o.Name into orders
                    select new
                    {
                        c.Name,
                        MaxOrder =
                            orders
                            .Aggregate(new { Amount = 0m, Month = String.Empty },
                            (a, s) => a.Amount > s.OrderAmount
                            ? a
                            : new
                            {
                                Amount = s.OrderAmount,
                                Month = s.Month
                            })
                    };



        }


        public void ReangOpartors()
        {

            var rangeOneTwoSix = Enumerable.Range(1, 6)
                 .SelectMany(x => (
                 from o in (
                 from c in customers
                 from o in c.Orders
                 select o)
                 where o.Month ==
                 new CultureInfo("en-US").DateTimeFormat.GetMonthName(x)
                 select new { o.Month, o.IdProduct }));

            var repeats =
                        Enumerable.Repeat((from c in customers
                                           select c.Name), 2)
                                                        .SelectMany(x => x);


            var expr =
                  Enumerable.Repeat((from c in customers
                                     select c.Name), 2)
                  .SelectMany(x => x);

            // Listin g 3 - 53 The All operator applied to all customer orders to check the quantity
            bool result =
                            (from c in customers
                             from o in c.Orders
                             select o)
                            .All(o => o.Quantity > 0);
            result = Enumerable.Empty<Order>().All(o => o.Quantity > 0);


            //Listin g 3 - 55 The Take operator, applied to extract the two top customers ordered by order amount
            var topTwoCustomers =
            (from c in customers
             join o in (
             from c in customers
             from o in c.Orders
             join p in products
             on o.IdProduct equals p.IdProduct
             select new { c.Name, OrderAmount = o.Quantity * p.Price }
             ) on c.Name equals o.Name
             into customersWithOrders
             let TotalAmount = customersWithOrders.Sum(o => o.OrderAmount)
             orderby TotalAmount descending
             select new { c.Name, TotalAmount }
            ).Take(2);

            //  Listin g 3 - 56 The TakeWhile operator, applied to extract the top customers that form 80 percent of all orders
            // globalAmount is the total amount for all the orders
            decimal globalAmount = 4;
            var limitAmount = globalAmount * 0.8m;
            var aggregated = 0m;
            var topCustomers =
            (from c in customers
             join o in (
                     from c in customers
                     from o in c.Orders
                     join p in products
                 on o.IdProduct equals p.IdProduct
                     select new { c.Name, OrderAmount = o.Quantity * p.Price }
         ) on c.Name equals o.Name
             into customersWithOrders
             let TotalAmount = customersWithOrders.Sum(o => o.OrderAmount)
             orderby TotalAmount descending
             select new { c.Name, TotalAmount }
                        )
                        .TakeWhile(X =>
                        {
                            bool result = aggregated < limitAmount;
                            aggregated += X.TotalAmount;
                            return result;
                        });


        }



        public void LinqKeywodsOprators()
        {

            var result = customers.Take(3).Union(customers.Skip(3));
            //var results = customers.TakeWhile(p).Union(customers.SkipWhile(p));

            var item = customers.First(c => c.Country == Countries.USA);

            //Listin g 3 - 58 Examples of the FirstOrDefault operator syntax
            var items = customers.FirstOrDefault(c => c.City == "Las Vegas");
            Console.WriteLine(item == null ? "null" : item.ToString()); // returns null
            IEnumerable<Customer> emptyCustomers = Enumerable.Empty<Customer>();
            items = emptyCustomers.FirstOrDefault(c => c.City == "Las Vegas");
            Console.WriteLine(item == null ? "null" : item.ToString()); // returns null

            // returns Product 1
            var itemss = products.Single(p => p.IdProduct == 1);
            Console.WriteLine(item == null ? "null" : item.ToString());
            // InvalidOperationException
            itemss = products.Single();
            Console.WriteLine(item == null ? "null" : item.ToString());
            // InvalidOperationException
            IEnumerable<Product> emptyProducts = Enumerable.Empty<Product>();
            itemss = emptyProducts.Single(p => p.IdProduct == 1);
            Console.WriteLine(item == null ? "null" : item.ToString());


            // returns Product at index 2
            var item1 = products.ElementAt(2);
            Console.WriteLine(item == null ? "null" : item.ToString());
            // returns null
            item1 = Enumerable.Empty<Product>().ElementAtOrDefault(6);
            Console.WriteLine(item == null ? "null" : item.ToString());
            // returns null
            item1 = products.ElementAtOrDefault(6);
            Console.WriteLine(item == null ? "null" : item.ToString());


            var italianCustomers =
                                from c in customers
                                where c.Country == Countries.Italy
                                select c;
            var americanCustomers =
            from c in customers
            where c.Country == Countries.USA
            select c;
            var expr = italianCustomers.Concat(americanCustomers);

        }


        public void ConventionOperators()
        {
            var productsQuery =
                        (from p in products
                         where p.Price >= 30
                         select p)
                        .ToList();

            var ordersWithProducts =
            from c in customers
            from o in c.Orders
            join p in productsQuery
            on o.IdProduct equals p.IdProduct
            select new
            {
                p.IdProduct,
                o.Quantity,
                p.Price,
                TotalAmount = o.Quantity * p.Price
            };
            foreach (var order in ordersWithProducts)
            {
                Console.WriteLine(order);
            }

            //  LISTINg 3 - 68 An example of the ToDictionary operator, applied to customers

            var customersDictionary =
                                customers
                                .ToDictionary(c => c.Name,
                                c => new { c.Name, c.City });


            //    Listin g 3 - 69 An example of the ToLookup operator, used to group orders by product
            var ordersByProduct =
                                  (from c in customers
                                   from o in c.Orders
                                   select o)
                                    .ToLookup(o => o.IdProduct);

            Console.WriteLine("\n\nNumber of orders for Product 1: {0}\n",
            ordersByProduct[1].Count());
        }

        public void LinqQuery()
        {

            var query =
                        from c in customers
                        where c.City == "USA"
                        && c.Name == "WA"
                        select new { c.Country, c.Name, c.City };

            var ordersCustomer =
                                from o in orders
                                where o.IdProduct == 10528
                                select o;



            var orderCounts = from c in customers where c.Orders.Count () > 20 select c.Orders;


            var city =
                    from c in customers
                    where c.City == "ab"
                    select c.City;
            IEnumerator<string> enumerator = city.GetEnumerator();

            var companyNames = city.ToList();


            var customerName =
                    from c in customers
                    where c.customerId == 2
                    select c;

            var enumeratosr = customerName.GetEnumerator();
            if (enumeratosr.MoveNext())
            {
                var customer = enumeratosr.Current;
                Console.WriteLine("{0} {1}", customer.customerId, customer.Name);
            }


            var customerCountry =
                from c in customers
                        where c.Country == Countries.USA
                        select new { c.customerId, Name = c.Name.ToUpper() } into r
                        orderby r.Name
                        select r;


        }




    }
}
