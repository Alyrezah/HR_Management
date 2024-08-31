using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR_Management.Application.DataTransferObject.LeaveType.Validator
{
    public class UpdateLeaveTypeDtoValidator : AbstractValidator<UpdateLeaveTypeDto>
    {
        public UpdateLeaveTypeDtoValidator()
        {
            Include(new LeaveTypeDtoValidatorBase());

            RuleFor(x => x.Id)
                .NotNull().WithMessage("فیلد {PropertyName} نباید خالی باشد")
                .NotEmpty().WithMessage("فیلد {PropertyName} نباید خالی باشد")
                .GreaterThan(0).WithMessage("فیلد {PropertyName} باید بزرگتر از 0 باشد");
        }
    }
}
