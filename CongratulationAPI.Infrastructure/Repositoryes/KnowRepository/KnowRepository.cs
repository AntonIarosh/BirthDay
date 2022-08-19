using CongratulationAPI.Domain.Entities;
using CongratulationAPI.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CongratulationAPI.Infrastructure.Repositoryes.KnowRepository
{
    public class KnowRepository : Repository<Know>, IKnowRepository
    {
        public KnowRepository(DbContext dbContext) :base(dbContext)
        {

        }
        public async Task<List<Know>> GetAllKnowsWithUsersСonnectedFromBothSides()
        {
            return await GetAll()
                .Include(obj => obj.FromUser)
                .Include(obj => obj.KnowUser)
                .ToListAsync();
        }
    }
}
