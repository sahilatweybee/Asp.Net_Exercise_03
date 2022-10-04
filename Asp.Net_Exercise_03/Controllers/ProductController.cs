﻿using Asp.Net_Exercise_03.Models;
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
        public async Task<IActionResult> ProductList(string message = "", int isSuccess = 0)
        {
            ViewBag.message = message;
            ViewBag.IsSuccess = isSuccess;
            var products = await _ProductRepo.GetAllProductsAsync();
            return View(products);
        }
        [HttpGet]
        public ViewResult ProductAdd(int isSuccess = 0 ,string Message = "")
        {
            ViewBag.message = Message;
            ViewBag.IsSuccess = isSuccess;
            ViewData["Title"] = "Add Product";
            return View("ProductAddEdit");
        }
        [HttpPost]
        public async Task<IActionResult> ProductAdd(ProductModel productModl)
        {
            ViewData["Title"] = "Add Product";
            string msg = "";
            if (ModelState.IsValid)
            {
                if (await _ProductRepo.IsContainsProduct(productModl) == true)
                {
                    msg = "A record with the same values already exists try something else!!";
                    return RedirectToAction(nameof(ProductAdd), new { isSuccess = 2, Message = msg });
                }
                else
                {
                    int id = await _ProductRepo.AddProduct(productModl);
                    msg = "Product Addded successfully";
                    return RedirectToAction(nameof(ProductAdd), new { isSuccess = 1, Message = msg });
                }
            
            }
            return View("ProductAddEdit");
        }

        [Route("{product_id:int}")]
        public async Task<IActionResult> Deleteproduct([FromRoute] int product_id)
        {
            await _ProductRepo.DeleteProductAsync(product_id);
            string msg = $"Product With Id = {product_id} Deleted SuccessFully.";
            return RedirectToAction(nameof(ProductList), new { isSuccess = 1, message = msg });
        }

        [HttpGet("{product_id:int}/{product_name}")]
        public ViewResult ProductEdit([FromRoute] int product_id, string product_name,int isSuccess = 0 ,string Message = "")
        {
            ViewBag.message = Message;
            ViewBag.IsSuccess = isSuccess;
            ViewData["Title"] = "Edit Product";
            return View("productAddEdit");
        }

        [HttpPost("{product_id:int}/{product_name}")]
        public async Task<IActionResult> ProductEdit([FromRoute] int product_id, ProductModel productModl)
        {
            ViewData["Title"] = "Edit Product";
            string msg = "";
            if (ModelState.IsValid)
            {
                if (await _ProductRepo.IsContainsProduct(productModl) == true)
                {
                    msg = "A record with the same values already exists try something else!!";
                    return RedirectToAction(nameof(ProductEdit), new { isSuccess = 2, Message = msg });
                }
                else
                {
                    await _ProductRepo.EditProductAsync(productModl, product_id);
                    msg = "Product Updated Successfully.";
                    return RedirectToAction(nameof(ProductEdit), new { isSuccess = 1, Message = msg });
                }
                
            }
            return View("productAddEdit");
        }
    }
}
