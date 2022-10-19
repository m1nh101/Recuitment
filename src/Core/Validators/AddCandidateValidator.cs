using Core.CQRS.Candidates.Requests;
using FluentValidation;
using System.Text.RegularExpressions;

namespace Core.Validators;

public class AddCandidateValidator : AbstractValidator<AddCandidateToRecruitmentRequest>
{
	public AddCandidateValidator()
	{
		RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage(Error.RequiredErrorMessage);
		RuleFor(x => x.Address).NotEmpty().NotNull().WithMessage(Error.RequiredErrorMessage);
		RuleFor(x => x.Email).NotEmpty().NotNull().WithMessage(Error.RequiredErrorMessage);
		RuleFor(x => x.Email).EmailAddress().WithMessage(Error.InvalidEmailErrorMessage);
    RuleFor(x => x.Attachment).NotEmpty().NotNull().WithMessage(Error.RequiredErrorMessage);
		RuleFor(x => x.Qualification).NotEmpty().NotNull().WithMessage(Error.RequiredErrorMessage);
		RuleFor(x => x.Phone).NotEmpty().NotNull().WithMessage(Error.RequiredErrorMessage);
		RuleFor(x => x.Phone).Must(e => Regex.IsMatch(e, @"^[\+]?[(]?[0-9]{3}[)]?[-\s\.]?[0-9]{3}[-\s\.]?[0-9]{4,6}$"))
			.WithMessage(Error.InvalidPhoneErrorMessage);
  }
}