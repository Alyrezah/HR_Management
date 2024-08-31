using HR_Management.Application.DataTransferObject.LeaveType;
using HR_Management.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR_Management.Application.Features.LeaveType.Requests.Commands
{
    public class UpdateLeaveTypeCommand : IRequest
    {
        public UpdateLeaveTypeDto UpdateLeaveTypeDto { get; set; }
    }
}
