using CongratulationAPI.Domain.Entities;
using CongratulationAPI.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongratulationAPI.Infrastructure.Repositoryes.CongratulationRepository
{
    public class CongratulationRepository : Repository<Congratulation>, ICongratulationRepository
    {
        public CongratulationRepository(DbContext dbContext) :base(dbContext)
        {

        }
        public async Task<List<Congratulation>> GetAllCongratulationsWithUsersFromUsersAndBirthDays()
        {
            return await GetAll()
                .Include(obj => obj.User)
                .Include(obj => obj.FromUser)
                .Include(obj => obj.BirthDay)
                .ToListAsync();
        }
    }
}
