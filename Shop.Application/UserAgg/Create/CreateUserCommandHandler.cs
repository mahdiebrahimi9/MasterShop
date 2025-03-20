using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Application.FileUtil.Interfaces;
using MediatR;
using Shop.Application._Shared;
using Shop.Domain.UserAgg;

namespace Shop.Application.UserAgg.Create
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand>
    {
        private readonly IRepository<User> _userRepository;
        private readonly IFileService _fileService;
        public CreateUserCommandHandler(IRepository<User> userRepository, IFileService fileService)
        {
            _userRepository = userRepository;
            _fileService = fileService;
        }

        public async Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var profileImage =
                await _fileService.SaveFileAndGenerateName(request.ProfileImage, Directories.UserProfile);
            var user = new User(request.UserName, request.Email, request.Phone, request.NationalCode, profileImage,
                request.BankCardNumber);
            await _userRepository.AddAsync(user);
            await _userRepository.Save();
        }
    }
}
