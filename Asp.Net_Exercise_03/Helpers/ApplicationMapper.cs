using Asp.Net_Exercise_03.DataBase;
using Asp.Net_Exercise_03.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        }
    }
}
