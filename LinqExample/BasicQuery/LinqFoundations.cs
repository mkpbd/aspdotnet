using Model;
using Model.Models;
using System.Collections;

namespace LinqExample.BasicQuery
{
    public class LinqFoundations
    {


        public void SimpleJoin()
        {
            Product[] products = new Product[] {
                new Product()
                {
                     IdProduct= 1,
                      Price= 10,
                       ProductName = "potato",
                        Orders = new Order[]
                        {
                             new Order()
                             {
                                 Quantity= 5
                             }
                        }
                },
                new Product()
                {
                     IdProduct= 4,
                      Price= 10,
                       ProductName = "tomato",
                        Orders = new Order[]
                        {
                             new Order()
                             {
                                 Quantity= 3
                             }
                        }
                },

                new Product()
                {
                     IdProduct= 3,
                      Price= 10,
                       ProductName = "solt",
                        Orders = new Order[]
                        {
                             new Order()
                             {
                                 Quantity= 2
                             }
                        }
                }


            };


            var query = from p in products where p.IdProduct == 1 from o in p.Orders select o;


        }

        public void SimpleCustomers()
        {
            Customer[] customers = new Customer[]
            {
                new Customer()
                {
                     City = "city1",
                      Name="bb"
                },
                new Customer()
                {
                    City = "city 2",
                     Name = "ccc"
                }
            };


            var query = from c in customers where c.Name == "bb" select c;
        }


        public void DeveloprsLinq()
        {
            Developer[] developers = GetDevelopers();

            var developersUsingCSharp = from d in developers where d.Language == "C#" select d;

            var filteredDevelopers = developers.Where(delegate (Developer d) { return d.Language == "C#"; });
            var filteredDevelopersLamdaExpression = developers.Where(d => d.Language == "C#");
            var filteredDevelopersLamdaExpressionReturn = developers.Where(d => { return d.Language == "C#"; });

            var csharpDevelopersNames = developers.Where(x => x.Language == "C#").Select(x => x.Name);


            foreach (var d in developersUsingCSharp)
            {
                Console.WriteLine($"{d.Language}  {d.Name}");
            }


            Func<Developer, bool> filterPadicate = d => d.Language == "C#";

            Func<Developer, string> selectPadicateString = d => d.Name;

            IEnumerable<string> developersUsingCSharpIEnumarable =
                    developers
                    .Where(filterPadicate)
                    .Select(selectPadicateString);
        }

        public void QueryExperssionNonGenerics()
        {

            ArrayList developers = new ArrayList();
            developers.Add(new Developer { Name = "Paolo", Language = "C#" });
            developers.Add(new Developer { Name = "Marco", Language = "C#" });
            developers.Add(new Developer { Name = "Frank", Language = "VB.NET" });

            var developersUsingCSharp = from Developer d in developers where d.Language == "C#" select d;

            foreach (var dd in developersUsingCSharp)
            {
                Console.WriteLine($"{dd.Name}  {dd.Language} ");
            }
        }


        public void JoiningWithQueryTwoGeneric()
        {
            Customer[] customers = new Customer[] {
                new Customer { Name = "Paolo", City = "Brescia",
                Orders = new Order[] {
                new Order { IdOrder = 1, EuroAmount = 100, Description = "Order 1" },
                new Order { IdOrder = 2, EuroAmount = 150, Description = "Order 2" },
                new Order { IdOrder = 3, EuroAmount = 230, Description = "Order 3" },
                }},

                                new Customer { Name = "Marco", City = "Torino",
                Orders = new Order[] {
                new Order { IdOrder = 4, EuroAmount = 320, Description = "Order 4" },
                new Order { IdOrder = 5, EuroAmount = 170, Description = "Order 5" },
                }}};

            var joiningTwo = from c in customers from o in c.Orders select new { c.Name, o.IdOrder, o.EuroAmount, o.Description };

            var joiningTwoTablesFiltering = from c in customers from o in c.Orders where o.EuroAmount > 150 select new { c.Name, o.Description, o.EuroAmount, o.IdOrder };


            foreach (var dd in joiningTwo)
            {
                Console.WriteLine($"{dd.Name}   {dd.EuroAmount} {dd.Description}");
            }

        }


