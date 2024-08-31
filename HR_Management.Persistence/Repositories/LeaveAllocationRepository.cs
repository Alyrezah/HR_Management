using HR_Management.Application.Cantracts.Persistence;
using HR_Management.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HR_Management.Persistence.Repositories
{
    public class LeaveAllocationRepository : GenericRepository<LeaveAllocation> , ILeaveAllocationRepository
    {
        private readonly HRManagementDbContext _context;
        public LeaveAllocationRepository(HRManagementDbContext context): base(context)
        {
            _context = context;
        }

        public async Task<LeaveAllocation> GetLeaveAllocatinDetails(int id)
        {
            var leaveAllocation = await _context.LeaveAllocations
                .Include(x => x.LeaveType)
                .FirstOrDefaultAsync(x=>x.Id == id);

            return leaveAllocation;
        }

        public async Task<List<LeaveAllocation>> GetLeaveAllocationList()
        {
            var list = await _context.LeaveAllocations
                .Include(x=>x.LeaveType)
                .ToListAsync();

            return list;
        }
    }
}
