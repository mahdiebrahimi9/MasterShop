using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Shop.Application.ProductAgg.EditFaq
{
    public class EditFaqCommandValidator:AbstractValidator<EditFaqCommand>
    {
        public EditFaqCommandValidator()
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
