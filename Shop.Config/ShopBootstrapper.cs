using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Application.FileUtil.Interfaces;
using Common.Application.FileUtil.Services;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shop.Application._Shared;
using Shop.Application.ProductAgg.AddComment;
using Shop.Application.ProductAgg.Create;
using Shop.Domain.ProductsAgg;
using Shop.Infra.Persestent.Dapper;
using Shop.Infra.Persestent.Ef;
using Shop.Infra.Persestent.Ef.ProductAgg.Faqs;
using Shop.Infra.Persestent.Ef.UsersAgg;
using Shop.Query.Products.GetProductList;

namespace Shop.Config
{
    public static class ShopBootstrapper
    {
        public static void Init(this IServiceCollection service, string connectionString)
        {
            service.AddScoped<IRepository<Product>, ProductRepository>();
            service.AddScoped<IRepository<Faq>, FaqRepository>();
            service.AddScoped<IFileService, FileService>();
            service.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));


            service.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateProductCommandHandler).Assembly));
            service.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetProductListQueryHandler).Assembly));

            service.AddValidatorsFromAssembly(typeof(AddCommentCommandValidator).Assembly);

            service.AddControllers()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<AddCommentCommandValidator>());

            service.AddSingleton<DapperContext>(option =>
            {
                return new DapperContext(connectionString);  
            });

            service.AddDbContext<ShopContext>(option =>
            {
                option.UseSqlServer(connectionString);
            });
        }
    }
}
