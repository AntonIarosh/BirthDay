using CongratulationAPI.Domain.Entities;
using CongratulationAPI.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
//using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongratulationAPI.Infrastructure.Repositoryes.BirthDayRepository
{
    public class BirthDayRepository : Repository<BirthDay>, IBirthDayRepository
    {
        public Microsoft.EntityFrameworkCore.DbSet<BirthDay> BirhtDays { get; set; }
        public BirthDayRepository(Microsoft.EntityFrameworkCore.DbContext dbContext) :base(dbContext)
        {
            
        }

        public BirthDay FindByDayAndMonth(int day, int month)
        {
            BirthDay holiday = DbSet.Where(h => h.Month == month && h.Day == day).FirstOrDefault();
            return holiday;
        }

        public async Task<List<BirthDay>> FindByDayAndMonthAsync(int day, int month)
        {
            var result = await DbSet.Where(h => h.Month == month && h.Day == day).Include(obj => obj.Congratulations).
                Select(day => new BirthDay
                {
                    Month = day.Month,
                    Day = day.Day,
                    Id = day.Id,
                    CreationDate = day.CreationDate,
                    Congratulations = day.Congratulations,
                    IsPased = day.IsPased,
                    Users = day.Users.Select(u => new User
                    {
                        Id = u.Id,
                        Name = u.Name,
                        SecondName = u.SecondName,
                        LastName = u.LastName,
                        Gender = u.Gender,
                        CreationDate = u.CreationDate,
                        Date = u.Date,
                        Email = u.Email,
                        Knows = u.Knows,
                        KnowsToMe = u.KnowsToMe,
                        BirthDayId =  u.BirthDayId
                    }).ToList()
                }).ToListAsync();
            return result;
        }

        public async Task<List<BirthDay>> GetAllBirthDaysWithCongratulations()
        {
            return await GetAll()
                .Include(obj => obj.Congratulations)
                .ToListAsync();
        }

        /// <inheritdoc />
        public void SaveChanges()
        {
            DbContext.SaveChanges();
        }

        /// <inheritdoc />
        public Guid AddAsyncAndReturnId(BirthDay model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            DbSet.Add(model);
            SaveChanges();
            return model.Id;
        }
    }
}
