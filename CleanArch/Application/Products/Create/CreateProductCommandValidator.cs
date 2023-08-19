
using FluentValidation;

namespace Application.Command.Products.Create
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(t => t.Title)
                .MinimumLength(3).WithMessage("عنوان باید حداقل 3 کاراکتر باشد")
                .MaximumLength(50).WithMessage("عنوان باید حداقل 50 کاراکتر باشد");

            RuleFor(p => p.Price)
                .GreaterThan(0).WithMessage("قیمت باید بیشتر از 0 باشد");
        }
    }
}
