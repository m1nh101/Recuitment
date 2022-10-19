using Core.CQRS.Recruitments.Requests;
using FluentValidation;

namespace Core.Validators;

public class UpdateRecruitmentValidator : AbstractValidator<UpdateRecruitmentRequest>
{
  public UpdateRecruitmentValidator()
	{
		RuleFor(e => e.Id).Must(e => e >= 0).WithMessage("Id không hợp lệ");
		RuleFor(e => e.Payload).NotNull().WithMessage("Không hợp lệ");
    RuleFor(e => e.Payload.Benifit).NotEmpty().NotNull().WithMessage(Error.RequiredErrorMessage);
    RuleFor(e => e.Payload.Name).NotEmpty().NotNull().WithMessage(Error.RequiredErrorMessage);
    RuleFor(e => e.Payload.Content).NotEmpty().NotNull().WithMessage(Error.RequiredErrorMessage);
    RuleFor(e => e.Payload.SalaryMax).GreaterThan(0).WithMessage(Error.NegativeValueErrorMessage);
    RuleFor(e => e.Payload.SalaryMin).GreaterThan(0).WithMessage(Error.NegativeValueErrorMessage);
    RuleFor(e => e.Payload.SalaryMin).LessThan(e => e.Payload.SalaryMax).WithMessage("Lương tối thiểu không thể lớn hơn lương tối đa");
    RuleFor(e => e.Payload.ExperienceFrom).GreaterThan(0).WithMessage(Error.NegativeValueErrorMessage);
    RuleFor(e => e.Payload.ExperienceTo).GreaterThan(0).WithMessage(Error.NegativeValueErrorMessage);
    RuleFor(e => e.Payload.ExperienceFrom).LessThan(e => e.Payload.ExperienceTo).WithMessage("Kinh nghiệm tối thiểu không thể lơn hơn kinh nghiệm tối đa");
    RuleFor(e => e.Payload.StartDate).GreaterThan(DateTime.Now).WithMessage(Error.InvalidDateErrorMessage);
    RuleFor(e => e.Payload.EndDate).GreaterThan(DateTime.Now).WithMessage(Error.InvalidDateErrorMessage);
    RuleFor(e => e.Payload.StartDate).LessThan(e => e.Payload.EndDate).WithMessage("Ngày bắt đầu không thể lơn hơn ngày kết thúc");
    RuleFor(e => e.Payload.Number).GreaterThanOrEqualTo(0).WithMessage(Error.NegativeValueErrorMessage);
  }
}