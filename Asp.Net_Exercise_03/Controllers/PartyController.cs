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
        public ViewResult PartyAdd(int isSuccess = 0, string Message = null)
        {
            ViewBag.message = Message;
            ViewData["Title"] = "Add Party";
            ViewBag.isSuccess = isSuccess;
            return View("PartyAddEdit");
        }

        [HttpPost]
        public async Task<IActionResult> PartyAdd(PartyModel partyModl)
        {
            ViewData["Title"] = "Add Party";
            string msg = "";
            if (ModelState.IsValid)
            {
                bool contain = await _PartyRepo.IsContainsParty(partyModl);
                if ( contain == true)
                {
                    msg = "A record with the same values already exists try something else!!";
                    return RedirectToAction(nameof(PartyAdd), new { isSuccess = 2, Message = msg });
                }
                else
                {
                    int id = await _PartyRepo.AddPartyAsync(partyModl);
                    msg = "Product Addded successfully";
                    return RedirectToAction(nameof(PartyAdd), new { isSuccess = 1, Message = msg });
                }
            }
            return View("PartyAddEdit");
        }

        [Route("Party/PartyList/{party_id:int}")]
        public async Task<IActionResult> DeleteParty([FromRoute] int party_id, string party_name)
        {
            await _PartyRepo.DeletePartyAsync(party_id);
            return RedirectToAction(nameof(PartyList));
        }

        [HttpGet("Party/PartyList/{party_id:int}/{party_name}")]
        public ViewResult PartyEdit([FromRoute] int party_id, string party_name, int isSuccess = 0, string Message = "")
        {
            ViewData["Title"] = "Edit Party";
            ViewBag.message = Message;
            ViewBag.IsSuccess = isSuccess;
            return View("PartyAddEdit");
        }

        [HttpPost("Party/PartyList/{party_id:int}/{party_name}")]
        public async Task<IActionResult> PartyEdit([FromRoute] int party_id, PartyModel partyModl)
        {
            string msg = "";
            if (ModelState.IsValid)
            {
                if (await _PartyRepo.IsContainsParty(partyModl) == true)
                {
                    msg = "A record with the same values already exists try something else!!";
                    return RedirectToAction(nameof(PartyEdit), new { isSuccess = 2, Message = msg });
                }
                else
                {
                    await _PartyRepo.EditPartyAsync(partyModl, party_id);
                    msg = "record Updated Successfully.";
                    return RedirectToAction(nameof(PartyEdit), new { isSuccess = 1, Message = msg });
                }
                
            }
            return View("PartyAddEdit");
        }

    }
}
