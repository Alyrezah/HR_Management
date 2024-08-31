using HR_Management.Application.DataTransferObject.LeaveAllocation;
using HR_Management.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR_Management.Application.Features.LeaveAllocation.Requests.Commands
{
    public class CreateLeaveAllocationCommand : IRequest<BaseCommandResponse>
    {
        public CreateLeaveAllocationDto CreateLeaveAllocationDto { get; set; }
    }
}
