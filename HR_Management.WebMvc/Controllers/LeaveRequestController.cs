using HR_Management.WebMvc.Cantracts;
using HR_Management.WebMvc.Models.LeaveRequest;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace HR_Management.WebMvc.Controllers
{
    [Authorize]
    public class LeaveRequestController : Controller
    {

        private readonly ILeaveRequestService _leaveRequestService;
        private readonly ILeaveTypeService _leaveTypeService;
        public LeaveRequestController(ILeaveRequestService leaveRequestService, ILeaveTypeService leaveTypeService)
        {
            _leaveRequestService = leaveRequestService;
            _leaveTypeService = leaveTypeService;
        }

        // GET: LeaveRequestController
        public async Task<ActionResult> Index()
        {
            var leaveRequests = await _leaveRequestService.GetLeaveRequestList();
            return View(leaveRequests);
        }

        // GET: LeaveRequestController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var leaveRequest = await _leaveRequestService.GetLeaveRequestBy(id);
            return View(leaveRequest);
        }

        // GET: LeaveRequestController/Create
        public async Task<ActionResult> Create()
        {
            return View(new CreateLeaveRequestViewModel()
            {
                LeaveTypes = await _leaveTypeService.GetLeaveTypesList()
            });
        }

        // POST: LeaveRequestController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateLeaveRequestViewModel createLeaveRequest)
        {
            try
            {
                var result = await _leaveRequestService.CreateLeaveRequest(createLeaveRequest);
                if (result.IsSuccess)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError("", result.ValidationErrors);
                }
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            createLeaveRequest.LeaveTypes = await _leaveTypeService.GetLeaveTypesList();
            return View(createLeaveRequest);
        }

        // GET: LeaveRequestController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var model = await _leaveRequestService.GetLeaveRequestForUpdate(id);
            model.LeaveTypes = await _leaveTypeService.GetLeaveTypesList();
            return View(model);
        }

        // POST: LeaveRequestController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, UpdateLeaveRequestViewModel updateLeaveRequest)
        {
            try
            {
                updateLeaveRequest.Id = id;
                var result = await _leaveRequestService.UpdateLeaveRequest(updateLeaveRequest);
                if (result.IsSuccess)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError("", result.ValidationErrors);
                }
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            updateLeaveRequest.LeaveTypes = await _leaveTypeService.GetLeaveTypesList();
            return View();
        }

        // GET: LeaveRequestController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var result = await _leaveRequestService.DeleteLeaveRequest(id);

                if (result.IsSuccess)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError("", result.Message);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return BadRequest();
        }
    }
}
