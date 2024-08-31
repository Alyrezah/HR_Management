using AutoMapper;
using HR_Management.Application.DataTransferObject.LeaveAllocation.Validator;
using HR_Management.Application.Features.LeaveAllocation.Requests.Commands;
using HR_Management.Application.Cantracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HR_Management.Application.Features.LeaveAllocation.Handlers.Commands
{
    public class UpdateLeaveAllocationCommandHandler : IRequestHandler<UpdateLeaveAllocationCommand, Unit>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;
        public UpdateLeaveAllocationCommandHandler(ILeaveAllocationRepository leaveAllocationRepository,
            IMapper mapper,ILeaveTypeRepository leaveTypeRepository) 
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            #region Validation

            var validator = new UpdateLeaveAllocationDtoValidator(_leaveTypeRepository);
            var validatorResult = await validator.ValidateAsync(request.UpdateLeaveAllocationDto);

            if (validatorResult.IsValid == false)
            {
                throw new Exceptions.ValidationException(validatorResult);
            }

            #endregion

            var leaveAllocation = await _leaveAllocationRepository.Get(request.UpdateLeaveAllocationDto.Id);
            _mapper.Map(request.UpdateLeaveAllocationDto, leaveAllocation);
            await _leaveAllocationRepository.Update(leaveAllocation);

            return Unit.Value;
        }
    }
}
