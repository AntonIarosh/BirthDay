using CongratulationAPI.DataAccess.Configuration;
using Microsoft.EntityFrameworkCore;

namespace CongratulationAPI.DataAccess
{
    /// <summary>
    /// Базовый контекст приложения
    /// </summary>
    public class BaseDbContext: DbContext
    {
        public BaseDbContext(DbContextOptions options): base(options)
        {


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new BirthDayConfiguration());
            modelBuilder.ApplyConfiguration(new CongratulationConfiguration());
            modelBuilder.ApplyConfiguration(new KnowConfiguration());
        }
    }
}
