using System.ComponentModel.DataAnnotations;

namespace HR_Management.WebMvc.Models.LeaveType
{
    public class CreateLeaveTypeViewModel
    {
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Default Day")]
        public int DefaultDay { get; set; }
    }
}
