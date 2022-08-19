using CongratulationAPI.Domain.Entities;
using CongratulationAPI.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CongratulationAPI.Infrastructure.Repositoryes.UserRepository
{
    /// <inheritdoc />
    public class UserRepository : Repository<User>, IUserRepository
    {
        public Microsoft.EntityFrameworkCore.DbSet<User> Users { get; set; }

        public UserRepository(Microsoft.EntityFrameworkCore.DbContext dbContext) :base(dbContext)
        {

        }

        /// <inheritdoc />
        public async Task<List<User>> GetAllUsersWithUsersKnowsKnowsToMeAndCongratulations()
        {
            return await GetAll()
                .Include(obj => obj.Knows)
                .Include(obj => obj.KnowsToMe)
                .Include(obj => obj.Congratulations)
                .ToListAsync();
        }

        /// <inheritdoc />
        public async Task<List<User>> FindBirthDayPlusAndMinusDaysAsync(int days)
        {
            DateTime date = DateTime.UtcNow;

            DateTime before = date.AddDays(-days);
            DateTime after = date.AddDays(days);

            var resultToPast = await DbSet.Where(h => ((h.Date.Month == after.Month) && (h.Date.Day <= after.Day)) || (h.Date.Month < after.Month) )
            .Include(obj => obj.Knows).
            Include(obj => obj.KnowsToMe).ToListAsync();
           
            var resultToFuture = await DbSet.Where(h => ((h.Date.Month == before.Month) && (h.Date.Day >= before.Day)) || (h.Date.Month > after.Month))
            .Include(obj => obj.Knows).
            Include(obj => obj.KnowsToMe).ToListAsync();

            var result = resultToPast.Intersect(resultToFuture).ToList();

            return result;
        }

        /// <inheritdoc />
        public async Task<List<User>> FindByFIO(string name, string secondName, string lastName)
        {
            List<User> result = null;
            if (secondName == null && lastName == null)
            {
                result = await DbSet.Where(h => h.Name == name).
                Include(obj => obj.Knows).
                Include(obj => obj.Congratulations).
                Include(obj => obj.KnowsToMe).ToListAsync();
            } else if (name == null && lastName == null)
            {
                result = await DbSet.Where(h => h.SecondName == secondName).
                Include(obj => obj.Knows).
                Include(obj => obj.Congratulations).
                Include(obj => obj.KnowsToMe).ToListAsync();
            } else if (name == null && secondName == null)
            {
                result = await DbSet.Where(h => h.LastName == lastName).
                Include(obj => obj.Knows).
                Include(obj => obj.Congratulations).
                Include(obj => obj.KnowsToMe).ToListAsync();
            } else
            {
                result = await DbSet.Where(h => h.Name == name && h.SecondName == secondName && h.LastName == lastName).
                Include(obj => obj.Knows).
                Include(obj => obj.Congratulations).
                Include(obj => obj.KnowsToMe).ToListAsync();
            }
            return result;

        }

        /// <inheritdoc />
        public async Task<List<User>> FindByEmail(string email)
        {
            var result = await DbSet.Where(h => h.Email == email).
            Include(obj => obj.Knows).
            Include(obj => obj.Congratulations).
            Include(obj => obj.KnowsToMe).ToListAsync();

            return result;

        }
    }
}
