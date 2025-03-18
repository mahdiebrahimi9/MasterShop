using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.ProductsAgg;

namespace Shop.Infra.Persestent.Ef.UsersAgg
{
    public class UserConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products", "Product");


            builder.OwnsOne(f => f.ProductPrice);

            builder.OwnsOne(f => f.ProductDiscount);

            builder.OwnsMany(f => f.Comments, option =>
            {
                option.ToTable("Comments", "Product");
            });

            builder.OwnsMany(f => f.Faqs, option =>
            {
                option.ToTable("Faqs", "Product");

                option.HasKey(faq => faq.Id);

                option.OwnsMany(faq => faq.Answer, answersOption =>
                {
                    answersOption.ToTable("Answers", "Faq");

                    answersOption.HasKey(answer => answer.AnswerId);
                });
            });


            builder.OwnsMany(f => f.Images, option =>
            {
                option.ToTable("Images", "Product");
            });
        }
    }
}