        public Developer[] GetDevelopers()
        {
            Developer[] developers = new Developer[] {
            new Developer { Name = "Paolo", Language = "C#", Age = 32 },
            new Developer { Name = "Marco", Language = "C#", Age = 37},
            new Developer { Name = "Frank", Language = "VB.NET", Age = 48 },
            };

            return developers;
        }

        public void QueryGroups()
        {
            Developer[] developers = GetDevelopers();


            var developersGroupedByLanguage = from ds in developers group ds by ds.Language;

            var developerGroupByLanguageWithCal = from gp in developers group gp by new { gp.Language, calulatorAge = (gp.Age / 10) * 10 };

            var developerGroupByLanguageWithIntoKeyword = from gp in developers
                                                          group gp by gp.Language into temporaryVariableInGroup
                                                          select new
                                                          {
                                                              Language = temporaryVariableInGroup.Key,
                                                              DeveloperCount = temporaryVariableInGroup.Count()
                                                          };

            foreach (var d in developerGroupByLanguageWithCal)
            {
                foreach (var c in d)
                {
                    Console.WriteLine(c.Age + " " + c.Language);
                }
            }
        }


        public void QueryExpressionOrderbyCluse()
        {
            Developer[] developers = GetDevelopers();


            var orderByCluse = from ds in developers orderby ds.Age ascending select new { Language = ds.Language, Age = ds.Age, Name = ds.Name };

            foreach (var d in orderByCluse)
            {
                Console.WriteLine(d.Age + " " + d.Name + " " + d.Language);
            }

        }



        public void GetTwoTableJoinProductAndCategory()
        {
            Product[] products = Utitlity.GetProduct();

            Category[] categories = Utitlity.Categoriy();


            var productAndCategory = from p in products join c in categories on p.IdCategory equals c.IdCategory select new { c.IdCategory, CategoryName = c.Name, ProductName = p.ProductName, p.Description };


            // check  temporary variables 
            var productAndCategoryGroup = from ct in categories
                                          join p in products on ct.IdCategory equals p.IdCategory
                                         // group ct by ct.Name into groupbyCatetory
                                         into productAndCategoryTemporaryVariable
                                          select new
                                          {
                                              ct.IdCategory,
                                              ct.Name,
                                              Products = productAndCategoryTemporaryVariable
                                          };

            foreach (var pc in productAndCategory)
            {
                //Console.WriteLine(pc.ProductName + " "+ pc.Description + " "+ pc.CategoryName + " "+ pc.IdCategory);
                Console.WriteLine(pc);
            }

        }


        public void LeftOuterJoin()
        {
            Category[] categories = Utitlity.Categoriy();
            Product[] products = Utitlity.GetProduct();
            var categoriesAndProducts =
                from c in categories
                join p in products on c.IdCategory equals p.IdCategory
                into productsByCategory
                from pc in productsByCategory.DefaultIfEmpty(
                new Product
                {
                    IdProductId = String.Empty,
                    Description = String.Empty,
                    IdCategory = 0
                })
                select new
                {
                    c.IdCategory,
                    CategoryName = c.Name,
                    Product = pc.Description
                };
            foreach (var item in categoriesAndProducts)
            {
                Console.WriteLine(item);
            }

        }


        public void CompositiesKey()
        {
            Category[] categories = Utitlity.Categoriy();
            Product[] products = Utitlity.GetProduct();


            var compositekeyJoin = from c in categories
                                   join p in products on new { c.IdCategory, c.Year } equals new { p.IdCategory, p.Year } into productsByCategory
                                   select new
                                   {
                                       c.Name,
                                       c.IdCategory,
                                       data = productsByCategory


                                   };

            foreach (var dd in compositekeyJoin)
            {

                foreach (var d in dd.data)
                {
                    Console.WriteLine(d.Year + " " + d.Description);
                }
            }





        }


