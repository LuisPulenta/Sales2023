﻿using Sales2023.Shared.Entities;

namespace Sales2023.Shared.Entities
{
    public class ProductCategory
    {
        public int Id { get; set; }

        public Product Product { get; set; } = null!;

        public int ProductId { get; set; }

        public Category Category { get; set; } = null!;

        public int CategoryId { get; set; }
    }
}