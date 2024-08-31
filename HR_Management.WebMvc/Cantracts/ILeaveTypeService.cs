using HR_Management.WebMvc.Models.LeaveType;
using HR_Management.WebMvc.Services.Base;

namespace HR_Management.WebMvc.Cantracts
{
    public interface ILeaveTypeService
    {
        Task<List<LeaveTypeViewModel>> GetLeaveTypesList();
        Task<LeaveTypeViewModel> GetLeaveTypesBy(int id);
        Task<Response<int>> CreateLeaveType(CreateLeaveTypeViewModel createLeaveTypeVm);
        Task<UpdateLeaveTypeViewModel> GetLeaveTypeForUpdate(int id);
        Task<Response<int>> UpdateLeaveType(UpdateLeaveTypeViewModel updateLeaveTypeVm);
        Task<Response<int>> DeleteLeaveType(int id);
    }
}
