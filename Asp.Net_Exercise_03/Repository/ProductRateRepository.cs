using Asp.Net_Exercise_03.DataBase;
using Asp.Net_Exercise_03.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.Net_Exercise_03.Repository
{
    public class ProductRateRepository : IProductRateRepository
    {
        private readonly PartyDbContext _Context = null;
        private readonly IMapper _Mapper = null;
        public ProductRateRepository(PartyDbContext context, IMapper mapper)
        {
            _Context = context;
            _Mapper = mapper;
        }

        public async Task<List<ProductRateModel>> GetAllProductRatesAsync()
        {
            var rates = await _Context.Rate_tbl.Include(x => x.Product_tbl).ToListAsync();
            return _Mapper.Map<List<ProductRateModel>>(rates);
        }

        public async Task<int> AddProductRate(ProductRateModel rateModl)
        {
            var product_rate = new ProductRate()
            {
                Product_id = rateModl.Product_id,
                Product_rate = rateModl.Product_rate,
                Date_of_Rate = rateModl.Date_of_Rate
            };
            await _Context.Rate_tbl.AddAsync(product_rate);
            await _Context.SaveChangesAsync();

            return product_rate.Rate_id;
        }

        public async Task DeleteProductRateAsync(int id)
        {
            var Rate = new ProductRate()
            {
                Rate_id = id
            };
            _Context.Rate_tbl.Remove(Rate);
            await _Context.SaveChangesAsync();
        }

        public async Task EditProductRateAsync(ProductRateModel rateModl, int id)
        {
            var productRate = new ProductRate()
            {
                Rate_id = id,
                Product_id = rateModl.Product_id,
                Product_rate = rateModl.Product_rate,
                Date_of_Rate = DateTime.Now
            };
            _Context.Rate_tbl.Update(productRate);
            await _Context.SaveChangesAsync();
        }

        public async Task<bool> IsContainsRate(int id)
        {
            var contains = await _Context.Rate_tbl.Where(x => x.Product_id == id).FirstOrDefaultAsync();
            if (contains != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
