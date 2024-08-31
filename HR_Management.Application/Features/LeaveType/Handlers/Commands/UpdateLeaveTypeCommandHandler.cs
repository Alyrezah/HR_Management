using AutoMapper;
using HR_Management.Application.DataTransferObject.LeaveType;
using HR_Management.Application.DataTransferObject.LeaveType.Validator;
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
using System.Linq;

namespace HR_Management.Application.Features.LeaveType.Handlers.Commands
{
    public class UpdateLeaveTypeCommandHandler : IRequestHandler<UpdateLeaveTypeCommand>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;
        public UpdateLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        public async Task Handle(UpdateLeaveTypeCommand request, CancellationToken cancellationToken)
        {

            #region Validation

            var validator = new UpdateLeaveTypeDtoValidator();
            var validatorResult = await validator.ValidateAsync(request.UpdateLeaveTypeDto);

            if (validatorResult.IsValid == false)
            {
                throw new Exceptions.ValidationException(validatorResult);
            }

            #endregion

            var leaveType = await _leaveTypeRepository.Get(request.UpdateLeaveTypeDto.Id);
            _mapper.Map(request.UpdateLeaveTypeDto, leaveType);
            await _leaveTypeRepository.Update(leaveType);
        }
    }
}
