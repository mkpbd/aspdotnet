using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Utitlity
    {

        public static Category[] Categoriy()
        {
            Category[] categories = new Category[] {
            new Category { IdCategory = 1, Name = "Pasta", Year = "2"},
            new Category { IdCategory = 2, Name = "Beverages", Year = "1"},
            new Category { IdCategory = 3, Name = "Other food", Year = "3"},
            };

            return categories;
        }


        public static Product[] GetProduct()
        {
            Product[] products = new Product[] {
                new Product { IdProductId = "PASTA01", IdCategory = 1, Description = "Tortellini" ,Year = "2"},
                new Product { IdProductId = "PASTA02", IdCategory = 1, Description = "Spaghetti" ,Year = "3"},
                new Product { IdProductId = "PASTA03", IdCategory = 1, Description = "Fusilli" , Year = "2"},
                new Product { IdProductId = "BEV01", IdCategory = 2, Description = "Water"  ,   Year = "1" },
                new Product { IdProductId = "BEV02", IdCategory = 2, Description = "Orange Juice",Year = "1" },
                };
            return products;
        }


        public static Customer[] GetCustomer()
        {
            Customer[] customers = new Customer[] {
                        new Customer {Name = "Paolo", City = "Brescia", customerId = 1,
                        Country = Countries.Italy, Orders = new Order[] { new Order { IdOrder = 1, Quantity = 3, IdProduct = 1 , Shipped = false, Month = "January"},
                        new Order { IdOrder = 2, Quantity = 5, IdProduct = 2 , Shipped = true, Month = "May"}}},
                                new Customer {Name = "Marco", City = "Torino", Country = Countries.Italy, Orders = new Order[] {
                                 new Order { IdOrder = 3, Quantity = 10, IdProduct = 1 , Shipped = false, Month = "July"},
                                 new Order { IdOrder = 4, Quantity = 20, IdProduct = 3 ,   Shipped = true, Month = "December"}}},
                                 new Customer {Name = "James", City = "Dallas", Country = Countries.USA, Orders = new Order[] {
                                new Order { IdOrder = 5, Quantity = 20, IdProduct = 3 , Shipped = true, Month = "December"}}},
                                 new Customer {Name = "Frank", City = "Seattle", Country = Countries.USA, Orders = new Order[] {
                                 new Order { IdOrder = 6, Quantity = 20, IdProduct = 5 , Shipped = false, Month = "July"}
                                 }
                               }
           };
            return customers;
        }

        // get orders methods 

        public static Order[] GetOrders()
        {
            Order[] orders = new Order[]
            {
                new Order
                {
                    IdOrder = 1,
                    Quantity = 1,
                    IdProduct = 1,
                    Customer = new Customer
                    {
                         City ="a", Country= Countries.USA,
                          Name = "jamal"
                    },
                      Product = new Product
                    {
                         IdProduct= 21,
                          IdCategory = 2,
                           Description = "abc",
                            Price =100,
                             ProductName="two product name"
                    }
                },
                new Order
                {
                    IdOrder = 1,
                    Quantity = 1,
                    IdProduct = 1,
                    Customer = new Customer
                    {
                         City ="a", Country = Countries.Italy,
                          Name = "jamal"
                    },
                    Product = new Product
                    {
                         IdProduct= 1,
                          IdCategory = 1,
                           Description = "abc",
                            Price =100,
                             ProductName="one product name"
                    }
                },
                new Order
                {
                    IdOrder = 3,
                    Quantity = 1,
                    IdProduct = 1,
                    Customer = new Customer
                    {
                         City ="a", Country= Countries.Italy,
                          Name = "tomal"
                    },
                      Product = new Product
                    {
                         IdProduct= 3,
                          IdCategory = 3,
                           Description = "abc",
                            Price =100,
                             ProductName="three product name"
                    }
                },
                new Order
                {
                    IdOrder = 5,
                    Quantity = 1,
                    IdProduct = 1,
                    Customer = new Customer
                    {
                         City ="a", Country = Countries.USA,
                          Name = "kamal"
                    },
                      Product = new Product
                    {
                         IdProduct= 4,
                          IdCategory = 4,
                           Description = "four abc",
                            Price =100,
                             ProductName="four product name"
                    }
                },

            };
            return orders;


        }


    }
}
