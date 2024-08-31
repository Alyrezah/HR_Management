using FluentValidation;
using HR_Management.Application.Cantracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR_Management.Application.DataTransferObject.LeaveAllocation.Validator
{
    public class UpdateLeaveAllocationDtoValidator : AbstractValidator<UpdateLeaveAllocationDto>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        public UpdateLeaveAllocationDtoValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;

            Include(new LeaveAllocationDtoValidatorBase(_leaveTypeRepository));

            RuleFor(x => x.Id)
                .NotNull().WithMessage("فیلد {PropertyName} نباید خالی باشد")
                .NotEmpty().WithMessage("فیلد {PropertyName} نباید خالی باشد")
                .GreaterThan(0).WithMessage("فیلد {PropertyName} باید بزرگتر از 0 باشد");
        }
    }
}
