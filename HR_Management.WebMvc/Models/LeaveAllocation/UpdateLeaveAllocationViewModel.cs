using HR_Management.WebMvc.Models.LeaveType;
using System.ComponentModel.DataAnnotations;

namespace HR_Management.WebMvc.Models.LeaveAllocation
{
    public class UpdateLeaveAllocationViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Number Of Days")]
        public int NumberOfDays { get; set; }

        [Required]
        [Display(Name = "Leave Type")]
        public int LeaveTypeId { get; set; }

        [Required]
        [Display(Name = "Period")]
        public int Period { get; set; }

        public List<LeaveTypeViewModel> LeaveTypes { get; set; }
    }
}
