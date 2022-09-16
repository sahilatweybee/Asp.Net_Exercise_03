using Asp.Net_Exercise_03.DataBase;
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
    public class ProductRateController : Controller
    {
        private readonly IProductRateRepository _RateRepository = null;
        public ProductRateController(IProductRateRepository RateRepo)
        {
            _RateRepository = RateRepo;
        }
        public async Task<IActionResult> ProductRateList()
        {
            var Rates = await _RateRepository.GetAllProductRatesAsync();
            return View(Rates);
        }
        [HttpGet]
        public ViewResult ProductRateAdd (bool isSuccess = false, string message = "")
        {
            ViewBag.message = message;
            ViewData["Title"] = "Add Product Rate";
            ViewBag.isSuccess = isSuccess;
            return View("ProductRateAddEdit");
        }

        [HttpPost]
        public async Task<IActionResult> ProductRateAdd(ProductRateModel rateModl)
        {
            string msg = "";
            if (ModelState.IsValid)
            {
                if (await _RateRepository.IsContainsRate(rateModl.Product_id) == true)
                {
                    msg = "Rate already exist for this product.";
                }
                else
                {
                    int id = await _RateRepository.AddProductRate(rateModl);
                    msg = "Rate added successfully.";
                }
            }
            return RedirectToAction(nameof(ProductRateAdd), new { isSuccess = true, message= msg});
        }

        [Route("{Rate_id:int}")]
        public async Task<IActionResult> DeleteProductRate([FromRoute] int Rate_id)
        {
            await _RateRepository.DeleteProductRateAsync(Rate_id);
            return RedirectToAction(nameof(ProductRateList));
        }

        [HttpGet("{Rate_id:int}/{Product_id:int}/{Product_rate:int}/{Date_of_Rate}")]
        public ViewResult ProductRateEdit([FromRoute] int Rate_id,int Product_id, int Product_rate, string Date_of_Rate, bool IsSuccess = false, string Message = "")
        {
            ViewBag.isSuccess = IsSuccess;
            ViewBag.message = Message;
            ViewData["Title"] = "Edit Product Rate";
            return View("ProductRateAddEdit");
        }

        [HttpPost("{Rate_id:int}/{Product_id:int}/{Product_rate:int}/{Date_of_Rate}")]
        public async Task<IActionResult> ProductRateEdit([FromRoute] int Rate_id, ProductRateModel rateModl)
        {
            
            if (ModelState.IsValid)
            {
                await _RateRepository.EditProductRateAsync(rateModl, Rate_id);
            }
            // new { IsSuccess = true, Message = msg}
            return RedirectToAction(nameof(ProductRateList));
        }
    }
}
