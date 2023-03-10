using FluentValidation;
using MediatR;

namespace DDDValidationsDemo.App.UseCases
{
    public abstract class BaseCommandHandler<TRequest, TResponse> : IRequestHandler<TRequest, Maybe<TResponse>>
        where TRequest : IRequest<Maybe<TResponse>>
    {
        private readonly IValidator<TRequest> _validator;

        public BaseCommandHandler(IValidator<TRequest> validator)
        {
            _validator = validator;
        }
        public async Task<Maybe<TResponse>> Handle(TRequest request, CancellationToken cancellationToken)
        {
            var context = new ValidationContext<TRequest>(request);

            var errorsDictionary = _validator.Validate(context).Errors
                .Where(x => x != null)
                .GroupBy(
                    x => x.PropertyName,
                    x => x.ErrorMessage,
                    (propertyName, errorMessages) => new
                    {
                        Key = propertyName,
                        Values = errorMessages.Distinct().ToArray()
                    })
                .ToDictionary(x => x.Key, x => x.Values);

            if (errorsDictionary.Any())
            {
                return Maybe<TResponse>.Problem(errorsDictionary);
            }

            return await ExecuteCommand(request, cancellationToken);
        }

        public abstract Task<Maybe<TResponse>> ExecuteCommand(TRequest command, CancellationToken cancellation);
    }
}