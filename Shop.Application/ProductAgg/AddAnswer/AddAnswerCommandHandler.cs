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
        private readonly IRepository<Faq> _faqRepository;

        public AddAnswerCommandHandler(IRepository<Faq> faqRepository)
        {
            _faqRepository = faqRepository;
        }

        public async Task Handle(AddAnswerCommand request, CancellationToken cancellationToken)
        {
            var faq = await _faqRepository.GetByIdAsync(request.FaqId);
            if (faq == null)
            {
                throw new InvalidApplicationDataException("ایدی وارد شده نامعتبر یا موجود نمی باشد");
            }
            faq.Answer.Add(new Answer(request.AnswerFaq));
            await _faqRepository.Save();

        }
    }
}
