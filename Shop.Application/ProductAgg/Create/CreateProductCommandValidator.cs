using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Shop.Application.ProductAgg.Create
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {

            RuleFor(r => r.ProductName)
                .NotNull()
                .NotEmpty()
                .WithMessage("نام محصول نمی تواند خالی باشد");

            RuleFor(r => r.Title)
                .NotNull()
                .NotEmpty()
                .WithMessage("عنوان محصول نمی تواند خالی باشد");

            RuleFor(r => r.Description)
                .NotNull()
                .NotEmpty()
                .WithMessage("توضیحات محصول نمی تواند خالی باشد");

            RuleFor(r => r.Category)
                .NotNull()
                .NotEmpty()
                .WithMessage("دسته بندی محصول نمی تواند خالی باشد");

            RuleFor(r => r.Color)
                .NotNull()
                .NotEmpty()
                .WithMessage("رنگ محصول نمی تواند خالی باشد");
        }
    }
}
