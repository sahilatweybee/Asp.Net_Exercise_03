using Asp.Net_Exercise_03.DataBase;
using Asp.Net_Exercise_03.Models;
using AutoMapper;
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
            var rates = await _Context.rate.Include(x => x.product).ToListAsync();
            return _Mapper.Map<List<ProductRateModel>>(rates);
        }
    }
}
