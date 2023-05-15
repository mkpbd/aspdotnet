using DominDrevenDesign.Domin;

namespace DominDrevenDesign
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");

            Account account = new Account();
            account.Id = 1;
            account.Balance = 200;
            account.Name = "kamal";
            account.Description = "Saving Account";

            List<Account> accounts = new List<Account>()
            {
                new Account()
                {
                    Id = 2,
                    Balance = 500,
                    Name= "borhan",
                    Description= "current account"
                },

                new Account()
                {
                    Id= 3,
                    Balance = 500,
                    Name = "kabir",
                    Description="primary Account"
                },
                new Account()
                {
                    Id= 3,
                    Balance = 500,
                    Name = "samim",
                    Description="primary Account"
                }

            };
            

        }
    }
}