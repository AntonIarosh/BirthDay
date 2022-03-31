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
    /// Конфигурация таблицы БД User
    /// </summary>
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        /// <inheritdoc />
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable(nameof(User));
            builder.HasKey(user => user.Id);
            builder.Property(user => user.Id).ValueGeneratedOnAdd();

            builder.HasMany(user => user.MyCongratulations)
                .WithOne(congratulations => congratulations.User)
                .HasForeignKey(congratulations => congratulations.UserId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_User_Congratulations");

            builder.HasMany(user => user.Congratulations)
                .WithOne(congratulations => congratulations.FromUser)
                .HasForeignKey(congratulations => congratulations.FromUserId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_User_Congratulations_From_");

            builder.HasMany(user => user.Knows)
                .WithOne(knows => knows.FromUser)
                .HasForeignKey(knows => knows.FromUserId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_User_Cnows");

            builder.HasMany(user => user.KnowsToMe)
                .WithOne(knows => knows.KnowUser)
                .HasForeignKey(knows => knows.KnowUserId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_User_Knows_");
        }
    }
}
