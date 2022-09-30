using KodlamaIoDevs.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIoDevs.Persistence.EntityTypeConfigurations
{
    public class TechnologyConfiguration : IEntityTypeConfiguration<Technology>
    {
        public void Configure(EntityTypeBuilder<Technology> builder)
        {
            
            builder.ToTable("Technologies").HasKey(k => k.Id);
            builder.Property(p => p.Id).HasColumnName("Id");
            builder.Property(p => p.Name).HasColumnName("Name");
            builder.Property(p => p.LanguageId).HasColumnName("LanguageId");
            builder.HasOne(p => p.Language);

            Technology[] technologyEntitySeeds = { new(1, "WPF", 1), new(2, "ASP.NET", 1), new(3, "Spring", 2) };
            builder.HasData(technologyEntitySeeds);
        }
    }
}
