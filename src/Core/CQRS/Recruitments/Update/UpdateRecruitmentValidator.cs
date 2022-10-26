using Core.Validators;
using FluentValidation;

namespace Core.CQRS.Recruitments.Update;

public class UpdateRecruitmentValidator : AbstractValidator<UpdateRecruitmentRequest>
{
  public UpdateRecruitmentValidator()
  {
    RuleFor(e => e.Id).GreaterThan(0).WithMessage("Id is not valid");
    RuleFor(e => e.Benifit).NotEmpty().NotNull().WithMessage(Error.RequiredErrorMessage);
		RuleFor(e => e.Name).NotEmpty().NotNull().WithMessage(Error.RequiredErrorMessage);
		RuleFor(e => e.Content).NotEmpty().NotNull().WithMessage(Error.RequiredErrorMessage);
		RuleFor(e => e.SalaryMax).GreaterThan(0).WithMessage(Error.NegativeValueErrorMessage);
		RuleFor(e => e.SalaryMin).GreaterThanOrEqualTo(0).WithMessage(Error.NegativeValueErrorMessage);
		RuleFor(e => e.SalaryMin).LessThan(e => e.SalaryMax).WithMessage("Lương tối thiểu không thể lớn hơn lương tối đa");
		RuleFor(e => e.ExperienceFrom).GreaterThanOrEqualTo(0).WithMessage(Error.NegativeValueErrorMessage);
    RuleFor(e => e.ExperienceTo).GreaterThanOrEqualTo(0).WithMessage(Error.NegativeValueErrorMessage);
		RuleFor(e => e.StartDate).LessThan(e => e.EndDate).WithMessage("Ngày bắt đầu không thể lơn hơn ngày kết thúc");
		RuleFor(e => e.Number).GreaterThanOrEqualTo(0).WithMessage(Error.NegativeValueErrorMessage);
  }
}