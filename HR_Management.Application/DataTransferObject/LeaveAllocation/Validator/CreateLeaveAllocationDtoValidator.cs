using FluentValidation;
using HR_Management.Application.Cantracts.Persistence;

namespace HR_Management.Application.DataTransferObject.LeaveAllocation.Validator
{
    public class CreateLeaveAllocationDtoValidator : AbstractValidator<CreateLeaveAllocationDto>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        public CreateLeaveAllocationDtoValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;

            Include(new LeaveAllocationDtoValidatorBase(_leaveTypeRepository));
        }
    }
}
