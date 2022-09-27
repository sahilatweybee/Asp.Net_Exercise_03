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
            var parties = await _Context.Assign_party_tbl.Include(x => x.Party_tbl).Include(x  => x.Product_tbl).ToListAsync();
            return _Mapper.Map<List<AssignPartyModel>>(parties);
        }

        public async Task<int> AddAssignParty(AssignPartyModel assignPartyModl)
        {
            var assignParty = new AssignParty()
            {
                Party_id = assignPartyModl.Party_id, 
                Product_id = assignPartyModl.Product_id
            };
            await _Context.Assign_party_tbl.AddAsync(assignParty);
            await _Context.SaveChangesAsync();

            return assignParty.Assign_id;
        }

        public async Task DeleteAssignAsync(int id)
        {
            var assign = new AssignParty()
            {
                Assign_id = id
            };
            _Context.Assign_party_tbl.Remove(assign);
            await _Context.SaveChangesAsync();
        }

        public async Task EditAssignPartyAsync(AssignPartyModel assignPartyModl, int id)
        {
            var assign = new AssignParty()
            {
                Assign_id = id,
                Party_id = assignPartyModl.Party_id,
                Product_id = assignPartyModl.Product_id
            };
            _Context.Assign_party_tbl.Update(assign);
            await _Context.SaveChangesAsync();
        }

        public async Task<List<ProductModel>> GetRemainingProductsByParty(int id)
        {
            //Didn't Work When tried using 2 separate tables!!

            var products = await _Context.Product_tbl
                .Except(_Context.Assign_party_tbl
                    .Where(x => x.Party_id == id)
                    .Include(x => x.Product_tbl)
                    .Select(x => x.Product_tbl)
                ).ToListAsync();
            return _Mapper.Map<List<ProductModel>>(products);
        }

        public async Task<bool> IsContainAssign(AssignPartyModel assignModl)
        {
            var contains = await _Context.Assign_party_tbl.Where(x => x.Party_id == assignModl.Party_id && x.Product_id == assignModl.Product_id).FirstOrDefaultAsync();
            if(contains == null)
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
