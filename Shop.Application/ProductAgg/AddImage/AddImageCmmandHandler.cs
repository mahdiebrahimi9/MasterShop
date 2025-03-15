using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Application.FileUtil.Interfaces;
using MediatR;
using Shop.Application._Shared;
using Shop.Application._Shared.Exceptions;
using Shop.Domain.ProductsAgg;

namespace Shop.Application.ProductAgg.AddImage
{
    public class AddImageCmmandHandler : IRequestHandler<AddImageCommand>
    {
        private readonly IRepository<Product> _repository;
        private readonly IFileService _fileService;
        public AddImageCmmandHandler(IRepository<Product> repository, IFileService fileService)
        {
            _repository = repository;
            _fileService = fileService;
        }

        public async Task Handle(AddImageCommand request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetByIdAsync(request.ProductId);
            if (product == null)
            {
                throw new InvalidApplicationDataException("ایدی وارد شده نامعتبر یا موجود نمی باشد");
            }

            var imageName = await _fileService.SaveFileAndGenerateName(request.Image, Directories.ProductImage);
            product.AddImage(new ProductIImage(imageName));
            await _repository.Save();
        }
    }
}
