﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Catalog.Domain
{
    public class Review
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public int NumberOfStars { get; set; }
        public string? ReviewText { get; set; }
        public int  ProductId { get; set; }
        public Product? Product { get; set; }

    }
}
