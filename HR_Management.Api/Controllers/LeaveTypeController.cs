using HR_Management.Application.DataTransferObject.LeaveType;
using HR_Management.Application.Features.LeaveType.Requests.Commands;
using HR_Management.Application.Features.LeaveType.Requests.Queries;
using HR_Management.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace HR_Management.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LeaveTypeController : ControllerBase
    {
        #region Constructor Injection

        private readonly IMediator _mediator;

        public LeaveTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        // GET: api/<LeaveTypeController>
        [HttpGet]
        public async Task<ActionResult<List<LeaveTypeDto>>> Get()
        {
            var leaveTypes = await _mediator.Send(new GetLeaveTypeListRequest());

            return Ok(leaveTypes);
        }

        // GET api/<LeaveTypeController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveTypeDto>> Get(int id)
        {
            var leaveType = await _mediator.Send(new GetLeaveTypeDetailsRequest { Id = id });

            return Ok(leaveType);
        }

        // POST api/<LeaveTypeController>
        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateLeaveTypeDto leaveType)
        {
            var command = new CreateLeaveTypeCommand() { CreateLeaveTypeDto = leaveType };
            var response = await _mediator.Send(command);

            return Ok(response);
        }

        // PUT api/<LeaveTypeController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] UpdateLeaveTypeDto leaveType)
        {
            leaveType.Id = id;
            var command = new UpdateLeaveTypeCommand() { UpdateLeaveTypeDto = leaveType };
            await _mediator.Send(command);

            return NoContent();
        }

        // DELETE api/<LeaveTypeController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command  = new DeleteLeaveTypeCommand() { Id = id };
            await _mediator.Send(command);

            return NoContent();
        }
    }
}
