using HR_Management.Application.DataTransferObject.LeaveAllocation.Cantracts;

namespace HR_Management.Application.DataTransferObject.LeaveAllocation
{
    public class CreateLeaveAllocationDto : ILeaveAllocationDto
    {
        public int NumberOfDays { get; set; }
        public int LeaveTypeId { get; set; }
        public int Period { get; set; }
    }
}
