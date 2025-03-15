using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Shop.Application._Shared;
using Shop.Domain.ProductsAgg;

namespace Shop.Application.ProductAgg.AddImage
{
    public class AddImageCmmandHandler : IRequestHandler<AddImageCommand>
    {
        private readonly IRepository<Product> _repository;
        private readonly ImageUploader _imageUploader;
        public AddImageCmmandHandler(IRepository<Product> repository, ImageUploader imageUploader)
        {
            _repository = repository;
            _imageUploader = imageUploader;
        }

        public async Task Handle(AddImageCommand request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetByIdAsync(request.ProductId);
            if (product == null)
            {
            }

            var folderPath = new ImageUploader(Directories.ProductImage);
            _imageUploader.UploadImageAsync()
            product.AddImage();
        }
    }
}
