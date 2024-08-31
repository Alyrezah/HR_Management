using HR_Management.Application.Cantracts.Persistence;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Management.UnitTets.Mocks
{
    public static class MockLeaveAllocationRepository
    {
        public static Mock<ILeaveAllocationRepository> GetLeaveAllocationRepository()
        {
            var mockRepository = new Mock<ILeaveAllocationRepository>();

            return mockRepository;
        }
    }
}
