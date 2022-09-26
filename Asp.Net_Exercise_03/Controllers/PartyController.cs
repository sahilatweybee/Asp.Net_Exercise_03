﻿using Asp.Net_Exercise_03.Models;
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
        public ViewResult PartyAdd(bool isSuccess = false, string Message ="")
        {
            ViewBag.message = Message;
            ViewData["Title"] = "Add Party";
            ViewBag.isSuccess = isSuccess;
            return View("PartyAddEdit");
        }

        [HttpPost]
        public async Task<IActionResult> PartyAdd(PartyModel partyModl)
        {
            string msg = "";
            if (ModelState.IsValid)
            {
                if (await _PartyRepo.IsContainsParty(partyModl) == true)
                {
                    msg = "A record with the same values already exists try something else!!";
                }
                else
                {
                    int id = await _PartyRepo.AddPartyAsync(partyModl);
                    msg = "Product Addded successfully";
                }
            }
                return RedirectToAction(nameof(PartyAdd), new { isSuccess = true, Message = msg });
        }

        [Route("Party/PartyList/{party_id:int}")]
        public async Task<IActionResult> DeleteParty([FromRoute] int party_id, string party_name)
        {
            await _PartyRepo.DeletePartyAsync(party_id);
            return RedirectToAction(nameof(PartyList));
        }

        [HttpGet("Party/PartyList/{party_id:int}/{party_name}")]
        public ViewResult PartyEdit([FromRoute] int party_id, string party_name, string Message="")
        {
            ViewData["Title"] = "Edit Party";
            ViewBag.message = Message;
            return View("PartyAddEdit");
        }

        [HttpPost("Party/PartyList/{party_id:int}/{party_name}")]
        public async Task<IActionResult> PartyEdit([FromRoute] int party_id, PartyModel partyModl)
        {
            string msg = "";
            if (await _PartyRepo.IsContainsParty(partyModl) == true)
            {
                msg = "A record with the same values already exists try something else!!";
            }
            else
            {
                await _PartyRepo.EditPartyAsync(partyModl, party_id);
            }
            
            return RedirectToAction(nameof(PartyEdit), new { Message = msg});
        }

    }
}
