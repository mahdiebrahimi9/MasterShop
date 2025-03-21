﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Shop.Application._Shared;
using Shop.Application._Shared.Exceptions;
using Shop.Domain.ProductsAgg;

namespace Shop.Application.ProductAgg.AddComment
{
    public class AddCommentCommandHandler : IRequestHandler<AddCommentCommand>
    {
        private readonly IRepository<Product> _repository;

        public AddCommentCommandHandler(IRepository<Product> repository)
        {
            _repository = repository;
        }

        public async Task Handle(AddCommentCommand request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetByIdAsync(request.ProductId);
            if (product == null)
            {
                throw new InvalidApplicationDataException("ایدی وارد شده نامعتبر یا موجود نمی باشد");
            }
            product.AddComment(new Comment(request.Rate, request.UserName, request.UserComment));

            await _repository.Save();
        }
    }
}
