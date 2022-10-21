using System.Text.RegularExpressions;
using Core.CQRS.Applications.Apply;
using Core.Validators;
using FluentValidation;

namespace Core.CQRS.Candidates.Create;

public class ApplyToRecruitmentValidator : AbstractValidator<ApplyToRecruitmentRequest>
{
    public ApplyToRecruitmentValidator()
    {
        RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage(Error.RequiredErrorMessage);
        RuleFor(x => x.Address).NotEmpty().NotNull().WithMessage(Error.RequiredErrorMessage);
        RuleFor(x => x.Email).NotEmpty().NotNull().WithMessage(Error.RequiredErrorMessage);
        RuleFor(x => x.Email).EmailAddress().WithMessage(Error.InvalidEmailErrorMessage);
        RuleFor(x => x.Qualification).NotEmpty().NotNull().WithMessage(Error.RequiredErrorMessage);
        RuleFor(x => x.Phone).NotEmpty().NotNull().WithMessage(Error.RequiredErrorMessage);
        RuleFor(x => x.Phone).Must(e => Regex.IsMatch(e, @"^[\+]?[(]?[0-9]{3}[)]?[-\s\.]?[0-9]{3}[-\s\.]?[0-9]{4,6}$"))
          .WithMessage(Error.InvalidPhoneErrorMessage);
    }
}