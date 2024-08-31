using FluentValidation;

namespace HR_Management.Application.DataTransferObject.LeaveType.Validator
{
    public class CreateLeaveTypeDtoValidator : AbstractValidator<CreateLeaveTypeDto>
    {
        public CreateLeaveTypeDtoValidator()
        {
            Include(new LeaveTypeDtoValidatorBase());
        }
    }
}
