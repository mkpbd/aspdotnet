using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DominDrevenDesign.Domin
{
    /// <summary>
    /*** This class represents an account in the banking domain. 
    It has three properties: Id, Name, and Balance.The Id property is the unique identifier for the account. 
The Name property is the name of the account holder. The Balance property is the current balance of the account.


    This is just a simple example of how DDD can be used to develop software applications. 
DDD is a powerful approach to software development that can help to create software that is more accurate, reliable, and maintainable. **/
    /// </summary>
    public class Account
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Balance { get; set; }
    }
}
