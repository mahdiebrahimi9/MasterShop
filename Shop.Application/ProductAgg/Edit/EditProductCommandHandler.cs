using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Shop.Application._Shared;
using Shop.Application._Shared.Exceptions;
using Shop.Domain._Shared.Exceptions;
using Shop.Domain.ProductsAgg;

namespace Shop.Application.ProductAgg.Edit
{
    public class EditProductCommandHandler : IRequestHandler<EditProductCommand>
    {
        private readonly IRepository<Product> _repository;

        public EditProductCommandHandler(IRepository<Product> repository)
        {
            _repository = repository;
        }

        public async Task Handle(EditProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetByIdAsync(request.ProductId);

            if (product == null)
            {
                throw new InvalidApplicationDataException("ایدی وارد شده نامعتبر یا موجود نمی باشد");
            }

            product.Edit(request.ProductName, request.ProductCode, request.ProductPrice, request.Count,
                request.TotalRate, request.Title, request.Description, request.Color, request.Category
                , request.BestSelling, request.Design, request.PurchaseValue, request.BuildQuality, request.Featured,
                request.ProductDiscount);
            await _repository.UpdateAsync(product);
            await _repository.Save();
        }
    }
}
