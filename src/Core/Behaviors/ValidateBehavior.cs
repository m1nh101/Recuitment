using Core.CQRS.Responses;
using FluentValidation;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Core.Behaviors;

public class ValidateBehavior<TRequest, TReponse>
  : IPipelineBehavior<TRequest, TReponse>
  where TRequest : IRequest<TReponse>
  where TReponse : ActionResponse
{
  private readonly IEnumerable<IValidator<TRequest>> _validators;

  public ValidateBehavior(IEnumerable<IValidator<TRequest>> validators)
  {
    _validators = validators;
  }

  public async Task<TReponse> Handle(TRequest request,
    CancellationToken cancellationToken,
    RequestHandlerDelegate<TReponse> next)
  {
    if (!_validators.Any())
      return await next();

    List<object> errors = new();

    foreach(var validator in _validators)
    {
      var validateResult = await validator.ValidateAsync(request);

      if (validateResult.IsValid)
        continue;

      var error = validateResult.Errors
     .Select(e => new { Field = e.PropertyName, Message = e.ErrorMessage });

      errors.AddRange(error);
    }

    var response = new FailedValidationResponse(errors);

    return (dynamic) response;
  }
}