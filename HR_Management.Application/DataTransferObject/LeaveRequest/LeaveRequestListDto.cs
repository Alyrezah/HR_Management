using System;
using HR_Management.Application.DataTransferObject.Common;
using HR_Management.Application.DataTransferObject.LeaveType;

namespace HR_Management.Application.DataTransferObject.LeaveRequest
{
    public class LeaveRequestListDto : BaseDto
    {
        public LeaveTypeDto LeaveType { get; set; }
        public DateTime RequestDate { get; set; }
        public bool? Approved { get; set; }
    }
}
