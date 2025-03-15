using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Shop.Application._Shared;
using Shop.Application._Shared.Exceptions;
using Shop.Domain.ProductsAgg;

namespace Shop.Application.ProductAgg.RemoveComment
{
    internal class RemoveCommentCommandHandler : IRequestHandler<RemoveCommentCommand>
    {
        private readonly IRepository<Product> _repository;

        public RemoveCommentCommandHandler(IRepository<Product> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = await _repository.GetByIdAsync(request.productId);
            if (comment == null)
            {
                throw new InvalidApplicationDataException("ایدی وارد شده نامعتبر یا موجود نمی باشد");
            }
            comment.RemoveComment(request.productId);
            await _repository.Save();
        }
    }
}
