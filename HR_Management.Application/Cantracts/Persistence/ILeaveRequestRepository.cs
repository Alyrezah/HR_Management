using HR_Management.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HR_Management.Application.Cantracts.Persistence
{
    public interface ILeaveRequestRepository : IGenericRepository<LeaveRequest>
    {
        Task<List<LeaveRequest>> GetLeaveRequestList();
        Task<LeaveRequest> GetLeaveRequestDetails(int id);
        Task ChangeApprovalStatus(LeaveRequest leaveRequest, bool? approvalSatus);
    }
}
