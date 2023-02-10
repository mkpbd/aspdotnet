using Model.Models;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

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





    }
}
