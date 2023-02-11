using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EfCoreWebApps.Core.Entities
{
    [Table("Persons", Schema = "dbo")]
    public class Person
    {
        [Column("Person_Id"), Key]
        public int Id { get; set; }
        [Required, MaxLength(255), Column(TypeName = "varchar(255)")]
        public string FirstName { get; set; }
        [Required, MaxLength(255), Column(TypeName = "varchar(255)")]
        public string LastName { get; set; }
        [Required, MaxLength(255), Column(TypeName = "varchar(255)")]
        public string EmailAddress { get; set; }
        public string EmailAddresss { get; set; }

        [NotMapped]
        public string FullName => $"{FirstName} {LastName}";



        //This will allow a  person to have one-to-many address records associated with them
        public List<Address> Addresses { get; set; } = new List<Address>();
    }
}
