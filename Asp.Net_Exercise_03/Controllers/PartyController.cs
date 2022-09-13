using Asp.Net_Exercise_03.Models;
using Asp.Net_Exercise_03.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.Net_Exercise_03.Controllers
{
    
    public class PartyController : Controller
    {
        private readonly IPartyRepository _PartyRepo = null;
        public PartyController(IPartyRepository PartyRepo)
        {
            _PartyRepo = PartyRepo;
        }
        [HttpGet]
        public async Task<IActionResult> PartyList()
        {
            var parties = await _PartyRepo.GetAllPartiesAsync();
            return View(parties);
        }
        [HttpGet]
        public ViewResult PartyAdd(bool isSuccess = false)
        {
            ViewBag.isSuccess = isSuccess;
            return View("PartyAddEdit");
        }

        [HttpPost]
        public async Task<IActionResult> PartyAdd(PartyModel partyModl)
        {
            if (ModelState.IsValid)
            {
                int id = await _PartyRepo.AddParty(partyModl);
                return RedirectToAction(nameof(PartyAdd),new { isSuccess = true});
            }
            return View(partyModl);
        }
    }
}
