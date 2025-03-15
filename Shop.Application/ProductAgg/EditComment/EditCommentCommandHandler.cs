using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Shop.Application._Shared;
using Shop.Application._Shared.Exceptions;
using Shop.Domain.ProductsAgg;

namespace Shop.Application.ProductAgg.EditComment
{
    public class EditCommentCommandHandler : IRequestHandler<EditCommentCommand>
    {
        private readonly IRepository<Product> _commentRepository;

        public EditCommentCommandHandler(IRepository<Product> commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task Handle(EditCommentCommand request, CancellationToken cancellationToken)
        {
            var productComment = await _commentRepository.GetByIdAsync(request.ProductId);

            if (productComment == null)
            {
                throw new InvalidApplicationDataException("ایدی وارد شده نامعتبر یا موجود نمی باشد");
            }
            productComment.EditComment(request.ProductId, new Comment(request.Rate, request.UserComment, request.UserName));
            await _commentRepository.Save();
        }
    }
}
