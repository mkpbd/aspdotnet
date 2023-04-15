using Azure;
using Microsoft.VisualBasic;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace EfCore.Models
{
    public class Book
    {
        public int BookId { get; set; }

        public PriceOffer Promotion { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<Tag> Tags { get; set; }
        public ICollection<BookAuthor>
        AuthorsLink
        { get; set; }

    }
}
