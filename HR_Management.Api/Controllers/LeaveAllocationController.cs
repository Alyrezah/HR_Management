using HR_Management.Application.DataTransferObject.LeaveAllocation;
using HR_Management.Application.Features.LeaveAllocation.Requests.Commands;
using HR_Management.Application.Features.LeaveAllocation.Requests.Queries;
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
    public class LeaveAllocationController : ControllerBase
    {
        #region Constructor Injection

        private readonly IMediator _mediator;

        public LeaveAllocationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        // GET: api/<LeaveAllocationController>
        [HttpGet]
        public async Task<ActionResult<List<LeaveAllocationDto>>> Get()
        {
            var leaveAllocations = await _mediator.Send(new GetLeaveAllocationListRequest());

            return Ok(leaveAllocations);
        }

        // GET api/<LeaveAllocationController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveAllocationDto>> Get(int id)
        {
            var leaveAllocation = await _mediator.Send(new GetLeaveAllocationDetailsRequest() { Id = id });

            return Ok(leaveAllocation);
        }

        // POST api/<LeaveAllocationController>
        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateLeaveAllocationDto leaveAllocation)
        {
            var command = new CreateLeaveAllocationCommand() { CreateLeaveAllocationDto = leaveAllocation };
            var response = await _mediator.Send(command);

            return Ok(response);
        }

        // PUT api/<LeaveAllocationController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] UpdateLeaveAllocationDto leaveAllocation)
        {
            leaveAllocation.Id = id;
            var command = new UpdateLeaveAllocationCommand() { UpdateLeaveAllocationDto = leaveAllocation };
            await _mediator.Send(command);

            return NoContent();
        }

        // DELETE api/<LeaveAllocationController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteLeaveAllocationCommand() { Id = id };
            await _mediator.Send(command);

            return NoContent();
        }
    }
}
