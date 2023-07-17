using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace IdentityFaremwork.Models
{
    public class ApplicationUser : IdentityUser
    {
        public  string  FiristName { get; set; }
        public string  LastName { get; set; }
        public string  Phone { get; set; }
    }
}
