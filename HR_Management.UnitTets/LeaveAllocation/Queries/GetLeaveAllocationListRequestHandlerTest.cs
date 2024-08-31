using AutoMapper;
using HR_Management.Application.Cantracts.Persistence;
using HR_Management.Application.Features.LeaveAllocation.Handlers.Queries;
using HR_Management.Application.Profiles;
using HR_Management.UnitTets.Mocks;
using Moq;
using HR_Management.Application.Features.LeaveAllocation.Requests.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shouldly;
using HR_Management.Application.DataTransferObject.LeaveAllocation;

namespace HR_Management.UnitTets.LeaveAllocation.Queries
{
    public class GetLeaveAllocationListRequestHandlerTest
    {
        IMapper _mapper;
        Mock<ILeaveAllocationRepository> _mockLeaveAllocationRepository;
        public GetLeaveAllocationListRequestHandlerTest()
        {
            _mockLeaveAllocationRepository = MockLeaveAllocationRepository.GetLeaveAllocationRepository();
            var mapperConfig = new MapperConfiguration(m =>
            {
                m.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task GetLeaveAllocationList()
        {
            var handler = new GetLeaveAllocationListRequestHandler(_mockLeaveAllocationRepository.Object,
                _mapper);

            var result = await handler.Handle(new GetLeaveAllocationListRequest(), CancellationToken.None);

            result.ShouldBeOfType<List<LeaveAllocationDto>>();
        }
    }
}
