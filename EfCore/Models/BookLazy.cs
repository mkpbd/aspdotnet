namespace EfCore.Models
{
    public class BookLazy
    {
        public int BookLazyId { get; set; }
        //… Other properties left out for clarity
        public virtual PriceOffer Promotion { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<BookAuthor> AuthorsLink { get; set; }
    }
}
