using HR_Management.WebMvc.Models.LeaveType;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HR_Management.WebMvc.Models.LeaveRequest
{
    public class UpdateLeaveRequestViewModel
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int LeaveTypeId { get; set; }
        public string RequestComment { get; set; }
        public bool Cancelled { get; set; }

        public List<LeaveTypeViewModel> LeaveTypes { get; set; }
    }
}
