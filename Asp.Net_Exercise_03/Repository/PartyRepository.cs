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
            var parties = await _Context.Party_tbl.OrderBy(x => x.Party_name).ToListAsync();
            return _Mapper.Map<List<PartyModel>>(parties);
        }

        public async Task<int> AddPartyAsync(PartyModel partyModl)
        {
            var party = new Party()
            {
                Party_name = partyModl.Party_name
            };
            await _Context.Party_tbl.AddAsync(party);
            await _Context.SaveChangesAsync();

            return party.Party_id;
        }

        public async Task DeletePartyAsync(int id)
        {
            var party = new Party()
            {
                Party_id = id
            };
            _Context.Party_tbl.Remove(party);
            await _Context.SaveChangesAsync();
        }

        public async Task EditPartyAsync(PartyModel partyModl)
        {
            var party = new Party()
            {
                Party_id = partyModl.Party_id,
                Party_name = partyModl.Party_name
            };
            _Context.Party_tbl.Update(party);
            await _Context.SaveChangesAsync();
        }

        public async Task<bool> IsContainsParty(PartyModel partyModl)
        {
            var model = await _Context.Party_tbl.Where(x => x.Party_name == partyModl.Party_name).FirstOrDefaultAsync();
            if(model== null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}
