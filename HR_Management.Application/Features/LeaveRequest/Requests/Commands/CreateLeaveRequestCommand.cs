using HR_Management.Application.DataTransferObject.LeaveRequest;
using HR_Management.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR_Management.Application.Features.LeaveRequest.Requests.Commands
{
    public class CreateLeaveRequestCommand : IRequest<BaseCommandResponse>
    {
        public CreateLeaveRequestDto CreateLeaveRequestDto { get; set; }
    }
}
