﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shop.Domain.ProductsAgg;

namespace Shop.Infra.Persestent.Ef
{
    public class ShopContext : DbContext
    {
        public ShopContext(DbContextOptions<ShopContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Faq> Faqs { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<ProductIImage> ProductIImages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ShopContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
