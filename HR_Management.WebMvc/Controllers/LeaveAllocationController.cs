using HR_Management.WebMvc.Cantracts;
using HR_Management.WebMvc.Models.LeaveAllocation;
using HR_Management.WebMvc.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR_Management.WebMvc.Controllers
{
    [Authorize]
    public class LeaveAllocationController : Controller
    {

        private readonly ILeaveAllocationService _leaveAllocationService;
        private readonly ILeaveTypeService _leaveTypeService;

        public LeaveAllocationController(ILeaveAllocationService leaveAllocationService, ILeaveTypeService leaveTypeService)
        {
            _leaveAllocationService = leaveAllocationService;
            _leaveTypeService = leaveTypeService;
        }

        // GET: LeaveAllocationController
        public async Task<ActionResult> Index()
        {
            var leaveAllocations = await _leaveAllocationService.GetLeavaAllocationList();
            return View(leaveAllocations);
        }

        // GET: LeaveAllocationController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var leaveAllocation = await _leaveAllocationService.GetLeaveAllocationBy(id);
            return View(leaveAllocation);
        }

        // GET: LeaveAllocationController/Create
        public async Task<ActionResult> Create()
        {
            return View(new CreateLeaveAllocationViewModel
            {
                LeaveTypes = await _leaveTypeService.GetLeaveTypesList()
            });
        }

        // POST: LeaveAllocationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateLeaveAllocationViewModel createLeaveAllocation)
        {
            try
            {
                var result = await _leaveAllocationService.CreateLeaveAllocation(createLeaveAllocation);
                if (result.IsSuccess)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError("", result.ValidationErrors);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            createLeaveAllocation.LeaveTypes = await _leaveTypeService.GetLeaveTypesList();
            return View(createLeaveAllocation);
        }

        // GET: LeaveAllocationController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var model = await _leaveAllocationService.GetLeaveAllocationForUpdate(id);
            model.LeaveTypes = await _leaveTypeService.GetLeaveTypesList();
            return View(model);
        }

        // POST: LeaveAllocationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, UpdateLeaveAllocationViewModel updateLeaveAllocation)
        {
            try
            {
                updateLeaveAllocation.Id = id;
                var result = await _leaveAllocationService.UpdateLeaveAllocation(updateLeaveAllocation);
                if (result.IsSuccess)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError("", result.ValidationErrors);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            updateLeaveAllocation.LeaveTypes = await _leaveTypeService.GetLeaveTypesList();
            return View(updateLeaveAllocation);
        }

        // GET: LeaveAllocationController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var result = await _leaveAllocationService.DeleteLeaveAllocation(id);
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
