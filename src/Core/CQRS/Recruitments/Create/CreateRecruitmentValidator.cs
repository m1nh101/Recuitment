using Core.Validators;
using FluentValidation;

namespace Core.CQRS.Recruitments.Create;

public class CreateRecruitmentValidator : AbstractValidator<CreateRecruitmentRequest>
{
	public CreateRecruitmentValidator()
	{
		RuleFor(e => e.Benifit).NotEmpty().NotNull().WithMessage(Error.RequiredErrorMessage);
		RuleFor(e => e.Name).NotEmpty().NotNull().WithMessage(Error.RequiredErrorMessage);
		RuleFor(e => e.Content).NotEmpty().NotNull().WithMessage(Error.RequiredErrorMessage);
		RuleFor(e => e.SalaryMax).GreaterThan(0).WithMessage(Error.NegativeValueErrorMessage);
		RuleFor(e => e.SalaryMin).GreaterThanOrEqualTo(0).WithMessage(Error.NegativeValueErrorMessage);
		RuleFor(e => e.SalaryMin).LessThan(e => e.SalaryMax).WithMessage("Lương tối thiểu không thể lớn hơn lương tối đa");
		RuleFor(e => e.ExperienceFrom).GreaterThanOrEqualTo(0).WithMessage(Error.NegativeValueErrorMessage);
    RuleFor(e => e.ExperienceTo).GreaterThanOrEqualTo(0).WithMessage(Error.NegativeValueErrorMessage);
    RuleFor(e => e.EndDate).GreaterThan(DateTime.Now).WithMessage(Error.InvalidDateErrorMessage);
		RuleFor(e => e.StartDate).LessThan(e => e.EndDate).WithMessage("Ngày bắt đầu không thể lơn hơn ngày kết thúc");
		RuleFor(e => e.Number).GreaterThanOrEqualTo(0).WithMessage(Error.NegativeValueErrorMessage);
  }
}