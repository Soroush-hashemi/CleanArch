using FluentValidation;

namespace Application.Command.Products.Edit
{
    public class EditProductCommandValidator : AbstractValidator<EditProductCommand>
    {
        public EditProductCommandValidator()
        {
            RuleFor(t => t.Title)
                .MinimumLength(3).WithMessage("عنوان باید حداقل 3 کاراکتر باشد")
                .MaximumLength(50).WithMessage("عنوان باید حداکثر 50 کاراکتر باشد");

            RuleFor(p => p.Price)
                .GreaterThan(0).WithMessage("قیمت معتبر نیست");
               
                
        }
    }
}
