using MediatR;
using Microsoft.AspNetCore.Http;

namespace Shop.Application.ProductAgg.AddImage
{
    public class AddImageCommand:IRequest
    {
        public AddImageCommand() { }
        public AddImageCommand(long productId,  IFormFile image)
        {
            ProductId = productId;
            Image = image;
        }
        public long ProductId { get;  set; }
        public IFormFile Image { get;  set; }
    }
}
