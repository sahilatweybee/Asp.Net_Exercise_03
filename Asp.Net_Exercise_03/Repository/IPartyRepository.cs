using Asp.Net_Exercise_03.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Asp.Net_Exercise_03.Repository
{
    public interface IPartyRepository
    {
        Task<int> AddPartyAsync(PartyModel partyModl);
        Task DeletePartyAsync(int id);
        Task EditPartyAsync(PartyModel partyModl, int id);
        Task<List<PartyModel>> GetAllPartiesAsync();
        Task<bool> IsContainsParty(PartyModel partyModl);
    }
}