        public void LetKeywordWithCount()
        {
            Category[] categories = Utitlity.Categoriy();
            Product[] products = Utitlity.GetProduct();

            var categoriesByProductsNumberQuery = from c in categories
                                                  join p in products on c.IdCategory equals p.IdCategory into categoriesByCategory
                                                  let productCount = categoriesByCategory.Count()
                                                  select new { c.Name, c.IdCategory, productCount };

            foreach (var d in categoriesByProductsNumberQuery)
            {
                Console.WriteLine(d.Name + " " + d.IdCategory + " " + d.productCount);
            }


        }


        public void DefferQueryExpression()
        {
            List<Developer> developers = new List<Developer>(GetDevelopers());
            developers.Add(new Developer() { Age = 10, Language = "JS", Name = "JavaScript" });


            var queary = from q in developers where q.Language == "C#" select q;


            foreach (var q in queary)
            {
                Console.WriteLine(q.Language);
            }


        }


        public void WhereCluseWithCustomers()
        {
            var customer = Utitlity.GetCustomer();

            var wherkey = from c in customer where c.Country == Countries.Italy select new { c.Name, c.Country, c.City };

            foreach (var c in wherkey)
            {
                Console.WriteLine(c.Name + " country = " + c.Country + " City = " + c.City);
            }
        }


        public void CustomerOrders()
        {
            Order[] orders = Utitlity.GetOrders();

            var customerOrderWithCountry = from o in orders
                                           where o.Customer.Country == Countries.Italy
                                           select new
                                           {
                                               o.IdOrder,
                                               o.Customer.Name,
                                               o.Customer.Country,
                                               o.Customer.City,
                                               o.Product.IdProduct,
                                               o.Product.ProductName
                                           };


            foreach (var o in orders)
            {
                Console.WriteLine(o.Product.ProductName + " " + o.IdOrder);
            }
        }


        public void GetOrderingBy()
        {

            Customer[] customers = Utitlity.GetCustomer();

            //var oderingByCustoersCountry = from c in customers where c.Country == Countries.Italy orderby c.Name descending select c;
            var oderingByCustoersCountry = from c in customers where c.Country == Countries.Italy orderby c.Name descending, c.City ascending select c;

            var customer = (from c in customers where c.Country == Countries.Italy orderby c.Name descending select c).Reverse();

            foreach (var r in oderingByCustoersCountry)
            {
                Console.WriteLine(r);
            }
        }


        public void GetSelectQuery()
        {

            Customer[] customers = Utitlity.GetCustomer();

            var customerWithNameSelect = customers.Select(c => c.Name);

            var customerWithNameCitySelect = customers.Select(c => new { c.Name, c.City });

            var customerWithIndexAndValue = customers.Select((val, index) => new { Name = val.Name, City = val.City, index });


            foreach (var item in customerWithIndexAndValue)
            {
                Console.WriteLine(item);
            }


        }


        public void TwoMoreTableJoin()
        {
            var orders = Utitlity.GetOrders();
            var products = Utitlity.GetProduct();
            var category = Utitlity.Categoriy();

            var joinsTwoMore = from o in orders join p in products on o.IdProduct equals p.IdProduct join cat in category on p.IdCategory equals cat.IdCategory select new { OrderId = o.IdOrder, ProductId = o.IdProduct, CategoryId = cat.IdCategory, CategoryName = cat.Name };


            foreach (var item in joinsTwoMore)
            {
                Console.WriteLine(item);
            }

        }


        public void GetJoinDataToTable()
        {
            Customer[] customers = Utitlity.GetCustomer();
            Product[] products = Utitlity.GetProduct();

            var customerOrders = from cus in customers
                                 from o in cus.Orders
                                 join p in products on o.IdProduct equals p.IdProduct
                                 select new { Name = cus.Name, OrderAmount = o.Quantity * p.Price };


            var joinTwoTables = (from cus in customers
                                 from o in cus.Orders
                                 select o.Quantity).Min();

            var avarageProduct = (from p in products select p.Price).Average();

            var avarageProudctWithQty = (from p in products select new { p.Price, p.IdProduct }).Average(p => p.Price);

            //foreach(var c in customerOrders)
            //{
            //    Console.WriteLine(c);
            //}

            Console.WriteLine(joinTwoTables);

        }


