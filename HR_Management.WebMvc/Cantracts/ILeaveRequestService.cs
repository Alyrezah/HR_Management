using HR_Management.WebMvc.Models.LeaveRequest;
using HR_Management.WebMvc.Services.Base;

namespace HR_Management.WebMvc.Cantracts
{
    public interface ILeaveRequestService
    {
        Task<List<LeaveRequestListViewModel>> GetLeaveRequestList();
        Task<LeaveRequestViewModel> GetLeaveRequestBy(int id);
        Task<Response<int>> CreateLeaveRequest(CreateLeaveRequestViewModel createLeaveRequestVm);
        Task<UpdateLeaveRequestViewModel> GetLeaveRequestForUpdate(int id);
        Task<Response<int>> UpdateLeaveRequest(UpdateLeaveRequestViewModel updateLeaveRequestVm);
        Task<Response<int>> DeleteLeaveRequest(int id);
    }
}
