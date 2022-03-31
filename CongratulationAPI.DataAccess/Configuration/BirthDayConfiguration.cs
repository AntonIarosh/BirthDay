using CongratulationAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongratulationAPI.DataAccess.Configuration
{
    /// <summary>
    /// Конфигурация таблицы БД BirthDay
    /// </summary>
    public class BirthDayConfiguration : IEntityTypeConfiguration<BirthDay>
    {
        /// <inheritdoc />
        public void Configure(EntityTypeBuilder<BirthDay> builder)
        {
            builder.ToTable(nameof(BirthDay));
            builder.HasKey(day => day.Id);
            builder.Property(day => day.Id).ValueGeneratedOnAdd();

            builder.HasMany(day => day.Congratulations)
                .WithOne(congratulations => congratulations.BirthDay)
                .HasForeignKey(congratulations => congratulations.BirthDayId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_BirthDay_Congratulations");

            builder.HasMany(day => day.Users)
                .WithOne(user => user.BirthDay)
                .HasForeignKey(user => user.BirthDayId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_BirthDay_Users");
        }
    }
}
