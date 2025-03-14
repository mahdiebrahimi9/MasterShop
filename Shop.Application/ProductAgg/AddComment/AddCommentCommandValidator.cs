using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Shop.Application.ProductAgg.AddComment
{
    public class AddCommentCommandValidator : AbstractValidator<AddCommentCommand>
    {
        public AddCommentCommandValidator()
        {
            RuleFor(r => r.UserComment)
                .NotEmpty()
                .NotNull()
                .WithMessage("کامنت نباید خالی باشد");

            RuleFor(r => r.UserName)
                .NotEmpty()
                .NotNull()
                .WithMessage("نام کاربری نباید خالی باشد");
        }
    }
}
