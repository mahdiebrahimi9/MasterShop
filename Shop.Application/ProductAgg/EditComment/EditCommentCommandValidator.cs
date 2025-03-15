using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Shop.Application.ProductAgg.EditComment
{
    public class EditCommentCommandValidator : AbstractValidator<EditCommentCommand>
    {
        public EditCommentCommandValidator()
        {
            RuleFor(r => r.UserComment)
                .NotNull()
                .NotEmpty()
                .WithMessage("کامنت نباید خالی باشد");

            RuleFor(r => r.UserName)
                .NotNull()
                .NotEmpty()
                .WithMessage("نام کاربری نباید خالی باشد");
        }
    }
}
