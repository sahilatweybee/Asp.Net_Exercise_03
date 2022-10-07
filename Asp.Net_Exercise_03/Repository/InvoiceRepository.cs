using Asp.Net_Exercise_03.DataBase;
using Asp.Net_Exercise_03.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.Net_Exercise_03.Repository
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly PartyDbContext _Context = null;
        private readonly IMapper _Mapper = null;
        public InvoiceRepository(PartyDbContext context, IMapper mapper)
        {
            _Context = context;
            _Mapper = mapper;
        }

        public async Task<int> AddInvoice(InvoiceModel InvoiceModl)
        {
            var invoice = new Invoice()
            {
                Party_id = InvoiceModl.Party_id,
                Product_id = InvoiceModl.Product_id,
                Product_rate = InvoiceModl.Product_rate,
                Quantity = InvoiceModl.Quantity,
                Total = InvoiceModl.Product_rate * InvoiceModl.Quantity
            };
            await _Context.Invoice_tbl.AddAsync(invoice);
            await _Context.SaveChangesAsync();
            return invoice.Invoice_id;
        }

        public async Task<List<InvoiceModel>> GetInvoice(int Party_id)
        {
            var invoices = await _Context.Invoice_tbl
                .Where(x => x.Party_id == Party_id)
                .Select(x => new InvoiceModel()
                {
                    Invoice_id = x.Invoice_id,
                    Party_id = x.Party_id,
                    Product_id = x.Product_id,
                    Product_rate = x.Product_rate,
                    Quantity = x.Quantity,
                    Total = x.Total
                }).ToListAsync();
            return invoices;
        }

        public async Task<int> CalcGrandTotal(int Party_id)
        {
            return await _Context.Invoice_tbl.Where(x => x.Party_id == Party_id).SumAsync(x => x.Total);
        }

        public async Task<List<ProductModel>> GetProductsByParty(int Party_id)
        {
            var products = await _Context.Assign_party_tbl
                .Where(x => x.Party_id == Party_id)
                .Include(x => x.Product_tbl)
                .Select(x => x.Product_tbl).ToListAsync();
            return _Mapper.Map<List<ProductModel>>(products);
        }

        public async Task<int> GetRate(int id)
        {
            return await _Context.Rate_tbl
                .Where(x => x.Product_id == id)
                .Select(x => x.Product_rate)
                .FirstOrDefaultAsync();
        }
    }
}
