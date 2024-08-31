using HR_Management.WebMvc.Models.LeaveAllocation;
using HR_Management.WebMvc.Services.Base;

namespace HR_Management.WebMvc.Cantracts
{
    public interface ILeaveAllocationService
    {
        Task<List<LeaveAllocationViewModel>> GetLeavaAllocationList();
        Task<LeaveAllocationViewModel> GetLeaveAllocationBy(int id);
        Task<Response<int>> CreateLeaveAllocation(CreateLeaveAllocationViewModel createLeaveAllocation);
        Task<UpdateLeaveAllocationViewModel> GetLeaveAllocationForUpdate(int id);
        Task<Response<int>> UpdateLeaveAllocation(UpdateLeaveAllocationViewModel updateLeaveAllocation);
        Task<Response<int>> DeleteLeaveAllocation(int id);
    }
}
