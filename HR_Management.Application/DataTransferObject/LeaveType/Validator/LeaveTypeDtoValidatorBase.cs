using FluentValidation;
using HR_Management.Application.DataTransferObject.LeaveType.Cantracts;

namespace HR_Management.Application.DataTransferObject.LeaveType.Validator
{
    public class LeaveTypeDtoValidatorBase : AbstractValidator<ILeaveTypeDto>
    {
        public LeaveTypeDtoValidatorBase()
        {
            RuleFor(lt=> lt.Name)
                .NotEmpty().WithMessage("فیلد {PropertyName} نباید خالی باشد")
                .NotNull().WithMessage("فیلد {PropertyName} نباید خالی باشد")
                .MaximumLength(100).WithMessage("فیلد {PropertyName} نباید بیشتر از 100 کاراکتر باشد");

            RuleFor(lt => lt.DefaultDay)
                .NotEmpty().WithMessage("فیلد {PropertyName} نباید خالی باشد")
                .NotNull().WithMessage("فیلد {PropertyName} نباید خالی باشد")
                .GreaterThan(0).WithMessage("فیلد {PropertyName} نباید کمتر از 0 باشد")
                .LessThan(100).WithMessage("فیلد {PropertyName} نباید بیشتر از 100 باشد");
        }
    }
}
