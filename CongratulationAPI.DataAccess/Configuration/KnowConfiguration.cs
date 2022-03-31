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
    /// Конфигурация таблицы БД Know
    /// </summary>
    public class KnowConfiguration : IEntityTypeConfiguration<Know>
    {
        /// <inheritdoc />
        public void Configure(EntityTypeBuilder<Know> builder)
        {
            builder.ToTable(nameof(Know));
            builder.HasKey(user => user.Id);
            builder.Property(user => user.Id).ValueGeneratedOnAdd();
            builder.Property(user => user.UserStatus).HasConversion<int>();
        }
    }
}
