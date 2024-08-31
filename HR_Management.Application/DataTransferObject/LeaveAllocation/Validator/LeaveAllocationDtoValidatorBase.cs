using FluentValidation;
using HR_Management.Application.DataTransferObject.LeaveAllocation.Cantracts;
using HR_Management.Application.Cantracts.Persistence;
using System;

namespace HR_Management.Application.DataTransferObject.LeaveAllocation.Validator
{
    public class LeaveAllocationDtoValidatorBase : AbstractValidator<ILeaveAllocationDto>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        public LeaveAllocationDtoValidatorBase(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;

            RuleFor(la=> la.NumberOfDays)
                .NotNull().WithMessage("فیلد {PropertyName} نباید خالی باشد")
                .NotEmpty().WithMessage("فیلد {PropertyName} نباید خالی باشد")
                .GreaterThan(0).WithMessage("فیلد {PropertyName} باید بزرگتر از 0 باشد");

            RuleFor(la => la.Period)
                .NotNull().WithMessage("فیلد {PropertyName} نباید خالی باشد")
                .NotEmpty().WithMessage("فیلد {PropertyName} نباید خالی باشد")
                .GreaterThanOrEqualTo(DateTime.Now.Year).WithMessage($"دوره نباید کمتر از سال جاری({DateTime.Now.Year})باشد");

            RuleFor(la => la.LeaveTypeId)
                 .NotNull().WithMessage("فیلد {PropertyName} نباید خالی باشد")
                 .NotEmpty().WithMessage("فیلد {PropertyName} نباید خالی باشد")
                 .GreaterThan(0).WithMessage("فیلد {PropertyName} باید بزرگتر از 0 باشد")
                 .MustAsync(async (id, token) =>
                 {
                     var leaveTypeIdExist = await _leaveTypeRepository.IsExist(id);
                     return leaveTypeIdExist;
                 }).WithMessage("فیلد {PropertyName} وجود ندارد");
        }
    }
}
