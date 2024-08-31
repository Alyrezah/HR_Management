using HR_Management.Application.DataTransferObject.Common;
using HR_Management.Application.DataTransferObject.LeaveRequest.Cantracts;
using HR_Management.Application.DataTransferObject.LeaveType;
using System;

namespace HR_Management.Application.DataTransferObject.LeaveRequest
{
    public class LeaveRequestDto : BaseDto, ILeaveRequestDto
    {
        public LeaveTypeDto LeaveType { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime? DateActioned { get; set; }
        public bool? Approved { get; set; }
        public bool Cancelled { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int LeaveTypeId { get; set; }
        public string RequestComment { get; set; }
    }
}
