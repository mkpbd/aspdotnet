using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Review.Domain
{
    public class Product
    {

        public int Id { get; set; }

        // Reviews 
        public List<Review> Reviews { get; set; } = new();
        public decimal ReviewAverage { get; set; }
    }
}
