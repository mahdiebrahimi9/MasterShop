using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Shop.Application._Shared;
using Shop.Application._Shared.Exceptions;
using Shop.Application.ProductAgg.Edit;
using Shop.Domain.ProductsAgg;

namespace Shop.Application.ProductAgg.EditFaq
{
    public class EditFaqCommandHandler : IRequestHandler<EditFaqCommand>
    {
        private readonly IRepository<Product> _repository;

        public EditFaqCommandHandler(IRepository<Product> repository)
        {
            _repository = repository;
        }

        public async Task Handle(EditFaqCommand request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetByIdAsync(request.ProductId);
            if (product == null)
            {
                throw new InvalidApplicationDataException("ایدی وارد شده نامعتبر یا موجود نمی باشد");
            }
            product.EditFaq(request.ProductId, new Faq(request.Question, request.UserName));
            await _repository.Save();
        }
    }
}
