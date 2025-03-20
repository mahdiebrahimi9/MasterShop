using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Application.FileUtil.Interfaces;
using MediatR;
using Shop.Application._Shared;
using Shop.Application._Shared.Exceptions;
using Shop.Domain.UserAgg;

namespace Shop.Application.UserAgg.Edit
{
    public class EditUserCommandHandler : IRequestHandler<EditUserCommand>
    {
        private readonly IRepository<User> _userRepository;
        private readonly IFileService _fileService;

        public EditUserCommandHandler(IRepository<User> userRepository, IFileService fileService)
        {
            _userRepository = userRepository;
            _fileService = fileService;
        }

        public async Task Handle(EditUserCommand request, CancellationToken cancellationToken)
        {
            var profileImage =
                await _fileService.SaveFileAndGenerateName(request.ProfileImage, Directories.UserProfile);

            var user = await _userRepository.GetByIdAsync(request.UserId);
            if (user == null)
                throw new InvalidApplicationDataException("ایدی وارد شده نامعتبر یا موجود نمی باشد");
            user.Edit(request.UserName, request.Email, request.Phone, request.NationalCode, profileImage,
                request.BankCardNumber);

            await _userRepository.Save();
        }
    }
}
