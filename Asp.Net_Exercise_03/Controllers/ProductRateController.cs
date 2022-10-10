using Asp.Net_Exercise_03.Models;
using Asp.Net_Exercise_03.Repository;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> ProductRateList(string message = "", int isSuccess = 0)
        {
            ViewBag.message = message;
            ViewBag.IsSuccess = isSuccess;
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
            return View("ProductRateAddEdit", rateModl);
        }

        public async Task<IActionResult> DeleteProductRate([FromQuery] int Rate_id)
        {
            await _RateRepository.DeleteProductRateAsync(Rate_id);
            string msg = $"Record With Id = {Rate_id} Deleted SuccessFully.";
            return RedirectToAction(nameof(ProductRateList), new { isSuccess = 1, message = msg });
        }

        [HttpGet]
        public ViewResult ProductRateEdit([FromQuery] ProductRateModel rateModl, string Message = "", int isSuccess = 0)
        {
            ViewBag.message = Message;
            ViewBag.IsSuccess = isSuccess;
            ViewData["Title"] = "Edit Product Rate";
            return View("ProductRateAddEdit", rateModl);
        }

        [HttpPost]
        public async Task<IActionResult> ProductRateEdit(ProductRateModel rateModl)
        {
            ViewData["Title"] = "Edit Product Rate";
            string msg = "";
            if (ModelState.IsValid)
            {
                await _RateRepository.EditProductRateAsync(rateModl);
                msg = "Rate Updated successfully.";
                return RedirectToAction(nameof(ProductRateList), new { isSuccess = 1, Message = msg });

            }
            return View("ProductRateAddEdit", rateModl);
        }
    }
}
