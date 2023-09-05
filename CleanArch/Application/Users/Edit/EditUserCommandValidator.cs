using FluentValidation;

namespace Application.Command.Users.Edit;

public class EditUserCommandValidator : AbstractValidator<EditUserCommand>
{
    public EditUserCommandValidator()
    {
        RuleFor(n => n.Name)
            .MinimumLength(3).WithMessage("نام باید حداقل 3 کاراکتر باشد")
            .MaximumLength(50).WithMessage("نام باید حداکثر 50 کاراکتر باشد");

        RuleFor(n => n.Family)
            .MinimumLength(3).WithMessage("نام‌خانوادگی باید حداقل 3 کاراکتر باشد")
            .MaximumLength(50).WithMessage("نام‌خانوادگی باید حداکثر 50 کاراکتر باشد");

        RuleFor(n => n.Email)
            .MinimumLength(10).WithMessage("ایمیل باید حداقل 10 کاراکتر باشد")
            .MaximumLength(70).WithMessage("ایمیل باید حداکثر 50 کاراکتر باشد");
    }
}