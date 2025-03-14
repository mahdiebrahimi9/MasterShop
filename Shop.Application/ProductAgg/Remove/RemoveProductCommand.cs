using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Shop.Application.ProductAgg.Remove
{
    public record RemoveProductCommand(long id) : IRequest;
}
