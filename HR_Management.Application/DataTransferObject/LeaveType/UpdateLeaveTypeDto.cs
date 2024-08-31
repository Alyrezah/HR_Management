using HR_Management.Application.DataTransferObject.Common;
using HR_Management.Application.DataTransferObject.LeaveType.Cantracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR_Management.Application.DataTransferObject.LeaveType
{
    public class UpdateLeaveTypeDto : BaseDto, ILeaveTypeDto
    {
        public string Name { get; set; }
        public int DefaultDay { get; set; }
    }
}
