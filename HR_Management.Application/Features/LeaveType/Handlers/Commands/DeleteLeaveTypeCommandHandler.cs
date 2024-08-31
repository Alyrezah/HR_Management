using AutoMapper;
using HR_Management.Application.Exceptions;
using HR_Management.Application.Features.LeaveType.Requests.Commands;
using HR_Management.Application.Cantracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HR_Management.Application.Responses;

namespace HR_Management.Application.Features.LeaveType.Handlers.Commands
{
    public class DeleteLeaveTypeCommandHandler : IRequestHandler<DeleteLeaveTypeCommand>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;
        public DeleteLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        public async Task Handle(DeleteLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var leaveType = await _leaveTypeRepository.Get(request.Id);

            if (leaveType == null)
            {
                throw new NotFoundException(nameof(Domain.LeaveType), request.Id);
            }

            await _leaveTypeRepository.Delete(leaveType);
        }
    }
}
