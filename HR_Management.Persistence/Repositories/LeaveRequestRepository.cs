using HR_Management.Application.Cantracts.Persistence;
using HR_Management.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Management.Persistence.Repositories
{
    public class LeaveRequestRepository : GenericRepository<LeaveRequest> , ILeaveRequestRepository
    {
        private readonly HRManagementDbContext _context;
        public LeaveRequestRepository(HRManagementDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task ChangeApprovalStatus(LeaveRequest leaveRequest, bool? approvalSatus)
        {
            leaveRequest.Approved = approvalSatus;
            _context.Entry(leaveRequest).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<LeaveRequest> GetLeaveRequestDetails(int id)
        {
            var leaveRequest = await _context.LeaveRequests
                .Include(x=>x.LeaveType)
                .FirstOrDefaultAsync(x=>x.Id == id);

            return leaveRequest;
        }

        public async Task<List<LeaveRequest>> GetLeaveRequestList()
        {
            var list = await _context.LeaveRequests.Include(x => x.LeaveType).ToListAsync();

            return list;
        }
    }
}
