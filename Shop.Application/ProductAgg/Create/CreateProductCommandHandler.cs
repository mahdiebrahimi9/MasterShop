using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Shop.Application._Shared;
using Shop.Domain.ProductsAgg;

namespace Shop.Application.ProductAgg.Create
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand>
    {
        private readonly IRepository<Product> _repository;

        public CreateProductCommandHandler(IRepository<Product> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product(request.ProductName, request.ProductCode, request.ProductPrice, request.Count,
                request.TotalRate, request.Title, request.Description, request.Color, request.Category
                , request.BestSelling, request.Design, request.PurchaseValue, request.BuildQuality, request.Featured,
                request.ProductDiscount);

           await _repository.AddAsync(product);
            await _repository.Save();
        }
    }
}
