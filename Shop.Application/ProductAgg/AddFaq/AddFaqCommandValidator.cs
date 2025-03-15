using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;

namespace Shop.Application.ProductAgg.AddFaq
{
    public class AddFaqCommandValidator : AbstractValidator<AddFaqCommand>
    {
        public AddFaqCommandValidator()
        {
            RuleFor(r => r.Question)
                .NotEmpty()
                .NotNull()
                .WithMessage("سوال نباید خالی باشد");

            RuleFor(r => r.UserName)
                .NotEmpty()
                .NotNull()
                .WithMessage("نام کاربری نباید خالی باشد");
        }
    }
}
