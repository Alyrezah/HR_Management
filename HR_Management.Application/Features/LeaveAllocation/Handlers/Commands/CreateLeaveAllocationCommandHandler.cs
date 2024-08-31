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
using HR_Management.Application.Responses;
using System.Linq;
using HR_Management.Domain;

namespace HR_Management.Application.Features.LeaveAllocation.Handlers.Commands
{
    public class CreateLeaveAllocationCommandHandler : IRequestHandler<CreateLeaveAllocationCommand, BaseCommandResponse>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;
        public CreateLeaveAllocationCommandHandler(ILeaveAllocationRepository leaveAllocationRepository, 
            IMapper mapper,ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
        }

        public async Task<BaseCommandResponse> Handle(CreateLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            #region Validation

            var validator = new CreateLeaveAllocationDtoValidator(_leaveTypeRepository);
            var validatorResult = await validator.ValidateAsync(request.CreateLeaveAllocationDto);

            if (validatorResult.IsValid == false)
            {
                response.IsSuccess = false;
                response.Message = "عملیات افزودن با خطا مواجه شد";
                response.ErrorMessages = validatorResult.Errors.Select(e => e.ErrorMessage).ToList();
                return response;
            }

            #endregion

            var leaveAllocation = _mapper.Map<Domain.LeaveAllocation>(request.CreateLeaveAllocationDto);
            leaveAllocation = await _leaveAllocationRepository.Add(leaveAllocation);
            response.IsSuccess = true;
            response.Message = "عملیات افزودن با موفقیت انجام شد";
            response.Id = leaveAllocation.Id;

            return response;
        }
    }
}
