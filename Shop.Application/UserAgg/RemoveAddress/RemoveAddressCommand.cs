using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Shop.Application.UserAgg.RemoveAddress
{
    public record RemoveAddressCommand(long userId, long addressId) : IRequest;
}
