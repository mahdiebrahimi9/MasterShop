using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Shop.Application.UserAgg.Remove
{
    public record RemoveUserCommand(long userId) : IRequest;
}
