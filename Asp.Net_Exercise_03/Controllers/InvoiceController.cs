using Asp.Net_Exercise_03.Models;
using Asp.Net_Exercise_03.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Asp.Net_Exercise_03.Controllers
{
    [Route("[controller]/[action]")]
    public class InvoiceController : Controller
    {
        private readonly IInvoiceRepository _InvoiceRepo = null;
        public InvoiceController(IInvoiceRepository InvoiceRepo)
        {
            _InvoiceRepo = InvoiceRepo;
        }
        public async Task<IActionResult> Index(int Party_id = 0, bool Added = false, int isSuccess = 0)
        {
            if (Added == true)
            {
                ViewBag.Invoices = await _InvoiceRepo.GetInvoice(Party_id);
                ViewBag.DisPlayTable = true;
                ViewBag.IsSuccess = isSuccess;
                ViewBag.GrandTotal = await _InvoiceRepo.CalcGrandTotal(Party_id);
                return View("Invoice");
            }
            ViewBag.GrandTotal = "";
            ViewBag.DisPlayTable = false;
            return View("Invoice");
        }

        [HttpPost]
        public async Task<IActionResult> AddInvoice(InvoiceModel InvoiceModl)
        {
            if (ModelState.IsValid)
            {
                int id = await _InvoiceRepo.AddInvoice(InvoiceModl);
                return RedirectToAction(nameof(Index), new { isSuccess = 0, InvoiceModl.Party_id, Added = true });
            }
            ViewBag.DisPlayTable = false;

            return View("Invoice");

        }

        public async Task<JsonResult> GetProductById(int id)
        {
            List<ProductModel> products = await _InvoiceRepo.GetProductsByParty(id);
            products.Insert(0, new ProductModel()
            {
                Product_id = 0,
                Product_name = "--Select Product--"
            });
            return Json(products);
        }

        public async Task<JsonResult> GetProductRate(int id)
        {
            var Rate = await _InvoiceRepo.GetRate(id);
            return Json(Rate);
        }
    }
}
