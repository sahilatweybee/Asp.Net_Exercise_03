using Asp.Net_Exercise_03.Models;
using Asp.Net_Exercise_03.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.Net_Exercise_03.Controllers
{
    [Route("[controller]/[action]")]
    public class AssignPartyController : Controller
    {
        private readonly IAssignPartyRepository _AssignPartyRepo = null;
        public AssignPartyController(IAssignPartyRepository ProductRepo)
        {
            _AssignPartyRepo = ProductRepo;
        }
        public async Task<IActionResult> AssignPartyList()
        {
            var Assigns = await _AssignPartyRepo.GetAllAssignPartiesAsync();
            return View(Assigns);
        }

        [HttpGet]
        public ViewResult AssignPartyAdd(bool isSuccess = false)
        {
            ViewBag.isSuccess = isSuccess;
            return View("AssignPartyAddEdit");
        }

        [HttpPost]
        public async Task<IActionResult> AssignPartyAdd(AssignPartyModel AssignpartyModl)
        {
            if (ModelState.IsValid)
            {
                int id = await _AssignPartyRepo.AddAssignParty(AssignpartyModl);
                return RedirectToAction(nameof(AssignPartyAdd), new { isSuccess = true });
            }
            return View(AssignpartyModl);
        }
    }
}
