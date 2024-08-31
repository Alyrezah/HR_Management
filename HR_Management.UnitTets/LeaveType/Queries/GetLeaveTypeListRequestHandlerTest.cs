using AutoMapper;
using HR_Management.Application.Cantracts.Persistence;
using HR_Management.Application.Features.LeaveType.Handlers.Queries;
using HR_Management.Application.Profiles;
using HR_Management.UnitTets.Mocks;
using Moq;
using HR_Management.Application.Features.LeaveType.Requests.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shouldly;
using HR_Management.Application.DataTransferObject.LeaveType;

namespace HR_Management.UnitTets.LeaveType.Queries
{
    public class GetLeaveTypeListRequestHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<ILeaveTypeRepository> _mockLeaveTypeRepository;
        public GetLeaveTypeListRequestHandlerTest()
        {
            _mockLeaveTypeRepository = MockLeaveTypeRepository.GetLeaveTypeRepository();
            var mapperConfig = new MapperConfiguration(m =>
            {
                m.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task GetLeaveTypeListTest()
        {
            var handler = new GetLeaveTypeListRequestHandler(_mockLeaveTypeRepository.Object, _mapper);
            var result = await handler.Handle(new GetLeaveTypeListRequest(), CancellationToken.None);

            result.ShouldBeOfType<List<LeaveTypeDto>>();
        }
    }
}
