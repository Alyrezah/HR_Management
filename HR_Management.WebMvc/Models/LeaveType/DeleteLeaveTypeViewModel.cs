using System.ComponentModel.DataAnnotations;

namespace HR_Management.WebMvc.Models.LeaveType
{
    public class DeleteLeaveTypeViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Default Day")]
        public int DefaultDay { get; set; }
    }
}
