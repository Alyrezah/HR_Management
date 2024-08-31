using FluentValidation;
using HR_Management.Application.Cantracts.Persistence;

namespace HR_Management.Application.DataTransferObject.LeaveRequest.Validator
{
    public class CreateLeaveRequestDtoValidator : AbstractValidator<CreateLeaveRequestDto>
    {

        private readonly ILeaveTypeRepository _leaveTypeRepository;
        public CreateLeaveRequestDtoValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;

            Include(new LeaveRequestDtoValidatorBase(_leaveTypeRepository));
        }
    }
}
