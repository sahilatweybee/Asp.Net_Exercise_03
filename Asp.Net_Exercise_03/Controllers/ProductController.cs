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
        public ViewResult ProductAdd(bool isSuccess = false, string Message = "")
        {
            ViewBag.message = Message;
            ViewData["Title"] = "Add Product";
            return View("ProductAddEdit");
        }
        [HttpPost]
        public async Task<IActionResult> ProductAdd(ProductModel productModl)
        {
            string msg = "";
            if (ModelState.IsValid)
            {
                if (await _ProductRepo.IsContainsProduct(productModl) == true)
                {
                    msg = "A record with the same values already exists try something else!!";
                }
                else
                {
                    int id = await _ProductRepo.AddProduct(productModl);
                    msg = "Product Addded successfully";
                }
            }
            return RedirectToAction(nameof(ProductAdd), new { isSuccess = true , Message = msg});
        }

        [Route("{product_id:int}")]
        public async Task<IActionResult> Deleteproduct([FromRoute] int product_id)
        {
            await _ProductRepo.DeleteProductAsync(product_id);
            return RedirectToAction(nameof(ProductList));
        }

        [HttpGet("{product_id:int}/{product_name}")]
        public ViewResult ProductEdit([FromRoute] int product_id, string product_name, string Message = "")
        {
            ViewData["Title"] = "Edit Product";
            return View("productAddEdit");
        }

        [HttpPost("{product_id:int}/{product_name}")]
        public async Task<IActionResult> ProductEdit([FromRoute] int product_id, ProductModel productModl)
        {
            string msg = "";
            if (await _ProductRepo.IsContainsProduct(productModl) == true)
            {
                msg = "A record with the same values already exists try something else!!";
            }
            else
            {
                await _ProductRepo.EditProductAsync(productModl, product_id);
                return RedirectToAction(nameof(ProductList));
            }
            return RedirectToAction(nameof(ProductEdit), new { Message = msg});
        }
    }
}
