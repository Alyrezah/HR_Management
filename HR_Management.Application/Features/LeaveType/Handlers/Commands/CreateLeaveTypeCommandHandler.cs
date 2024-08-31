using AutoMapper;
using HR_Management.Application.DataTransferObject.LeaveType.Validator;
using HR_Management.Application.Exceptions;
using HR_Management.Application.Features.LeaveType.Requests.Commands;
using HR_Management.Application.Cantracts.Persistence;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using HR_Management.Application.Responses;
using System.Linq;

namespace HR_Management.Application.Features.LeaveType.Handlers.Commands
{
    public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, BaseCommandResponse>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;
        public CreateLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository,IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            #region Validation

            var validator = new CreateLeaveTypeDtoValidator();
            var validatorResult = await validator.ValidateAsync(request.CreateLeaveTypeDto);

            if (validatorResult.IsValid == false)
            {
                response.IsSuccess = false;
                response.Message = "عملیات افزودن با خطا مواجه شد";
                response.ErrorMessages = validatorResult.Errors.Select(x=>x.ErrorMessage).ToList();
                return response;
            }

            #endregion

            var leaveType = _mapper.Map<Domain.LeaveType>(request.CreateLeaveTypeDto);
            leaveType = await _leaveTypeRepository.Add(leaveType);
            response.IsSuccess = true;
            response.Id = leaveType.Id;
            response.Message = "عملیات افزودن با موفقیت انجام شد";

            return response;
        }
    }
}
