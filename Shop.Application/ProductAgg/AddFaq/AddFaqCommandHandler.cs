using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Shop.Application._Shared;
using Shop.Application._Shared.Exceptions;
using Shop.Domain.ProductsAgg;

namespace Shop.Application.ProductAgg.AddFaq
{
    public class AddFaqCommandHandler : IRequestHandler<AddFaqCommand>
    {
        private readonly IRepository<Product> _productRepository;

        public AddFaqCommandHandler(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task Handle(AddFaqCommand request, CancellationToken cancellationToken)
        {
            var productFaq = await _productRepository.GetByIdAsync(request.ProductId);
            if (productFaq == null)
            {
                throw new InvalidApplicationDataException("ایدی وارد شده نامعتبر یا موجود نمی باشد");
            }
            productFaq.AddFaq(new Faq(request.Question, request.UserName));
            await _productRepository.Save();
        }
    }
}
