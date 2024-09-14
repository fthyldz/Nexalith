using Nexalith.Application.Cqrs.Request;

namespace Nexalith.Application.Cqrs.Behaviors;

public class ValidationBehavior<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : ICommand<TResponse> where TResponse : notnull
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        var context = new ValidationContext<TRequest>(request);

        var validationResult = await Task.WhenAll(validators.Select(v => v.ValidateAsync(context, cancellationToken)));

        var failures = validationResult.Where(r => r.Errors.Count != 0).SelectMany(r => r.Errors).ToList();

        if (failures.Count != 0)
            throw new ValidationException(failures);

        return await next();
    }
}