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
    /// Конфигурация таблицы БД Congratulation
    /// </summary>
    public class CongratulationConfiguration : IEntityTypeConfiguration<Congratulation>
    {
        /// <inheritdoc />
        public void Configure(EntityTypeBuilder<Congratulation> builder)
        {
            builder.ToTable(nameof(Congratulation));
            builder.HasKey(congratulation => congratulation.Id);
            builder.Property(congratulation => congratulation.Id).ValueGeneratedOnAdd();    
        }
    }
}
