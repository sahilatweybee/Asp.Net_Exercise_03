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
        public ViewResult ProductRateAdd(string message = "", int isSuccess = 0)
        {
            ViewBag.message = message;
            ViewBag.IsSuccess = isSuccess;
            ViewData["Title"] = "Add Product Rate";
            return View("ProductRateAddEdit");
        }

        [HttpPost]
        public async Task<IActionResult> ProductRateAdd(ProductRateModel rateModl)
        {
            ViewData["Title"] = "Add Product Rate";
            string msg = "";
            if (ModelState.IsValid)
            {
                if (await _RateRepository.IsContainsRate(rateModl.Product_id) == true)
                {
                    msg = "Rate already exist for this product.";
                    return RedirectToAction(nameof(ProductRateAdd), new { isSuccess = 2, message = msg });
                }
                else
                {
                    int id = await _RateRepository.AddProductRate(rateModl);
                    msg = "Rate added successfully.";
                    return RedirectToAction(nameof(ProductRateAdd), new { isSuccess = 1, message = msg });
                }
                
            }
            return View("ProductRateAddEdit");
        }

        [Route("{Rate_id:int}")]
        public async Task<IActionResult> DeleteProductRate([FromRoute] int Rate_id)
        {
            await _RateRepository.DeleteProductRateAsync(Rate_id);
            return RedirectToAction(nameof(ProductRateList));
        }

        [HttpGet("{Rate_id:int}/{Product_id:int}/{Product_rate:int}/{Date_of_Rate}")]
        public ViewResult ProductRateEdit([FromRoute] int Rate_id, int Product_id, int Product_rate, string Date_of_Rate, string Message = "", int isSuccess = 0)
        {
            ViewBag.message = Message;
            ViewBag.IsSuccess = isSuccess;
            ViewData["Title"] = "Edit Product Rate";
            return View("ProductRateAddEdit");
        }

        [HttpPost("{Rate_id:int}/{Product_id:int}/{Product_rate:int}/{Date_of_Rate}")]
        public async Task<IActionResult> ProductRateEdit([FromRoute] int Rate_id, ProductRateModel rateModl)
        {
            ViewData["Title"] = "Edit Product Rate";
            string msg = "";
            if (ModelState.IsValid)
            {
                if (await _RateRepository.IsContainsRate(rateModl.Product_id) == true)
                {
                    msg = "Rate already exist for this product.";
                    return RedirectToAction(nameof(ProductRateList), new { isSuccess = 2, Message = msg });
                }
                else
                {
                    await _RateRepository.EditProductRateAsync(rateModl, Rate_id);
                    msg = "Rate added successfully.";
                    return RedirectToAction(nameof(ProductRateList), new { isSuccess = 1, Message = msg });
                }
                
            }
            return View("ProductRateAddEdit");
            // new { IsSuccess = true, Message = msg}
        }
    }
}
