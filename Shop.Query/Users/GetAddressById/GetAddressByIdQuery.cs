using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Shop.Query.Users.DTOs;

namespace Shop.Query.Users.GetAddressById
{
    public record GetAddressByIdQuery(long addressId) : IRequest<GetAddressListDto>;
}
