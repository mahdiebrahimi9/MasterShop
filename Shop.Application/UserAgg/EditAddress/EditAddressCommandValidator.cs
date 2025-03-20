using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Shop.Application.UserAgg.EditAddress
{
    public class EditAddressCommandValidator:AbstractValidator<EditAddressCommand>
    {
        public EditAddressCommandValidator()
        {
            RuleFor(r => r.ReceiverName)
                .NotNull()
                .NotEmpty()
                .WithMessage("نام  نامعتبر است");

            RuleFor(r => r.ReceiverCity)
                .NotNull()
                .NotEmpty()
                .WithMessage("شهر نامعتبر است");

            RuleFor(r => r.ReceiverPhone)
                .NotNull()
                .NotEmpty()
                .WithMessage("شماره تلفن نامعتبر است");

            RuleFor(r => r.ReceiverPostalAddress)
                .NotNull()
                .NotEmpty()
                .WithMessage("آدرس پستی نامعتبر است");

            RuleFor(r => r.ReceiverPostalCode)
                .NotNull()
                .NotEmpty()
                .WithMessage("کد پستی نامعتبر است");

            RuleFor(r => r.ReceiverProvince)
                .NotNull()
                .NotEmpty()
                .WithMessage("استان نامعتبر است");
        }
    }
}
