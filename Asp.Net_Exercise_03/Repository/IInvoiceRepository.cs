using Asp.Net_Exercise_03.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Asp.Net_Exercise_03.Repository
{
    public interface IInvoiceRepository
    {
        Task<int> AddInvoice(InvoiceModel InvoiceModl);
        Task<int> CalcGrandTotal(int Party_id);
        Task<List<InvoiceModel>> GetInvoice(int Party_id);
        Task<List<ProductModel>> GetProductsByParty(int Party_id);
        Task<int> GetRate(int id);
    }
}