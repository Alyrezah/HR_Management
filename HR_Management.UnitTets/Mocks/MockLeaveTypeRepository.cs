using HR_Management.Application.Cantracts.Persistence;
using HR_Management.Domain;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Management.UnitTets.Mocks
{
    public static class MockLeaveTypeRepository
    {
        public static Mock<ILeaveTypeRepository> GetLeaveTypeRepository()
        {
            var leaveTypes = new List<Domain.LeaveType>()
            {
                new Domain.LeaveType()
                {
                    Id = 1,
                    DefaultDay = 10,
                    Name = "Jaunt Test",
                },
                new Domain.LeaveType()
                {
                    Id = 2,
                    DefaultDay = 3,
                    Name = "Disease Test",
                },
            };

            var mockRepository = new Mock<ILeaveTypeRepository>();

            mockRepository.Setup(x => x.GetAll()).ReturnsAsync(leaveTypes);
            mockRepository.Setup(x => x.Add(It.IsAny<Domain.LeaveType>()))
                .ReturnsAsync((Domain.LeaveType leaveType) =>
                {
                    leaveTypes.Add(leaveType);
                    return leaveType;
                });

            return mockRepository;
        }
    }
}
