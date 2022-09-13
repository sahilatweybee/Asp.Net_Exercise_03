﻿using Asp.Net_Exercise_03.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Asp.Net_Exercise_03.Repository
{
    public interface IProductRateRepository
    {
        Task<List<ProductRateModel>> GetAllProductRatesAsync();
    }
}