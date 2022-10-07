using Asp.Net_Exercise_03.DataBase;
using Asp.Net_Exercise_03.Models;
using AutoMapper;

namespace Asp.Net_Exercise_03.Helpers
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Party, PartyModel>().ReverseMap();

            CreateMap<Product, ProductModel>().ReverseMap();

            CreateMap<AssignParty, AssignPartyModel>().ReverseMap();

            CreateMap<ProductRate, ProductRateModel>().ReverseMap();

            CreateMap<Invoice, InvoiceModel>().ReverseMap();
        }
    }
}
