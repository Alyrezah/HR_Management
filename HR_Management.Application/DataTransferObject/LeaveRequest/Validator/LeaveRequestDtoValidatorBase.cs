using FluentValidation;
using HR_Management.Application.DataTransferObject.LeaveRequest.Cantracts;
using HR_Management.Application.Cantracts.Persistence;

namespace HR_Management.Application.DataTransferObject.LeaveRequest.Validator
{
    public class LeaveRequestDtoValidatorBase : AbstractValidator<ILeaveRequestDto>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        public LeaveRequestDtoValidatorBase(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;

            RuleFor(lr => lr.StartDate)
                .NotNull().WithMessage("فیلد {PropertyName} نباید خالی باشد")
                .NotEmpty().WithMessage("فیلد {PropertyName} نباید خالی باشد")
                .LessThan(lr => lr.EndDate).WithMessage("تاریخ شروع نباید بزرگتر از تاریخ پایان باشد");

            RuleFor(lr => lr.EndDate)
                 .NotNull().WithMessage("فیلد {PropertyName} نباید خالی باشد")
                 .NotEmpty().WithMessage("فیلد {PropertyName} نباید خالی باشد")
                 .GreaterThan(lr => lr.StartDate).WithMessage("تاریخ پایان نباید کوچکتر از تاریخ شروع باشد");

            RuleFor(lr => lr.LeaveTypeId)
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
