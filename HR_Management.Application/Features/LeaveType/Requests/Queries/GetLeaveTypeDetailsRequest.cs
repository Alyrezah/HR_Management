using HR_Management.Application.DataTransferObject.LeaveType;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR_Management.Application.Features.LeaveType.Requests.Queries
{
    public class GetLeaveTypeDetailsRequest : IRequest<LeaveTypeDto>
    {
        public int Id { get; set; }
    }
}
