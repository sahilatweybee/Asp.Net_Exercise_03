using Asp.Net_Exercise_03.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Asp.Net_Exercise_03.Repository
{
    public interface IProductRepository
    {
        Task<int> AddProduct(ProductModel productModl);
        Task DeleteProductAsync(int id);
        Task EditProductAsync(ProductModel productModl, int id);
        Task<List<ProductModel>> GetAllProductsAsync();
        Task<bool> IsContainsProduct(ProductModel producrModl);
    }
}