using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Shop.Application._Shared;
using Shop.Application._Shared.Exceptions;
using Shop.Domain.UserAgg;

namespace Shop.Application.UserAgg.AddAddress
{
    public class AddAddressCommandHandler : IRequestHandler<AddAddressCommand>
    {
        private readonly IRepository<User> _userRepository;

        public AddAddressCommandHandler(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task Handle(AddAddressCommand request, CancellationToken cancellationToken)
        {
            var userAddress = await _userRepository.GetByIdAsync(request.UserId);
            if (userAddress == null)
                throw new InvalidApplicationDataException("ایدی وارد شده نامعتبر یا موجود نمی باشد");
            userAddress.AddAddress(new UserAddress(request.ReceiverName, request.ReceiverPhone, request.ReceiverProvince, request.ReceiverCity
            , request.ReceiverPostalAddress, request.ReceiverPostalCode));

            await _userRepository.Save();
        }
    }
}
