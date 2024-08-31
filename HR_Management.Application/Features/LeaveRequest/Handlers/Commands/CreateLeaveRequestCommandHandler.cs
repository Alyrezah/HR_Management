using AutoMapper;
using FluentValidation;
using HR_Management.Application.DataTransferObject.LeaveRequest.Validator;
using HR_Management.Application.Features.LeaveRequest.Requests.Commands;
using HR_Management.Application.Cantracts.Persistence;
using HR_Management.Application.Responses;
using HR_Management.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HR_Management.Application.Cantracts.Infrastructure;
using HR_Management.Application.Models;

namespace HR_Management.Application.Features.LeaveRequest.Handlers.Commands
{
    public class CreateLeaveRequestCommandHandler : IRequestHandler<CreateLeaveRequestCommand, BaseCommandResponse>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;
        private readonly IEmailSender _emailSender;
        public CreateLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper
            , ILeaveTypeRepository leaveTypeRepository, IEmailSender emailSender)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
            _emailSender = emailSender;
        }

        public async Task<BaseCommandResponse> Handle(CreateLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            #region Validation

            var validator = new CreateLeaveRequestDtoValidator(_leaveTypeRepository);
            var validatorResult = await validator.ValidateAsync(request.CreateLeaveRequestDto);

            if (validatorResult.IsValid == false)
            {
                /*
                throw new Exceptions.ValidationException(validatorResult);
                */

                response.IsSuccess = false;
                response.Message = "عملیات افزودن با خطا مواجه شد";
                response.ErrorMessages = validatorResult.Errors.Select(e => e.ErrorMessage).ToList();
                return response;
            }

            #endregion

            var leaveRequest = _mapper.Map<Domain.LeaveRequest>(request.CreateLeaveRequestDto);
            leaveRequest = await _leaveRequestRepository.Add(leaveRequest);
            response.IsSuccess = true;
            response.Message = "عملیات افزودن با موفقیت انجام شد";
            response.Id = leaveRequest.Id;

            #region Send Email

            var email = new Email()
            {
                DestinationEmail = "alireza80heydri@gmail.com",
                Subject = "Your request is submit",
                Body = $"Your leave request for {request.CreateLeaveRequestDto.StartDate}" +
                $" to {request.CreateLeaveRequestDto.EndDate} has been submited."
            };

            try
            {
                await _emailSender.SendEmail(email);
            }
            catch (Exception e)
            {

            }

            #endregion

            return response;

            /*
            return leaveRequest.Id;
            */
        }
    }
}
