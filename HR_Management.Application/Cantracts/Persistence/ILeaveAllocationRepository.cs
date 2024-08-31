using HR_Management.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HR_Management.Application.Cantracts.Persistence
{
    public interface ILeaveAllocationRepository : IGenericRepository<LeaveAllocation>
    {
        Task<List<LeaveAllocation>> GetLeaveAllocationList();
        Task<LeaveAllocation> GetLeaveAllocatinDetails(int id);
    }
}
