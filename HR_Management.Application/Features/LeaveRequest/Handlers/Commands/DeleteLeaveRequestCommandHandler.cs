using AutoMapper;
using HR_Management.Application.Exceptions;
using HR_Management.Application.Features.LeaveRequest.Requests.Commands;
using HR_Management.Application.Cantracts.Persistence;
using HR_Management.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HR_Management.Application.Features.LeaveRequest.Handlers.Commands
{
    public class DeleteLeaveRequestCommandHandler : IRequestHandler<DeleteLeaveRequestCommand>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;
        public DeleteLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository,IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
        }

        public async Task Handle(DeleteLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var leaveRequest = await _leaveRequestRepository.Get(request.Id);

            if (leaveRequest == null)
            {
                throw new NotFoundException(nameof(Domain.LeaveRequest), request.Id);
            }

            await _leaveRequestRepository.Delete(leaveRequest);
        }
    }
}
