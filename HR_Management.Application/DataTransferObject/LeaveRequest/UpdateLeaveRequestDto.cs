using HR_Management.Application.DataTransferObject.Common;
using HR_Management.Application.DataTransferObject.LeaveRequest.Cantracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR_Management.Application.DataTransferObject.LeaveRequest
{
    public class UpdateLeaveRequestDto : BaseDto, ILeaveRequestDto
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int LeaveTypeId { get; set; }
        public string RequestComment { get; set; }
        public bool Cancelled { get; set; }
    }
}
