using Asp.Net_Exercise_03.DataBase;
using Asp.Net_Exercise_03.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.Net_Exercise_03.Repository
{
    public class PartyRepository : IPartyRepository
    {
        private readonly PartyDbContext _Context = null;
        private readonly IMapper _Mapper = null;
        public PartyRepository(PartyDbContext context, IMapper mapper)
        {
            _Context = context;
            _Mapper = mapper;
        }

        public async Task<List<PartyModel>> GetAllPartiesAsync()
        {
            var parties = await _Context.party.OrderBy(x => x.party_name).ToListAsync();
            return _Mapper.Map<List<PartyModel>>(parties);
        }

        public async Task<int> AddParty(PartyModel partyModl)
        {
            var party = new Party()
            {
                party_name = partyModl.party_name
            };
            await _Context.party.AddAsync(party);
            await _Context.SaveChangesAsync();

            return party.party_id;
        }
    }
}
