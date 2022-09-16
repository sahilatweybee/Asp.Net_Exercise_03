using Asp.Net_Exercise_03.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Asp.Net_Exercise_03.Repository
{
    public interface IAssignPartyRepository
    {
        Task<int> AddAssignParty(AssignPartyModel assignPartyModl);
        Task DeleteAssignAsync(int id);
        Task EditAssignPartyAsync(AssignPartyModel assignPartyModl, int id);
        Task<List<AssignPartyModel>> GetAllAssignPartiesAsync();
        Task<List<ProductModel>> GetRemainingProductsByParty(int id);
        Task<bool> IsContainAssign(AssignPartyModel assignModl);
    }
}