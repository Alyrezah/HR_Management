using HR_Management.Application.Cantracts.Persistence;
using HR_Management.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR_Management.Persistence.Repositories
{
    public class LeaveTypeRepository: GenericRepository<LeaveType>, ILeaveTypeRepository
    {
        private readonly HRManagementDbContext _context;
        public LeaveTypeRepository(HRManagementDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
