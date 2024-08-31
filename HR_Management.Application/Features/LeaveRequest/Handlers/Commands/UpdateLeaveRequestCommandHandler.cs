using AutoMapper;
using HR_Management.Application.DataTransferObject.LeaveRequest.Validator;
using HR_Management.Application.Features.LeaveRequest.Requests.Commands;
using HR_Management.Application.Cantracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HR_Management.Application.Features.LeaveRequest.Handlers.Commands
{
    public class UpdateLeaveRequestCommandHandler : IRequestHandler<UpdateLeaveRequestCommand, Unit>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;
        public UpdateLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper,
            ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var leaveRequest = await _leaveRequestRepository.Get(request.Id);

            if (request.UpdateLeaveRequestDto != null)
            {
                #region Validation

                var validator = new UpdateLeaveRequestDtoValidator(_leaveTypeRepository);
                var validatorResult = await validator.ValidateAsync(request.UpdateLeaveRequestDto);

                if (validatorResult.IsValid == false)
                {
                    throw new Exceptions.ValidationException(validatorResult);
                }

                #endregion

                _mapper.Map(request.UpdateLeaveRequestDto, leaveRequest);
                if (request.UpdateLeaveRequestDto.Cancelled == true)
                {
                    leaveRequest.Approved = false;
                }
                else if (request.UpdateLeaveRequestDto.Cancelled == false)
                {
                    leaveRequest.Approved = null;
                }
                await _leaveRequestRepository.Update(leaveRequest);
            }
            else if (request.ChangeLeaveRequestApprovalDto != null)
            {
                await _leaveRequestRepository.ChangeApprovalStatus(leaveRequest, request.ChangeLeaveRequestApprovalDto.Approved);
            }
            return Unit.Value;
        }
    }
}
