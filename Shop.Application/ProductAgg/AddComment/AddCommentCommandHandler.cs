using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Shop.Application._Shared;
using Shop.Domain.ProductsAgg;

namespace Shop.Application.ProductAgg.AddComment
{
    public class AddCommentCommandHandler : IRequestHandler<AddCommentCommand>
    {
        private readonly IRepository<Comment> _repository;

        public AddCommentCommandHandler(IRepository<Comment> repository)
        {
            _repository = repository;
        }

        public async Task Handle(AddCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = new Comment(request.Rate, request.UserName, request.UserComment);
            await _repository.AddAsync(comment);
            await _repository.Save();
        }
    }
}
