using Asp.Net_Exercise_03.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Asp.Net_Exercise_03.Repository
{
    public interface IProductRateRepository
    {
        Task<int> AddProductRate(ProductRateModel rateModl);
        Task DeleteProductRateAsync(int id);
        Task EditProductRateAsync(ProductRateModel rateModl, int id);
        Task<List<ProductRateModel>> GetAllProductRatesAsync();
        Task<bool> IsContainsRate(int id);
    }
}