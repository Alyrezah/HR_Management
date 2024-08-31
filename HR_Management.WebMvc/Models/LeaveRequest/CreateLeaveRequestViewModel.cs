using HR_Management.WebMvc.Models.LeaveType;

namespace HR_Management.WebMvc.Models.LeaveRequest
{
    public class CreateLeaveRequestViewModel
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int LeaveTypeId { get; set; }
        public DateTime RequestDate { get; set; }
        public string RequestComment { get; set; }

        public List<LeaveTypeViewModel> LeaveTypes { get; set; }
    }
}
