using HR_Management.Application.DataTransferObject.LeaveRequest;
using HR_Management.Application.Features.LeaveRequest.Requests.Commands;
using HR_Management.Application.Features.LeaveRequest.Requests.Queries;
using HR_Management.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HR_Management.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LeavRequestController : ControllerBase
    {
        #region Constructor Injection

        private readonly IMediator _mediator;

        public LeavRequestController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        // GET: api/<LeavRequestController>
        [HttpGet]
        public async Task<ActionResult<List<LeaveRequestListDto>>> Get()
        {
            var leaveRequests = await _mediator.Send(new GetLeaveRequestListRequest());
            
            return Ok(leaveRequests);
        }

        // GET api/<LeavRequestController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveRequestDto>> Get(int id)
        {
            var leaveRequest = await _mediator.Send(new GetLeaveRequestDetailsRequest { Id = id });
            
            return Ok(leaveRequest);
        }

        // POST api/<LeavRequestController>
        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateLeaveRequestDto leaveRequest)
        {
            var command  = new CreateLeaveRequestCommand() { CreateLeaveRequestDto = leaveRequest };
            var response = await _mediator.Send(command);

            return Ok(response);
        }

        // PUT api/<LeavRequestController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] UpdateLeaveRequestDto leaveRequest)
        {
            var command = new UpdateLeaveRequestCommand() 
            { 
                UpdateLeaveRequestDto = leaveRequest,
                Id = id
            };
            await _mediator.Send(command);

            return NoContent();
        }

        // PUT api/<LeavRequestController>/ChangeApproval/5
        [HttpPut("ChangeApproval/{id}")]
        public async Task<ActionResult> ChangeApproval(int id, [FromBody] ChangeLeaveRequestApprovalDto leaveRequestApproval)
        {
            var command = new UpdateLeaveRequestCommand()
            {
                Id = id,
                ChangeLeaveRequestApprovalDto = leaveRequestApproval
            };
            await _mediator.Send(command);

            return NoContent();
        }

        // DELETE api/<LeavRequestController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteLeaveRequestCommand() { Id = id };
            await _mediator.Send(command);

            return NoContent();
        }
    }
}
