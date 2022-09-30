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
    public class KodlamaIoUserConfiguration : IEntityTypeConfiguration<KodlamaIoUser>
    {
        public void Configure(EntityTypeBuilder<KodlamaIoUser> builder)
        {

            builder.ToTable("KodlamaIoUsers").HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("Id");
            builder.Property(p => p.GithubUrl).HasColumnName("GithubUrl");
            builder.Property(p => p.UserId).HasColumnName("UserId");
            builder.HasOne(p => p.User);

        }
    }
}
