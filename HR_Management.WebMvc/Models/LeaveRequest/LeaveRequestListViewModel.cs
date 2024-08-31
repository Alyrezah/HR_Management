using HR_Management.WebMvc.Models.LeaveType;

namespace HR_Management.WebMvc.Models.LeaveRequest
{
    public class LeaveRequestListViewModel
    {
        public int Id { get; set; }
        public LeaveTypeViewModel LeaveType { get; set; }
        public DateTime RequestDate { get; set; }
        public bool? Approved { get; set; }
    }
}
