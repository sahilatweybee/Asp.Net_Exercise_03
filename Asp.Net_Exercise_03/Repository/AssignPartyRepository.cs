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
    public class AssignPartyRepository : IAssignPartyRepository
    {
        private readonly PartyDbContext _Context = null;
        private readonly IMapper _Mapper = null;
        public AssignPartyRepository(PartyDbContext context, IMapper mapper)
        {
            _Context = context;
            _Mapper = mapper;
        }

        public async Task<List<AssignPartyModel>> GetAllAssignPartiesAsync()
        {
            var parties = await _Context.assign_party.Include(x => x.party).Include(x  => x.product).ToListAsync();
            return _Mapper.Map<List<AssignPartyModel>>(parties);
        }

        public async Task<int> AddAssignParty(AssignPartyModel assignPartyModl)
        {
            var assignParty = new AssignParty()
            {
                party = assignPartyModl.party,
                product = assignPartyModl.product
            };
            await _Context.assign_party.AddAsync(assignParty);
            await _Context.SaveChangesAsync();

            return assignParty.assign_id;
        }
    }
}
