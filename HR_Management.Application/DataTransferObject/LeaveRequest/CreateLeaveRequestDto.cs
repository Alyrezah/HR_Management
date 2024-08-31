using HR_Management.Application.DataTransferObject.Common;
using HR_Management.Application.DataTransferObject.LeaveRequest.Cantracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR_Management.Application.DataTransferObject.LeaveRequest
{
    public class CreateLeaveRequestDto : ILeaveRequestDto
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int LeaveTypeId { get; set; }
        public DateTime RequestDate { get; set; }
        public string RequestComment { get; set; }
    }
}
