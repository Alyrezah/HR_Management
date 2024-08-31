using HR_Management.Application.DataTransferObject.Common;
using HR_Management.Application.DataTransferObject.LeaveType.Cantracts;

namespace HR_Management.Application.DataTransferObject.LeaveType
{
    public class LeaveTypeDto : BaseDto , ILeaveTypeDto
    {
        public string Name { get; set; }
        public int DefaultDay { get; set; }
    }
}
