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
        public ViewResult AssignPartyAdd(string Message = "", int isSuccess = 0)
        {
            ViewData["Title"] = "Assign Party";
            ViewBag.IsSuccess = isSuccess;
            ViewBag.message = Message;
            return View("AssignPartyAddEdit");
        }

        [HttpPost]
        public async Task<IActionResult> AssignPartyAdd(AssignPartyModel AssignpartyModl)
        {
            ViewData["Title"] = "Assign Party";
            string msg = "";
            if (ModelState.IsValid)
            {
                if (await _AssignPartyRepo.IsContainAssign(AssignpartyModl) == true)
                {
                    msg = "A record with the same values already exists try something else!!";
                    return RedirectToAction(nameof(AssignPartyAdd), new { isSuccess = 2, Message = msg }); ;
                }
                else
                {
                    int id = await _AssignPartyRepo.AddAssignParty(AssignpartyModl);
                    msg = "Party assigned successfully";
                    return RedirectToAction(nameof(AssignPartyAdd), new { isSuccess = 1, Message = msg });
                }
            }
            return View("AssignPartyAddEdit");
        }

        [Route("{assign_id:int}")]
        public async Task<IActionResult> DeleteAssign([FromRoute] int assign_id)
        {
            await _AssignPartyRepo.DeleteAssignAsync(assign_id);
            return RedirectToAction(nameof(AssignPartyList));
        }

        [HttpGet("{assign_id:int}/{party_id:int}/{product_id:int}")]
        public ViewResult AssignPartyEdit([FromRoute] int assign_id, int party_id, int product_id, string Message = "", int isSuccess = 0)
        {
            ViewData["Title"] = "Edit Assigned Party";
            ViewBag.message = Message;
            ViewBag.IsSuccess = isSuccess;
            return View("AssignPartyAddEdit");
        }

        [HttpPost("{assign_id:int}/{party_id}/{product_id}")]
        public async Task<IActionResult> AssignPartyEdit([FromRoute] int assign_id, AssignPartyModel assignModl)
        {
            string msg = "";
            if (ModelState.IsValid)
            {
                if (await _AssignPartyRepo.IsContainAssign(assignModl) == true)
                {
                    msg = "A record with the same values already exists try something else!!";
                    return RedirectToAction(nameof(AssignPartyEdit), new { isSuccess = 2, Message = msg });
                }
                else
                {
                    await _AssignPartyRepo.EditAssignPartyAsync(assignModl, assign_id);
                    msg = "Assign Party Updated Successfully.";
                    return RedirectToAction(nameof(AssignPartyEdit), new { isSuccess = 1, Message = msg });
                }
            
            }
            return View("AssignPartyAddEdit");
        }

        public async Task<JsonResult> GetProductsForParty(int id)
        {
            // Products = new List<ProductModel>();
            List<ProductModel> Products = await _AssignPartyRepo.GetRemainingProductsByParty(id);
            Products.Insert(0, new ProductModel()
            {
                Product_id = 0,
                Product_name = "--Select Product--"
            });
            return Json(Products);
        }
    }
}
