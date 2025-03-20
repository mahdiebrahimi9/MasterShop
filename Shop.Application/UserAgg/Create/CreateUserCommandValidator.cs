using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Shop.Application.UserAgg.Create
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(f => f.UserName)
                .NotNull()
                .NotEmpty()
                .WithMessage("نام کاربری نامعتبر می باشد ");

            RuleFor(f => f.Phone)
                .NotNull()
                .NotEmpty()
                .WithMessage(" شماره موبایل نامعتبر می باشد ");

            RuleFor(f => f.Email)
                .NotNull()
                .NotEmpty()
                .WithMessage(" ایمیل  نامعتبر می باشد ");

            RuleFor(f => f.NationalCode)
                .NotNull()
                .NotEmpty()
                .WithMessage(" کدملی  نامعتبر می باشد ");


            RuleFor(f => f.BankCardNumber)
                .NotNull()
                .NotEmpty()
                .WithMessage(" شماره کارت نامعتبر می باشد ");

        }
    }
}
