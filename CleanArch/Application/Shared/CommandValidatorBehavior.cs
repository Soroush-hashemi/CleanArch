using Application.Command.Products.Create;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Application.Command.Shared
{
    public class CommandValidatorBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;
        public CommandValidatorBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var Errors = _validators.Select(v => v.Validate(request))
                .SelectMany(res => res.Errors)
                .Where(r => r is not null);

            if (Errors.Any())
            {
                var StringBuilder = new StringBuilder();
                foreach (var error in Errors)
                {
                    StringBuilder.AppendLine(error.ErrorMessage);
                }
                throw new InvalidOperationException(StringBuilder.ToString());
            }

            var Response = await next();
            return Response;
        }
    }
}
