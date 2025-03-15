using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Shop.Application._Shared;
using Shop.Application._Shared.Exceptions;
using Shop.Domain.ProductsAgg;

namespace Shop.Application.ProductAgg.RemoveFaq
{
    public class RemoveFaqCommandHandler : IRequestHandler<RemoveFaqCommand>
    {
        private readonly IRepository<Product> _repository;

        public RemoveFaqCommandHandler(IRepository<Product> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveFaqCommand request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetByIdAsync(request.productId);
            if (product == null)
            {
                throw new InvalidApplicationDataException("ایدی وارد شده نامعتبر یا موجود نمی باشد");
            }
            product.RemoveFaq(request.productId);
           await _repository.Save();
        }
    }
}