        public void GroupJoiningBySubQueryOrJoinKeyWord()
        {

            Customer[] customers = Utitlity.GetCustomer();
            Product[] products = Utitlity.GetProduct();


            var customerOrders = from c in customers from o in c.Orders select o;

            var joiningCustomerOrders = from p in products join o in customerOrders on p.IdProduct equals o.IdProduct select new { p.IdProductId, o.IdOrder, p.ProductName, o.Description };


            var joinWithNestedQuery = from p in products
                                      join o in (
                                        from c in customers from o in c.Orders select o
                                      ) on p.IdProduct equals o.IdProduct
                                      select new
                                      {
                                          p.IdProductId,
                                          o.IdOrder,
                                          p.ProductName,
                                          o.Description

                                      };


            var customersOrders =
                    from c in customers
                    from o in c.Orders
                    join p in products
                    on o.IdProduct equals p.IdProduct
                    select new { c.Name, OrderAmount = o.Quantity * p.Price };




            var expr =
               from c in customers
               join o in customersOrders
               on c.Name equals o.Name
               into customersWithOrders
               select new
               {
                   c.Name,
                   TotalAmount = customersWithOrders.Sum(o => o.OrderAmount)
               };


            var expr1 =
                       from c in customers
                       join o in (
                       from c in customers
                       from o in c.Orders
                       join p in products
                       on o.IdProduct equals p.IdProduct
                       select new { c.Name, OrderAmount = o.Quantity * p.Price }
                       ) on c.Name equals o.Name
                       into customersWithOrders
                       select new
                       {
                           c.Name,
                           TotalAmount = customersWithOrders.Sum(o => o.OrderAmount)
                       };






        }


        public void SomeMehodUseInLinq()
        {
            Customer[] customers = Utitlity.GetCustomer();
            Product[] products = Utitlity.GetProduct();

            var minmum =
                     (from c in customers
                      from o in c.Orders
                      select o.Quantity
                     ).Min();

            var maximum =
                    (from c in customers
                     from o in c.Orders
                     select o.Quantity
                    ).Max();

            var minimumQuery =
                (from c in customers
                 from o in c.Orders
                 select new { o.IdProduct, o.Quantity }
                ).Min();

            var maximumQuery =
               (from c in customers
                from o in c.Orders
                select new { o.IdProduct, o.Quantity }
               ).Max();


            var minimumQuntiyWithAggrigate =
                        (from c in customers
                         from o in c.Orders
                         select new { o.IdProduct, o.Quantity }
                        ).Min(o => o.Quantity);

            var avgProducts =
                        (from p in products
                         select p.Price
                        ).Average();
            var avgProductAggrigate =
                    (from p in products
                     select new { p.IdProduct, p.Price }
                    ).Average(p => p.Price);



            var customersWithOrderss =
                        from c in customers
                        join o in (
                                from c in customers
                                from o in c.Orders
                                join p in products
                                on o.IdProduct equals p.IdProduct
                                select new { c.Name, OrderAmount = o.Quantity * p.Price }
                        ) on c.Name equals o.Name
                        into customersWithOrders
                        select new
                        {
                            c.Name,
                            AverageAmount = customersWithOrders.Average(o => o.OrderAmount)
                        };



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
                                OrderAmount = o.Quantity * p.Price
                            }
                            ) on c.Name equals o.Name
                            into orders
                            select new
                            {
                                c.Name,
                                MaxOrderAmount =
                            orders
                            .Aggregate((a, o) => a.OrderAmount > o.OrderAmount ?
                            a : o)
                            .OrderAmount
                            };
        }
    }
}
