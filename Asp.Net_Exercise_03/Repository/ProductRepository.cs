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
            var products = await _Context.Product_tbl.OrderBy(x => x.Product_name).ToListAsync();
            return _Mapper.Map<List<ProductModel>>(products);
        }

        public async Task<int> AddProduct(ProductModel productModl)
        {
            var product = new Product()
            {
                Product_name = productModl.Product_name
            };
            await _Context.Product_tbl.AddAsync(product);
            await _Context.SaveChangesAsync();

            return product.Product_id;
        }

        public async Task DeleteProductAsync(int id)
        {
            var product = new Product()
            {
                Product_id = id
            };
            _Context.Product_tbl.Remove(product);
            await _Context.SaveChangesAsync();
        }

        public async Task EditProductAsync(ProductModel productModl, int id)
        {
            var product = new Product()
            {
                Product_id = id,
                Product_name = productModl.Product_name            };
            _Context.Product_tbl.Update(product);
            await _Context.SaveChangesAsync();
        }

        public async Task<bool> IsContainsProduct(ProductModel producrModl)
        {
            var model = _Mapper.Map<Product>(producrModl);
            return await _Context.Product_tbl.ContainsAsync(model);
        }
    }
}
