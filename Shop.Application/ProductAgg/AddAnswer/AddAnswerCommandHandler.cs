using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Shop.Application._Shared;
using Shop.Application._Shared.Exceptions;
using Shop.Domain.ProductsAgg;
using Shop.Domain.ProductsAgg.ValueObjects;

namespace Shop.Application.ProductAgg.AddAnswer
{
    public class AddAnswerCommandHandler : IRequestHandler<AddAnswerCommand>
    {
        private readonly IRepository<Product> _repository;

        public AddAnswerCommandHandler(IRepository<Product> repository)
        {
            _repository = repository;
        }

        public async Task Handle(AddAnswerCommand request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetByIdAsync(request.ProductId);
            if (product == null)
            {
                throw new InvalidApplicationDataException("محصول وارد شده نامعتبر یا موجود نمی‌باشد");
            }

            var faq = product.Faqs.FirstOrDefault(f => f.Id == request.FaqId);
            if (faq == null)
            {
                throw new InvalidApplicationDataException("ایدی سوال وارد شده نامعتبر یا موجود نمی‌باشد");
            }
            faq.AddAnswer(new Answer(request.AnswerFaq));
            await _repository.Save();
        }
    }
}
