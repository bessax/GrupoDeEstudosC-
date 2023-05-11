namespace ByteBank.Application.Middlewares;

public class ValidationBehavior<TRequest, TResponse>
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : ResultBase<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        var context = new ValidationContext<TRequest>(request);

        var failures = _validators
            .Select(v => v.Validate(context))
            .SelectMany(result => result.Errors)
            .Where(f => f != null)
            .ToList();

        if (failures.Any())
        {
            var error = new ValidationError(
                failures.Select(
                    f => new ValidationError.ValidationErrorItem(
                        f.PropertyName,
                        f.ErrorMessage)));

            if (typeof(TResponse) == typeof(Result))
            {
                return (TResponse)(ResultBase)Result.Fail(error);
            }

            var resultType = typeof(TResponse)
                .GetGenericArguments()
                .Single();

            var failMethod = typeof(Result).GetMethods()
                    .Where(x => x.Name == nameof(Result.Fail))
                    .Where(x => x.IsGenericMethod)
                    .Where(x => x.GetParameters().Length == 1)
                    .Where(x => x.GetParameters()[0].ParameterType == typeof(IError))
                    .Single()
                    .MakeGenericMethod(resultType);

            return (TResponse)(ResultBase)failMethod.Invoke(null, new[] { error })!;
        }

        return await next();
    }
}