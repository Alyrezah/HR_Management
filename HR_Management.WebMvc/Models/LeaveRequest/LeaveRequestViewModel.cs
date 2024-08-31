using HR_Management.WebMvc.Models.LeaveType;

namespace HR_Management.WebMvc.Models.LeaveRequest
{
    public class LeaveRequestViewModel
    {
        public int Id { get; set; }
        public LeaveTypeViewModel LeaveType { get; set; }
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
