using HR_Management.WebMvc.Models.LeaveType;

namespace HR_Management.WebMvc.Models.LeaveAllocation
{
    public class LeaveAllocationViewModel
    {
        public int Id { get; set; }
        public int NumberOfDays { get; set; }
        public int LeaveTypeId { get; set; }
        public int Period { get; set; }
        public LeaveTypeViewModel LeaveType { get; set; }
    }
}
