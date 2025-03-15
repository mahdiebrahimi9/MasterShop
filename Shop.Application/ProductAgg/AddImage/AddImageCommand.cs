using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Shop.Application.ProductAgg.AddImage
{
    public class AddImageCommand:IRequest
    {
        public AddImageCommand(long productId,  IFormFile image)
        {
            ProductId = productId;
            Image = image;
        }
        public long ProductId { get;  set; }
        public IFormFile Image { get;  set; }
    }
}
