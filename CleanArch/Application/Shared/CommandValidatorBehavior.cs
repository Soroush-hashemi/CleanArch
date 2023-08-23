using FluentValidation;
using MediatR;
using System.Text;

namespace Application.Command.Shared;
public class CommandValidatorBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;
    private readonly Dictionary<string, int> _errorCounts = new Dictionary<string, int>();
    /* _errorCounts
    * یک دیکشنری است که برای هر خطای اعتبارسنجی، 
    * تعداد تکرار آن خطا در درخواست را ذخیره می‌کند.
    * به این ترتیب، اگر یک خطا اعتبارسنجی دو بار یا بیشتر در درخواست تکرار شده باشد، تعداد تکرار آن افزایش می‌یابد.
    */
    public CommandValidatorBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        foreach (var validator in _validators) 
        {
            var validationResult = validator.Validate(request); // اینجا نوبتی قیمت و عنوان میان داخل حلقه

            foreach (var error in validationResult.Errors)
            {
                if (_errorCounts.ContainsKey(error.ErrorMessage)) // ایا خطای مورد نطر قبلا در دیکشنری سیو شده یا نه ؟
                {
                    _errorCounts[error.ErrorMessage]++; //این کد به منظور افزایش تعداد تکرار یک خطا در دیکشنری استفاده میشود 
                }
                else
                {
                    _errorCounts[error.ErrorMessage] = 1;
                }
            }
        }

        var errorsToShow = _errorCounts.Where(kv => kv.Value > 1).Select(kv => kv.Key).ToList(); // لیستی از خطا هارو دریافت میکنه 

        if (errorsToShow.Any())
        {
            var stringBuilder = new StringBuilder();
            foreach (var error in errorsToShow)
            {
                stringBuilder.AppendLine(error); // خطا هارو از هم حدا و در چند چند خط نشون میده 
            }
            throw new InvalidOperationException(stringBuilder.ToString());
        }

        _errorCounts.Clear(); // خطا ها اینجا کامل پاک میشن

        var Response = await next();
        return Response;
    }
}