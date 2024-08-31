using HR_Management.WebMvc.Cantracts;
using HR_Management.WebMvc.Models.LeaveType;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR_Management.WebMvc.Controllers
{
    [Authorize]
    public class LeaveTypeController : Controller
    {

        private readonly ILeaveTypeService _leaveTypeService;
        public LeaveTypeController(ILeaveTypeService leaveTypeService)
        {
            _leaveTypeService = leaveTypeService;
        }

        // GET: LeaveTypeController
        public async Task<ActionResult> Index()
        {
            var leaveTypes = await _leaveTypeService.GetLeaveTypesList();
            return View(leaveTypes);
        }

        // GET: LeaveTypeController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var leaveType = await _leaveTypeService.GetLeaveTypesBy(id);
            return View(leaveType);
        }

        // GET: LeaveTypeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LeaveTypeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateLeaveTypeViewModel createLeaveType)
        {
            try
            {
                var result = await _leaveTypeService.CreateLeaveType(createLeaveType);

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
            return View(createLeaveType);
        }

        // GET: LeaveTypeController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var model = await _leaveTypeService.GetLeaveTypeForUpdate(id);

            return View(model);
        }

        // POST: LeaveTypeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, UpdateLeaveTypeViewModel updateLeaveType)
        {
            try
            {
                updateLeaveType.Id = id;
                var result = await _leaveTypeService.UpdateLeaveType(updateLeaveType);
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
            return View(updateLeaveType);
        }

        // GET: LeaveTypeController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var result = await _leaveTypeService.DeleteLeaveType(id);

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
