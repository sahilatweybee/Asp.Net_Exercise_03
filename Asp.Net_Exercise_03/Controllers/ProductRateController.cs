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
    }
}
