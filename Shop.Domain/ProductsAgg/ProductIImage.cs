using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Domain.Shared.Exceptions;

namespace Shop.Domain.ProductsAgg
{
    public class ProductIImage
    {
        public ProductIImage(string name, string image)
        {
            NullOrEmptyDomainDataException.CheckString(name, nameof(name));
            NullOrEmptyDomainDataException.CheckString(image, nameof(image));
            Name = name;
            Image = image;
        }

        public long ProductId { get; internal set; }
        public string Name { get; private set; }
        public string Image { get; private set; }
    }
}
