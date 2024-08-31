using AutoMapper;
using HR_Management.Application.Cantracts.Persistence;
using HR_Management.Application.DataTransferObject.LeaveType;
using HR_Management.Application.Features.LeaveType.Handlers.Commands;
using HR_Management.Application.Features.LeaveType.Requests.Commands;
using HR_Management.Application.Profiles;
using HR_Management.Application.Responses;
using HR_Management.UnitTets.Mocks;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Management.UnitTets.LeaveType.Commands
{
    public class CreateLeaveTypeCommandHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<ILeaveTypeRepository> _mockLeaveTypeRepository;
        private readonly CreateLeaveTypeDto _createLeaveTypeDto;
        public CreateLeaveTypeCommandHandlerTest()
        {
            _mockLeaveTypeRepository = MockLeaveTypeRepository.GetLeaveTypeRepository();
            var mapperConfig = new MapperConfiguration(m =>
            {
                m.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();

            _createLeaveTypeDto = new CreateLeaveTypeDto()
            {
                DefaultDay = 10,
                Name = "Test Add LeaveType"
            };
        }

        [Fact]
        public async Task CreateLeaveTypeTest()
        {
            var handler = new CreateLeaveTypeCommandHandler(_mockLeaveTypeRepository.Object, _mapper);
            var result = await handler.Handle(new CreateLeaveTypeCommand()
            {
                CreateLeaveTypeDto = _createLeaveTypeDto
            }, CancellationToken.None);

            result.ShouldBeOfType<BaseCommandResponse>();

            var leaveTypes = await _mockLeaveTypeRepository.Object.GetAll();

            leaveTypes.Count.ShouldBe(3);
        }
    }
}
