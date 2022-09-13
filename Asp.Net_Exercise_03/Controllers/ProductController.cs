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
    public class ProductController : Controller
    {
        private readonly IProductRepository _ProductRepo = null;
        public ProductController(IProductRepository ProductRepo)
        {
            _ProductRepo = ProductRepo;
        }
        public async Task<IActionResult> ProductList()
        {
            var products = await _ProductRepo.GetAllProductsAsync();
            return View(products);
        }
        [HttpGet]
        public ViewResult ProductAdd(bool isSuccess = false)
        {
            return View("ProductAddEdit");
        }
        [HttpPost]
        public async Task<IActionResult> ProductAdd(ProductModel productModl)
        {
            if (ModelState.IsValid)
            {
                int id = await _ProductRepo.AddProduct(productModl);
                return RedirectToAction(nameof(ProductAdd), new { isSuccess = true });
            }
            return View(productModl);
        }
    }
}
