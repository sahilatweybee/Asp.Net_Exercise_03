using Asp.Net_Exercise_03.DataBase;
using Asp.Net_Exercise_03.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.Net_Exercise_03.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly PartyDbContext _Context = null;
        private readonly IMapper _Mapper = null;
        public ProductRepository(PartyDbContext context, IMapper mapper)
        {
            _Context = context;
            _Mapper = mapper;
        }

        public async Task<List<ProductModel>> GetAllProductsAsync()
        {
            var products = await _Context.product.OrderBy(x => x.product_name).ToListAsync();
            return _Mapper.Map<List<ProductModel>>(products);
        }

        public async Task<int> AddProduct(ProductModel productModl)
        {
            var product = new Product()
            {
                product_name = productModl.product_name
            };
            await _Context.product.AddAsync(product);
            await _Context.SaveChangesAsync();

            return product.product_id;
        }
    }
}
