using HR_Management.Application.DataTransferObject.LeaveType;
using HR_Management.Application.Responses;
using MediatR;

namespace HR_Management.Application.Features.LeaveType.Requests.Commands
{
    public class CreateLeaveTypeCommand : IRequest<BaseCommandResponse>
    {
        public CreateLeaveTypeDto CreateLeaveTypeDto { get; set; }
    }
}
